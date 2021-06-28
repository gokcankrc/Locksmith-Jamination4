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

    public delegate void OnAttack(EntityBaseClass entity);
    public delegate void OnHit(EntityBaseClass entity, EntityBaseClass otherEntity);
    public delegate void OnProjectileDestroy(EntityBaseClass entity);
    public delegate void OnDamageTaken(EntityBaseClass entity, EntityBaseClass otherEntity);
    public delegate void OnDeath(EntityBaseClass entity);

    public OnAttack onAttack;
    public OnHit onHit;
    public OnProjectileDestroy onProjectileDestroy;
    public OnDamageTaken onDamageTaken;
    public OnDeath onDeath;

}


