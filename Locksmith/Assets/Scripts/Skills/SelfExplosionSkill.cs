using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/SelfExplosion")]
public class SelfExplosionSkill : Skill
{
    public GameObject _explosion;

    protected override void ApplyEffects(EntityBaseClass entity, EntityBaseClass otherEntity, Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    protected override void ApplyEffects(EntityBaseClass entity, EntityBaseClass otherEntity)
    {
        throw new System.NotImplementedException();
    }

    protected override void ApplyEffects(EntityBaseClass entity)
    {
        var a = Instantiate(_explosion).GetComponent<DamagingAoE>();
        AoEEffectSync(a, entity);
    }

    public override void OnAttack(EntityBaseClass entity, AttackerBaseClass attackerBase, float direction)
    {
        base.OnAttack(entity, attackerBase, direction);
        Instantiate(_explosion, entity.transform.position, Quaternion.identity);
        foreach (var skill in entity.skills)
        {
            skill.OnHit();
        }
    }
    
    protected void AoEEffectSync(DamagingAbility Instance, EntityBaseClass entity)
    {
        // TODO; I'm kind of fucking this design up so refactor here at some point
        var attackerClass = entity.AttackerClass;
        Instance.transform.position = attackerClass.transform.position;
        Instance.effects = attackerClass.effects;
        Instance.effects.Explosion = false;
        Instance.effects.LeaveBurningGround = false;
        Instance.stats = new Stats(attackerClass.stats);
        Instance.FromPlayer = attackerClass.fromPlayer;
        Instance.sourceEntity = entity;
    }
}
