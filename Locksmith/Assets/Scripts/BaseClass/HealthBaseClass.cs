using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBaseClass : MonoBehaviour
{
    protected EntityBaseClass Entity;
    [SerializeField] protected PopUp popUp; 
    
    public int maxHealth;
    [NonSerialized] public float health;

    void Awake()
    {
        health = maxHealth;
    }

    
    public virtual float TakeDamage(float damageTaken)
    {
        Debug.Log("1took dmf");
        health -= damageTaken;
        popUp.Create(transform.position,  damageTaken.ToString());
        
        // we don't need to check if health is lower than 0 because EntityBaseClass does that.
        return health;
    }

    public virtual float Heal(float healAmount)
    {
        popUp.Create(transform.position,  healAmount.ToString());
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        return health;
    }
}
