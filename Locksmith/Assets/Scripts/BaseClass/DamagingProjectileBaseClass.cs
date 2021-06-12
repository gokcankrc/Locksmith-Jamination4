using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;
using Debug = UnityEngine.Debug;

public abstract class DamagingProjectileBaseClass : DamagingAbility
{
    [SerializeField] public ProjectileStats projectileStats;
    
    private void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        var vel = rb.velocity;
        rb.velocity=  vel.normalized * projectileStats.Speed;
        EffectDirection = vel.normalized;
    }
    
    protected void FixedUpdate()
    {
        projectileStats.Duration -= Time.fixedDeltaTime;
        if (projectileStats.Duration <= 0)
        {
            Destroy(gameObject);
        }
    }


    protected override void OnPlayerCollision(EntityBaseClass otherEntity)
    {
        DefaultCollision(otherEntity);
    }

    protected override void OnEnemyCollision(EntityBaseClass otherEntity)
    {
        DefaultCollision(otherEntity);
    }

    protected void DefaultCollision(EntityBaseClass otherEntity)
    {
        if (projectileStats.Pierce < 0)
        {
            return;
        };
        ApplyHostileEffects(otherEntity);
        projectileStats.Pierce -= 1;
        if (projectileStats.Pierce < 0) Destroy(gameObject);
    }

    protected override void OnObstacleCollision()
    {
        Destroy(gameObject);
    }


    protected override void DealDamage()
    {
        _collisionEntity.healthClass.TakeDamage(projectileStats.Damage);
    }
    protected override void Heal() { return; }
}



