using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [SerializeField] protected TriggerEnum trigger;
    [SerializeField] protected  SkillType type;
    [SerializeField] protected List<Skill> childrenSkills;
    [SerializeField] public bool FromPlayer;

    
    public virtual void Add(EntitySkills entitySkills)
    {
        switch (trigger)
        {
            case TriggerEnum.OnAttack:
                entitySkills.onAttack += ApplyEffects;
                break;
            case TriggerEnum.OnDeath:
                entitySkills.onDeath += ApplyEffects;
                break;
            case TriggerEnum.OnHit:
                entitySkills.onHit += ApplyEffects;
                break;
            case TriggerEnum.OnDamageTaken:
                entitySkills.onDamageTaken += ApplyEffects;
                break;
            case TriggerEnum.OnProjectileDestroy:
                entitySkills.onProjectileDestroy += ApplyEffects;
                break;
        }
    }
    
    // Many versions of apply effects because some triggers have different types.
    // Could easily change the naming to stuff like "onAttack()" to make it more readable.

    protected abstract void ApplyEffects(EntityBaseClass entity, EntityBaseClass otherEntity, Vector2 direction);
    protected abstract void ApplyEffects(EntityBaseClass entity, EntityBaseClass otherEntity);
    protected abstract void ApplyEffects(EntityBaseClass entity);

    
    public virtual void OnAttack(EntityBaseClass entity, AttackerBaseClass attackerBase, float direction)
    {
        var skill = entity.skills;
        //DamagingAbility damaging= Instantiate(attackBase.);
        //damaging.effects;
    }

    public virtual void OnHit()
    {
        
    }

    public virtual void OnDamageTaken()
    {
        
    }

    public virtual bool OnDamageIncoming()
    {
        return true;
    }
}

public enum TriggerEnum
{
    OnAttack, OnHit, OnProjectileDestroy, OnDamageTaken, OnDeath
}

public enum SkillType
{
    Summon, ProjectileBehavior, LeaveAoE, SingleTarger
}