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
    
    protected float outOfCombatDuration;
    
    // "damaged" is true if we lost health, and false if we got healed.
    public delegate void OnHealthChange(float health, float maxHealth, bool damaged);
    public event OnHealthChange onHealthChange;
    
    protected virtual void Awake()
    {
        entity = GetComponent<EntityBaseClass>();
        health = maxHealth;
        outOfCombatDuration = 0;
    }

    protected virtual void Start()
    {
        entity.entitySkillClass.onHitEntitySide += OnAttackhit;
    }

    protected virtual void FixedUpdate()
    {
        outOfCombatDuration += Time.fixedDeltaTime;
    }

    protected virtual void OnAttackhit(EntityBaseClass thisEntity, EntityBaseClass otherEntity, DamagingAbility attacker)
    {
        outOfCombatDuration = 0;
    }


    public virtual float TakeDamage(float damageTaken, EntityBaseClass otherEntity)
    {
        health -= damageTaken;
        
        onHealthChange?.Invoke(health, maxHealth, true);
        
        PopUpColorEnum popUpColor;
        popUpColor = entity.attackerClass.fromPlayer ? PopUpColorEnum.FriendHit : PopUpColorEnum.EnemyHit;
        var damageTakenInt = (int) damageTaken;
        var a = popUp.Create(transform.position, damageTakenInt.ToString(), popUpColor);
        a.transform.position += Vector3.back * 10;

        outOfCombatDuration = 0;
        

        entity.entitySkillClass.onDamageTaken?.Invoke(entity, otherEntity);

        if (health <= 0) entity.Die();
        return health;
    }

    public virtual float Heal(float healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        
        onHealthChange?.Invoke(health, maxHealth, false);
        
        PopUpColorEnum popUpColor;
        popUpColor = entity.attackerClass.fromPlayer ? PopUpColorEnum.EnemyHeal : PopUpColorEnum.FriendHeal;
        popUp.Create(transform.position,  healAmount.ToString(), popUpColor);
        
        return health;
    }
}
