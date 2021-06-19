using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBaseClass : MonoBehaviour
{
    protected EntityBaseClass Entity;
    [SerializeField] protected PopUp popUp; 
    
    public int maxHealth;
    public float health;
    
    protected virtual void Awake()
    {
        Entity = GetComponent<EntityBaseClass>();
        health = maxHealth;
    }
    
    
    public virtual float TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        
        PopUpColorEnum popUpColor;
        if (Entity.AttackerClass.fromPlayer) popUpColor = PopUpColorEnum.EnemyHit;
        else popUpColor = PopUpColorEnum.FriendHit;
        var damageTakenInt = (int) damageTaken;
        var a =popUp.Create(transform.position, damageTakenInt.ToString(), popUpColor);
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
        PopUpColorEnum popUpColor;
        if (Entity.AttackerClass.fromPlayer) popUpColor = PopUpColorEnum.EnemyHeal;
        else popUpColor = PopUpColorEnum.FriendHeal;
        popUp.Create(transform.position,  healAmount.ToString(), popUpColor);
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        return health;
    }
}
