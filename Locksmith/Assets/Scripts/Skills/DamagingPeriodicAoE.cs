using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// Bu isim okdr çok "inheritence kullan" diye bağırıyor ki inanamazsın
public class DamagingPeriodicAoE : DamagingAoE
{
    // periodically checks and deals damage
    [SerializeField] private float damageFrequency = 2;
    [SerializeField] private float tickCounter=0;
    List <Collider2D> currentColliders = new List <Collider2D> ();
    List <Collider2D> toBeRemovedColliders = new List <Collider2D> ();
    protected override void Start()
    {
        base.Start();
        // so the multiplayer kinda stays the same. like, if damage was more frequent, it doesn't damage more.
        skillDamageMultiplayer /= damageFrequency;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        // Effect things in surroundings
        if (!CounterTick()) return;
        // I had to do this like this or it was giving error in foreach in currentCollisions
        foreach (var collider2d in toBeRemovedColliders)
        {
            currentColliders.Remove(collider2d);
        }
        foreach (var collider2d in currentColliders)
        {
            base.Interract(collider2d);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        currentColliders.Add(other);
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        // I had to do this like this or it was giving error in foreach
        // Alternative was to currentColliders.Remove(other)
        toBeRemovedColliders.Add(other);
    }

    protected bool CounterTick()
    {
        tickCounter -= Time.fixedDeltaTime;
        if (tickCounter >= 0) return false;
        tickCounter += 1 / damageFrequency;
        return true;
    }
}
