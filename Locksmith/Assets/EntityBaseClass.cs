﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityBaseClass : MonoBehaviour
{
    // abstract
    
    // requires scripts/variables: Health, MovementBaseClass, Attack,
    protected int maxHealth;
    protected float health;
    protected float damage;
    protected float speed;
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

    protected void Die()
    {
        GameObject.Destroy(gameObject);
    }

    protected void Heal(float healAmount)
    {
        health += healAmount;
    }
    
}