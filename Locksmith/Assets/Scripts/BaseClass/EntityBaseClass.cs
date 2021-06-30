using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBaseClass))]
[RequireComponent(typeof(MovementBaseClass))]
[RequireComponent(typeof(AttackerBaseClass))]
[RequireComponent(typeof(EntitySkills))]

public abstract class EntityBaseClass : MonoBehaviour
{
    // abstract
    
    // requires scripts/variables: Health, MovementBaseClass, Attack,

    public HealthBaseClass healthClass;
    public MovementBaseClass moveClass;
    public AttackerBaseClass attackerClass;
    public EntitySkills entitySkillClass;
    private EntityBaseClass Entity => this;
    protected bool dashing;
    protected bool pushing;
    public List<Skill> skills;
    public EntityType type;

    public enum EntityType
    {
        Player, EnemyShooter
    }
    
    protected virtual void Awake()
    {
        GetReferences();
    }

    public void GetReferences()
    {
        if (attackerClass != null) 
        {
            Debug.Log("references already gathered");
            return;
        }
        healthClass = GetComponent<HealthBaseClass>();
        moveClass = GetComponent<MovementBaseClass>();
        attackerClass = GetComponent<AttackerBaseClass>();
        entitySkillClass = GetComponent<EntitySkills>();
    }

    public bool Dashing
    {
        get => dashing;
        set => dashing = value;
    }

    public bool Pushing
    {
        get => pushing;
        set => pushing = value;
    }

    public virtual void MoveTowards(Vector3 destination, float speedMultiplier=1f)
    {
        if (moveClass == null) return;
        moveClass.MoveTowards(destination, speedMultiplier);
    }

    public virtual void Attack(float direction)
    {

        attackerClass.Attack(direction);
        
        // under construction code
        /*
        foreach (Skill skill in skills)
        {
            skill.OnAttack(this, AttackerClass, direction);
        }
        */
        
        
    }

    public virtual void CreatedEntity()
    {
        // When an entity is created, it looks at current active gates and changes stats if necessary.
        
    }
    
    public virtual void TakeDamage(float damage, EntityBaseClass otherEntity)
    {
        healthClass.TakeDamage(damage, otherEntity);
    }
    
    public virtual void Die()
    {
        entitySkillClass.onDeath?.Invoke(this);
        Destroy(gameObject);
    }

    public virtual void Heal(float healAmount)
    {
        healthClass.Heal(healAmount);
    }

    protected void OnBulletExpire()
    {
        
    }

    public void ToggleSkill(Effects skillAdd)
    {
        var _skill = new Effects(attackerClass.effects);
        for (int i = 0; i < skillAdd.list.Length; i++)
        {
            // If true, toggle the skill
            if (skillAdd.list[i])
            {
                _skill.list[i] = !_skill.list[i];
            }
        }

        attackerClass.effects.list = _skill.list;
    }
    
    public void ToggleSkill(Effects.EffectsEnum skillAdd)
    {
        var buffer = new Effects();
        buffer.list[skillAdd.GetHashCode()] = true;
        ToggleSkill(buffer);
    }

    public void GetKnockedBack(DamagingAbility damaging)
    {
        GetComponent<KnockBack>().UseSkill(damaging);
    }

    public void GetGateStats(GateStats gateStats)
    {
        attackerClass.stats.Damage += gateStats.damageAdd;
        attackerClass.stats.AreaDuration += gateStats.durationAdd;
        healthClass.maxHealth += gateStats.maxHealthAdd;
    }
}

