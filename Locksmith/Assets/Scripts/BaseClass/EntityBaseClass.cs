using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBaseClass))]
[RequireComponent(typeof(MovementBaseClass))]
[RequireComponent(typeof(AttackerBaseClass))]
public abstract class EntityBaseClass : MonoBehaviour
{
    // abstract
    
    // requires scripts/variables: Health, MovementBaseClass, Attack,

    [NonSerialized] public HealthBaseClass healthClass;
    [NonSerialized] public MovementBaseClass moveClass;
    [NonSerialized] public AttackerBaseClass AttackerClass;
    protected bool dashing;
    protected bool pushing;
    public Skill[] skills;

    private void Start()
    {
        healthClass = GetComponent<HealthBaseClass>();
        moveClass = GetComponent<MovementBaseClass>();
        AttackerClass = GetComponent<AttackerBaseClass>();
        //GateManager.
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
        AttackerClass.Attack(direction);
        
        // under construction code
        /*
        foreach (Skill skill in skills)
        {
            skill.OnAttack(this, AttackerClass, direction);
        }
        */
        
        
    }
    
    public virtual void TakeDamage(float damage)
    {
        healthClass.TakeDamage(damage);
    }
    
    public virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void Heal(float healAmount)
    {
        healthClass.Heal(healAmount);
    }

    protected void OnBulletExpire()
    {
        
    }

    public void ToggleSkill(Effects skillAdd)
    {
        var _skill = new Effects(AttackerClass.effects);
        for (int i = 0; i < skillAdd.list.Length; i++)
        {
            Debug.Log(skillAdd.list[i]);
            Debug.Log(i);
            // If true, toggle the skill
            if (skillAdd.list[i])
            {
                Debug.Log(_skill.list[i]);
                _skill.list[i] = !_skill.list[i];
                Debug.Log(_skill.list[i]);
            }
        }

        AttackerClass.effects.list = _skill.list;
    }
    
    public void ToggleSkill(Effects.EffectsEnum skillAdd)
    {
        var buffer = new Effects();
        buffer.list[skillAdd.GetHashCode()] = true;
        ToggleSkill(buffer);
    }

    public void GetKnockedBack(DamagingAbility damaging)
    {
        var a = GetComponent<KnockBack>();
        a.Damaging = damaging;
        a.UseSkill();
        
    }

    public void GetGateStats(gateStats gateStats)
    {
        
    }
}

