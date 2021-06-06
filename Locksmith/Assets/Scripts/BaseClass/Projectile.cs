using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public ProjectileStats stats;
    public Effects effects;
    private EntityBaseClass _collisionEntity;

    [SerializeField] private GameObject burningGround;


    private void OnTriggerEnter(Collider other)
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
            case Tags.PlayerTag:
                OnPlayerCollision(other.GetComponent<EntityBaseClass>());
            break;
        }
    }

    protected abstract void OnPlayerCollision(EntityBaseClass otherEntity);
    protected abstract void OnEnemyCollision(EntityBaseClass otherEntity);
    protected abstract void OnObstacleCollision();


    protected void ApplyEffects(EntityBaseClass entity)
    {
        if (effects.DealCollisionDamage)  DealDamage();
        if (effects.KnockBack) KnockBack();
    }


    protected void OnDestroy()
    {
        if (effects.LeaveBurningGround) LeaveBurningGround();
    }

    // ----------------------------------------------------
    // These are all effects of some sorts
    // ----------------------------------------------------
    private void DealDamage() { _collisionEntity.healthClass.TakeDamage(stats.Damage); }
    private void KnockBack() { _collisionEntity.moveClass.KnockBack(); }
    private void LeaveBurningGround() { Instantiate(burningGround); }
}

public class Effects
{
    public bool DealCollisionDamage;
    public bool KnockBack;
    public bool LeaveBurningGround;
}

