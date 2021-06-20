using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBaseClass : MonoBehaviour
{
    [SerializeField] protected PopUp popUp;
    [SerializeField] protected EntityBaseClass entity;
    
    public int maxHealth;
    public float health;
    
    [SerializeField]protected float outOfCombatDuration;
    
    protected virtual void Awake()
    {
        entity = GetComponent<EntityBaseClass>();
        health = maxHealth;
        outOfCombatDuration = 0;
    }

    protected virtual void Start()
    {
        entity.AttackerClass.attackhit += OnAttackhit;
    }

    protected virtual void FixedUpdate()
    {
        outOfCombatDuration += Time.fixedDeltaTime;
    }

    protected virtual void OnAttackhit()
    {
        outOfCombatDuration = 0;
    }


    public virtual float TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        
        PopUpColorEnum popUpColor;
        if (entity.AttackerClass.fromPlayer) popUpColor = PopUpColorEnum.EnemyHit;
        else popUpColor = PopUpColorEnum.FriendHit;
        var damageTakenInt = (int) damageTaken;
        var a =popUp.Create(transform.position, damageTakenInt.ToString(), popUpColor);
        a.transform.position += Vector3.back * 10;

        outOfCombatDuration = 0;
        
        //under construction
        foreach (var skill in entity.skills)
        {
            skill.OnDamageTaken();
        }
        
        if (health <= 0) entity.Die();
        return health;
    }

    public virtual float Heal(float healAmount)
    {
        PopUpColorEnum popUpColor;
        if (entity.AttackerClass.fromPlayer) popUpColor = PopUpColorEnum.EnemyHeal;
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
