using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/SelfExplosion")]
public class SelfExplosionSkill : Skill
{
    public GameObject _explosion;
    
    public override void OnAttack(EntityBaseClass entity, AttackBaseClass attackBase, float direction)
    {
        base.OnAttack(entity, attackBase, direction);
        Instantiate(_explosion, entity.transform.position, quaternion.identity);
        foreach (var skill in entity.skills)
        {
            skill.OnHit();
        }
    }
}
