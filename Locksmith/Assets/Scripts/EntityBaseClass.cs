using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkillHolder))]
[RequireComponent(typeof(AttackBaseClass))]
public abstract class EntityBaseClass : MonoBehaviour
{
    // abstract
    
    // requires scripts/variables: Health, MovementBaseClass, Attack,
    protected int maxHealth;
    protected float health;
    protected float damage;
    protected float speed;
    protected AttackBaseClass attack;
    protected bool dashing;

    private void Awake()
    {
        health = maxHealth;
        attack = GetComponent<AttackBaseClass>();
    }

    //protected Skill[] skills;
    public float Speed
    {
        get { return speed;}
        set { speed = value; }
    }
    public bool Dashing
    {
        get { return dashing; }
        set { dashing = value; }
    }


    protected virtual void Attack()
    {
        attack.Attack();
    }
    protected virtual void DealDamage()
    {
        
    }

    protected virtual void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (health < 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected void Heal(float healAmount)
    {
        health += healAmount;
    }
    
}

