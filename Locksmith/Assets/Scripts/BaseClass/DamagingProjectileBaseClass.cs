using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;
using Debug = UnityEngine.Debug;

public abstract class DamagingProjectileBaseClass : DamagingAbility
{
    private void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        var vel = rb.velocity;
        rb.velocity=  vel.normalized * stats.ProjectileSpeed;
        EffectDirection = vel.normalized;
    }
    
    protected void FixedUpdate()
    {
        stats.ProjectileDuration -= Time.fixedDeltaTime;
        if (stats.ProjectileDuration <= 0)
        {
            Destroy(gameObject);
        }
    }


    protected override void OnPlayerCollision(EntityBaseClass otherEntity)
    {
        if (stats.ProjectilePierce < 0) return;
        
        base.OnPlayerCollision(otherEntity);
        
        stats.ProjectilePierce -= 1;
        if (stats.ProjectilePierce < 0) Destroy(gameObject);
    }

    protected override void OnEnemyCollision(EntityBaseClass otherEntity)
    {
        if (stats.ProjectilePierce < 0) return;
        
        base.OnEnemyCollision(otherEntity);
        
        stats.ProjectilePierce -= 1;
        if (stats.ProjectilePierce < 0) Destroy(gameObject);

    }

    protected override void OnObstacleCollision()
    {
        Destroy(gameObject);
    }
    
    protected override void OnDestroy()
    {
        entity.entitySkillClass.onProjectileDestroy?.Invoke(entity, this);
        attackerSkillClass.onProjectileDestroy?.Invoke(entity, this);
        base.OnDestroy();
    }
}



