using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetSkill : Skill
{



    public override void OnHit(EntityBaseClass entity, EntityBaseClass otherentity, DamagingAbility attacker)
    {
        
        
        var damagingAOE = Instantiate().GetComponent<DamagingAoE>();
        Vector3 pos = otherentity.transform.position;
        AreaOfEffect.AOESync(damagingAOE, entity, pos, entity.AttackerClass.effects);

    }

    public override void OnDamageTaken(EntityBaseClass entity, EntityBaseClass otherentity)
    {
        base.OnDamageTaken(entity, otherentity);
    }

}
