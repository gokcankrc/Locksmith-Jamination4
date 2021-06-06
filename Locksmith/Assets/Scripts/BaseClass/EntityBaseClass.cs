using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBaseClass))]
[RequireComponent(typeof(MovementBaseClass))]
[RequireComponent(typeof(AttackBaseClass))]
public abstract class EntityBaseClass : MonoBehaviour
{
    // abstract
    
    // requires scripts/variables: Health, MovementBaseClass, Attack,

    [NonSerialized] public HealthBaseClass healthClass;
    [NonSerialized] public MovementBaseClass moveClass;
    [NonSerialized] public AttackBaseClass attackClass;
    protected bool dashing;
    protected bool pushing;

    private void Start()
    {
        healthClass = GetComponent<HealthBaseClass>();
        moveClass = GetComponent<MovementBaseClass>();
        attackClass = GetComponent<AttackBaseClass>();
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
        attackClass.Attack(direction);
    }
    
    public virtual void TakeDamage(float damage)
    {
        healthClass.TakeDamage(damage);
    }
    
    public virtual void Die()
    {
        Destroy(gameObject);
    }

    protected void Heal(float healAmount)
    {
        healthClass.Heal(healAmount);
    }

    public void ToggleSkill(Effects skill)
    {
        foreach (var VARIABLE in attackClass.effects.list)
        {
            
        }
        attackClass.effects.KnockBack = true;
        
        var _skill = new Effects(attackClass.effects);
        for (int i = 0; i < skill.list.Length; i++)
        {
            Debug.Log("aa");
            Debug.Log(i);
            if (skill.list[i])
            {
                _skill.list[i] = !_skill.list[i];
            }
        }

        attackClass.effects = _skill;
    }

    public void GetKnockedBack(Projectile bullet)
    {
        var a = GetComponent<BulletPush>();
        a.bullet = bullet;
        a.UseSkill();
        
    }
}

