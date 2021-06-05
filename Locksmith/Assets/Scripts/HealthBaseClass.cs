using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBaseClass : MonoBehaviour
{
    protected EntityBaseClass Entity;
    
    public int maxHealth;
    public float health;

    void Awake()
    {
        health = maxHealth;
    }

    
    public virtual float TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        // we don't need to check if health is lower than 0 because EntityBaseClass does that.
        return health;
    }

    public virtual float Heal(float healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        return health;
    }
}
