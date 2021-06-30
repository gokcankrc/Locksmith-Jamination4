using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private float pushMaxCdTime;
    [SerializeField] private float pushMaxDuration;
    [SerializeField] private float pushSpeed;
    [SerializeField] private bool onCooldown;
    

    private float pushCdTime;
    private EntityBaseClass entity;
    private Rigidbody2D rb;
    private float pushDuration;
    private Vector2 direction;

    private void Awake()
    {
        entity = GetComponent<EntityBaseClass>();
        rb = GetComponent<Rigidbody2D>();
        pushDuration = pushMaxDuration;
    }

    private void Update()
    {
        if (pushDuration > 0 && entity.Pushing)
        {
            pushDuration -= Time.deltaTime;
            if (pushDuration <= 0)
            {
                pushDuration = pushMaxDuration;
                entity.Pushing = false;
            }
        }
        if (onCooldown)
        {
            pushCdTime -= Time.deltaTime;
            if (pushCdTime < 0)
                onCooldown = false;
        }
    }

    public void UseSkill(DamagingAbility damaging)
    {
        if (true)
        {
            pushCdTime = pushMaxCdTime;
            pushDuration= pushMaxDuration;
            onCooldown = true;
            // entity.Pushing = true;
            direction = damaging.EffectDirection;;
            rb.velocity = direction * pushSpeed * Time.fixedDeltaTime;
        }
    }
}
