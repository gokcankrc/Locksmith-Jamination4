using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject burningGround;

    [SerializeField] public ProjectileStats stats;
    [SerializeField] public Effects effects;
    
    private EntityBaseClass _collisionEntity;
    
    private void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        var vel = rb.velocity;
        rb.velocity=  vel.normalized * stats.Speed;
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision enter");
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        _collisionEntity = other.GetComponent<EntityBaseClass>();
        var Tag = other.tag;
        switch (Tag)
        {
            case Tags.ObstacleTag:
                OnObstacleCollision();
            break;
            case Tags.EnemyTag:
                OnEnemyCollision(other.GetComponent<EntityBaseClass>());
            break;
            case Tags.AllyTag:
                OnPlayerCollision(other.GetComponent<EntityBaseClass>());
            break;
        }
    }

    protected  void FixedUpdate()
    {
        stats.Duration -= Time.fixedDeltaTime;
        if (stats.Duration <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected abstract void OnPlayerCollision(EntityBaseClass otherEntity);
    protected abstract void OnEnemyCollision(EntityBaseClass otherEntity);
    protected abstract void OnObstacleCollision();


    protected void ApplyEffects(EntityBaseClass otherEntity)
    {
        if (effects.DealCollisionDamage)  DealDamage();
        if (effects.KnockBack) otherEntity.GetKnockedBack(this);
    }


    protected void OnDestroy()
    {

        if (effects.LeaveBurningGround) LeaveBurningGround();
        if (effects.Explosion) LeaveBurningGround();
    }

    // ----------------------------------------------------
    // These are all effects of some sorts
    // ----------------------------------------------------
    private void DealDamage() { _collisionEntity.healthClass.TakeDamage(stats.Damage); }
    private void LeaveBurningGround() { Instantiate(burningGround); }
}



