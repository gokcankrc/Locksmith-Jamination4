using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public abstract class Projectile : DamagingAbility
{
    [SerializeField] public ProjectileStats stats;
    
    private void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        var vel = rb.velocity;
        rb.velocity=  vel.normalized * stats.Speed;
    }
    
    protected  void FixedUpdate()
    {
        stats.Duration -= Time.fixedDeltaTime;
        if (stats.Duration <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    protected override void DealDamage() { _collisionEntity.healthClass.TakeDamage(stats.Damage); }
}



