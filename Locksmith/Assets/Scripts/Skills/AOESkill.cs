using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/AOESkill")]
public class AOESkill : Skill
{
    public GameObject aoePrefab;
    
    // How can i check/force type to be LeavAoE?
    
    public override void OnAttack(EntityBaseClass entity, DamagingAbility attacker)
    {
        //TODO; Refactor here
        // In this mode, effect happens at the location of the character.
        // trigger == TriggerEnum.OnAttack;
        var damagingAOE = Instantiate(aoePrefab).GetComponent<DamagingAoE>();
        Vector3 pos = entity.transform.position;
        AreaOfEffect.AOESync(damagingAOE, entity, pos, entity.AttackerClass.effects);
    }

    public override void OnProjectileDestroy(EntityBaseClass entity, DamagingAbility projectile)
    {
        // In this mode, effect happens at the location of projectile
        // trigger == TriggerEnum.OnProjectileDestroy;
        var damagingAOE = Instantiate(aoePrefab).GetComponent<DamagingAoE>();
        Vector3 pos = projectile.pos;
        AreaOfEffect.AOESync(damagingAOE, entity, pos, entity.AttackerClass.effects);
    }

    public override void OnHit(EntityBaseClass entity, EntityBaseClass otherentity, DamagingAbility attacker)
    {
        var damagingAOE = Instantiate(aoePrefab).GetComponent<DamagingAoE>();
        Vector3 pos = otherentity.transform.position;
        AreaOfEffect.AOESync(damagingAOE, entity, pos, entity.AttackerClass.effects);

    }

    public override void OnDeath(EntityBaseClass entity)
    {
        var damagingAOE = Instantiate(aoePrefab).GetComponent<DamagingAoE>();
        Vector3 pos = entity.transform.position;
        AreaOfEffect.AOESync(damagingAOE, entity, pos, entity.AttackerClass.effects);
    }
}
