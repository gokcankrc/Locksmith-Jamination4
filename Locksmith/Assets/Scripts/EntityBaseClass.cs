using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkillHolder))]
public abstract class EntityBaseClass : MonoBehaviour
{
    // abstract
    
    // requires scripts/variables: Health, MovementBaseClass, Attack,
    protected int maxHealth;
    protected float health;
    protected float damage;
    protected float speed;

    private void Awake()
    {
        health = maxHealth;
    }

    //protected Skill[] skills;
    public float Speed
    {
        get { return speed;}
        set { speed = value; }
    }

    protected void DealDamage()
    {
        
    }

    protected void TakeDamage(float damageTaken)
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

