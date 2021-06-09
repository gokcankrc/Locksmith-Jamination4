using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public virtual void OnAttack(EntityBaseClass entity, AttackBaseClass attackBase, float direction)
    {
        var skill = entity.skills;
        //DamagingAbility damaging= Instantiate(attackBase.);
        //damaging.effects;
    }

    public virtual void OnHit()
    {
        
    }

    public virtual void OnDamageTaken()
    {
        
    }

    public virtual bool OnDamageIncoming()
    {
        return true;
    }
}
