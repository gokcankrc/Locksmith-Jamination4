using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EntitySkills : MonoBehaviour
{
    
    [NonSerialized] public EntityBaseClass entity;
    [SerializeField] public List<Skill> skills;

    private void Awake()
    {
        entity = GetComponent<EntityBaseClass>();
        Initialize();

    }

    public void Initialize()
    {
        foreach (var skill in skills)
        {
            skill.Add(this);
            /*
            Debug.Log(skill.name);
            Debug.Log(skill.type);
            Debug.Log(skill.trigger);
            */
        }
    }

    public void AddSkill(Skill newSkill)
    {
        skills.Add(newSkill);
        newSkill.Add(this);
    }
    
    // Benefit of this: can easily create new triggers/events.
    // If they need different arguments, it does not create any problem.

    public delegate void OnAttack(EntityBaseClass entity, DamagingAbility attacker);
    public delegate void OnHit(EntityBaseClass entity, EntityBaseClass otherEntity, DamagingAbility attacker);
    public delegate void OnProjectileDestroy(EntityBaseClass entity, DamagingAbility projectile);
    public delegate void OnDamageTaken(EntityBaseClass entity, EntityBaseClass otherEntity);
    public delegate void OnDeath(EntityBaseClass entity);

    public OnAttack onAttack;
    public OnHit onHitEntitySide;
    public OnHit onHitAttackerSide;
    public OnProjectileDestroy onProjectileDestroy;
    public OnDamageTaken onDamageTaken;
    public OnDeath onDeath;

}


