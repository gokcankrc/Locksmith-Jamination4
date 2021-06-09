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
        Entity = GetComponent<EntityBaseClass>();
        health = maxHealth;
    }

    
    public virtual float TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        var a =popUp.Create(transform.position,  damageTaken.ToString());
        a.transform.position += Vector3.back * 10;
        
        //under construction
        foreach (var skill in Entity.skills)
        {
            skill.OnDamageTaken();
        }
        
        
        if (health <= 0) Entity.Die();       
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
