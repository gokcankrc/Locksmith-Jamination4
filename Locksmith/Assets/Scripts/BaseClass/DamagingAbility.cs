using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class DamagingAbility : MonoBehaviour
{
    [SerializeField] public Effects effects;
    [SerializeField] public Stats stats;
    [SerializeField] public bool FromPlayer;
    [SerializeField] public EntityBaseClass entity;

    [SerializeField] protected GameObject burningGround;
    [SerializeField] protected GameObject explosion;
    

    protected Vector2 effectDirection;
    public Vector3 pos => transform.position;
    
    public virtual Vector2 EffectDirection
    {
        get => effectDirection;
        set => effectDirection = value;
    }

    protected EntityBaseClass _collisionEntity;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Interract(other);
    }

    protected virtual void Interract(Collider2D other)
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

    protected virtual void OnPlayerCollision(EntityBaseClass otherEntity)
    {
        if (!FromPlayer)
        {
            ApplyHostileEffects(otherEntity.GetComponent<EntityBaseClass>());
        }       
        else
        {
            ApplyAllyEffects(otherEntity.GetComponent<EntityBaseClass>());
        }
    }

    protected virtual void OnEnemyCollision(EntityBaseClass otherEntity)
    {
        if (FromPlayer)
        {
            ApplyHostileEffects(otherEntity.GetComponent<EntityBaseClass>());
        }
        else
        {
            ApplyAllyEffects(otherEntity.GetComponent<EntityBaseClass>());
        }
    }

    protected virtual void OnObstacleCollision()
    {
        // Does not interract
    }


    protected void ApplyHostileEffects(EntityBaseClass otherEntity)
    {
        entity.AttackerClass.AttackhitInvoke();
        if (effects.DealCollisionDamage)  DealDamage();
        if (effects.KnockBack) otherEntity.GetKnockedBack(this);
        
    }

    protected void ApplyAllyEffects(EntityBaseClass otherEntity)
    {
        if (effects.Heal) Heal();
    }
    
    protected virtual void OnDestroy()
    {
        if (effects.LeaveBurningGround) LeaveBurningGround();
        if (effects.Explosion) Explode();
    }


    // ----------------------------------------------------
    // These are all effects of some sorts
    // ----------------------------------------------------
    
    protected abstract void DealDamage();
    protected abstract void Heal(); 

    protected virtual void LeaveBurningGround()
    {
        var burningGroundEffect = Instantiate(burningGround).GetComponent<DamagingPeriodicAoE>();
        AreaOfEffect.AOESync(burningGroundEffect, entity, transform.position, effects);
        // obsolete: burningGroundEffect.transform.Rotate(Vector3.back, Random.Range(0, 360));
    }
    
    protected virtual void Explode()
    {
        var explosionEffect = Instantiate(explosion).GetComponent<DamagingInstantAoE>();
        AreaOfEffect.AOESync(explosionEffect, entity, transform.position, effects);
    }
}
