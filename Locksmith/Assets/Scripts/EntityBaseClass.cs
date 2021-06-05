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
    protected bool dashing;
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

