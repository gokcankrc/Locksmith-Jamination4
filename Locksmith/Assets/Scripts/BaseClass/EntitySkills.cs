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
        foreach (var skill in skills)
        {
            skill.Add(this);
        }
    }

    public void AddSkill(Skill newSkill)
    {
        skills.Add(newSkill);
        newSkill.Add(this);
    }
    
    // Benefit of this: can easily create new triggers/events.
    // If they need different arguments, it does not create any problem.

    public delegate void OnAttack(EntityBaseClass entity);
    public delegate void OnHit(EntityBaseClass entity, EntityBaseClass otherEntity, Vector2 direction);
    public delegate void OnProjectileDestroy(EntityBaseClass entity, DamagingAbility projectile);
    public delegate void OnDamageTaken(EntityBaseClass entity, EntityBaseClass otherEntity);
    public delegate void OnDeath(EntityBaseClass entity);

    public OnAttack onAttack;
    public OnHit onHit;
    public OnProjectileDestroy onProjectileDestroy;
    public OnDamageTaken onDamageTaken;
    public OnDeath onDeath;

}


