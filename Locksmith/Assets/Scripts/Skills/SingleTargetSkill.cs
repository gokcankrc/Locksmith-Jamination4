using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetSkill : Skill
{
    public override void OnHit(EntityBaseClass entity, EntityBaseClass otherEntity, DamagingAbility attacker)
    {
        base.OnHit(entity, otherEntity, attacker);
    }

    public override void OnDamageTaken(EntityBaseClass entity, EntityBaseClass otherEntity)
    {
        base.OnDamageTaken(entity, otherEntity);
    }

}
