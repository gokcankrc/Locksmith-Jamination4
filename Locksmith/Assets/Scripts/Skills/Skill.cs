using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [SerializeField] protected TriggerEnum trigger;
    [SerializeField] protected SkillType type;
    [SerializeField] protected List<Skill> childrenSkills;

    
    public virtual void Add(EntitySkills entitySkills)
    {
        switch (trigger)
        {
            case TriggerEnum.OnAttack:
                entitySkills.onAttack += OnAttack;
                break;
            case TriggerEnum.OnDeath:
                entitySkills.onDeath += OnDeath;
                break;
            case TriggerEnum.OnHit:
                entitySkills.onHit += OnHit;
                break;
            case TriggerEnum.OnDamageTaken:
                entitySkills.onDamageTaken += OnDamageTaken;
                break;
            case TriggerEnum.OnProjectileDestroy:
                entitySkills.onProjectileDestroy += OnProjectileDestroy;
                break;
        }
    }
    
    // TODO; Is there any way to not make this copy_paste like this?
    
    public virtual void OnAttack(EntityBaseClass entity)
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnDeath(EntityBaseClass entity)
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnHit(EntityBaseClass entity, EntityBaseClass otherentity, Vector2 direction)
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnDamageTaken(EntityBaseClass entity, EntityBaseClass otherentity)
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnProjectileDestroy(EntityBaseClass entity, DamagingAbility projectile)
    {
        throw new System.NotImplementedException();
    }



    // Many versions of apply effects because some triggers have different types.
    // Could easily change the naming to stuff like "onAttack()" to make it more readable.

    /*
    protected virtual void ApplyEffects(EntityBaseClass entity, EntityBaseClass otherEntity, Vector2 direction)
    {
        throw new System.NotImplementedException();
    }
    
    protected virtual void ApplyEffects(EntityBaseClass entity, EntityBaseClass otherEntity)
    {
        throw new System.NotImplementedException();
    }
    
    protected virtual void ApplyEffects(EntityBaseClass entity)
    {
        throw new System.NotImplementedException();
    }

    protected virtual void ApplyEffects(EntityBaseClass entity, DamagingAbility ability)
    {
    }
    */

    public virtual bool OnDamageIncoming()
    {
        throw new System.NotImplementedException();
    }
}

public enum TriggerEnum
{
    OnAttack, OnHit, OnProjectileDestroy, OnDamageTaken, OnDeath
}

public enum SkillType
{
    Summon, ProjectileBehavior, LeaveAoE, SingleTarget, None
}