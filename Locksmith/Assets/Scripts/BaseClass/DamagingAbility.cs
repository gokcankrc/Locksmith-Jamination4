using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

    
[RequireComponent(typeof(EntitySkills))]
public abstract class DamagingAbility : MonoBehaviour
{
    
    [SerializeField] public Effects effects;
    [SerializeField] public Stats stats;
    [SerializeField] public bool FromPlayer;
    [SerializeField] public EntityBaseClass entity;
    [SerializeField] public EntitySkills entitySkillClass;
    [SerializeField] public EntitySkills attackerSkillClass;

    public List<Skill> Skills
    {
        get => attackerSkillClass.skills;
        set => attackerSkillClass.skills = value;
    }

    [SerializeField] protected GameObject burningGround;
    [SerializeField] protected GameObject explosion;
    
    // Do I really have to do this public? Really?
    public float skillDurationMultiplayer = 1;
    public float skillDamageMultiplayer = 1;

    protected Vector2 effectDirection;
    public Vector3 pos => transform.position;

    private void Awake()
    {
        attackerSkillClass = GetComponent<EntitySkills>();
    }

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
                OnEnemyCollision(_collisionEntity);
                break;
            case Tags.AllyTag:
                OnPlayerCollision(_collisionEntity);
                break;
        }
    }

    protected virtual void OnPlayerCollision(EntityBaseClass otherEntity)
    {
        if (!FromPlayer)
        {
            attackerSkillClass.onHitAttackerSide?.Invoke(entity, otherEntity, this);
            entitySkillClass.onHitEntitySide?.Invoke(entity, otherEntity, this);
            ApplyHostileEffects(otherEntity);
        }       
        else
        {
            ApplyAllyEffects(otherEntity);
        }
    }

    protected virtual void OnEnemyCollision(EntityBaseClass otherEntity)
    {
        if (FromPlayer)
        {
            attackerSkillClass.onHitAttackerSide?.Invoke(entity, otherEntity, this);
            entitySkillClass.onHitEntitySide?.Invoke(entity, otherEntity, this);
            ApplyHostileEffects(otherEntity);
        }
        else
        {
            ApplyAllyEffects(otherEntity);
        }
    }

    protected virtual void OnObstacleCollision()
    {
        // Does not interract
    }


    protected void ApplyHostileEffects(EntityBaseClass otherEntity)
    {
        if (effects.DealCollisionDamage)
        {
            otherEntity.healthClass.TakeDamage(stats.Damage * skillDamageMultiplayer, entity);
        }
        
        if (effects.KnockBack) otherEntity.GetKnockedBack(this);
    }

    protected void ApplyAllyEffects(EntityBaseClass otherEntity)
    {
        if (effects.Heal) otherEntity.Heal(stats.HealAmount);
    }
    
    protected virtual void OnDestroy()
    {
        if (effects.LeaveBurningGround) LeaveBurningGround();
        if (effects.Explosion) Explode();
    }


    // ----------------------------------------------------
    // These are all effects of some sorts
    // ----------------------------------------------------


    protected virtual void LeaveBurningGround()
    {
        var burningGroundEffect = Instantiate(burningGround).GetComponent<DamagingPeriodicAoE>();
        AreaOfEffect.AOESync(burningGroundEffect, entity, transform.position, effects, Skills);
        // obsolete: burningGroundEffect.transform.Rotate(Vector3.back, Random.Range(0, 360));
    }
    
    protected virtual void Explode()
    {
        var explosionEffect = Instantiate(explosion).GetComponent<DamagingInstantAoE>();
        AreaOfEffect.AOESync(explosionEffect, entity, transform.position, effects, Skills);
    }
}
