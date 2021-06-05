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

    protected HealthBaseClass healthClass;
    protected MovementBaseClass moveClass;
    protected AttackBaseClass attackClass;
    protected bool dashing;

    private void Awake()
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

    public virtual void MoveTowards(Vector3 destination, float speedMultiplier)
    {
        moveClass.MoveTowards(destination, speedMultiplier);
    }

    public virtual void Attack(Vector3 targetPosition)
    {
        attackClass.Attack();
    }
    protected virtual void DealDamage()
    {
        
    }
    


    private void OnCollisionEnter(Collision other)
    {
        // if other is dangeous, take damage.
        // bu böyle yapılmayacak da şimdilik böyle dursun. belki buraya da koymayız.
        // burayı konsepti açıklaamsı için yazıyorum
        var attacker = other.gameObject.GetComponent<AttackBaseClass>();
        var remainingHealth = healthClass.TakeDamage(attacker.damage);
        if (attackClass.GetType() == Projectile)
        {
            attacker.Collide();
        }
        if (remainingHealth < 0)
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
        healthClass.Heal(healAmount);
    }
    
}

