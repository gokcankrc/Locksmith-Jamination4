using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Zap Skill")]
public class ZapSkill : SingleTargetSkill
{
    [SerializeField] private int ZapAmount = 1;
    [SerializeField] private int ZapRange = 1;
    [SerializeField] private GameObject particleEffect;

    // cant do this
    // private int ZapRangeSqr = ZapRange * ZapRange;

    public override void OnHit(EntityBaseClass entity, EntityBaseClass otherEntity, DamagingAbility attacker)
    {
        var enemiesToEffect = AreaOfEffect.FindClosestUniques(attacker.transform.position, EnemyManager.I.CurrentEnemyPositions.ToList(), ZapAmount);
        var enemyEntities = new List<EntityBaseClass>(enemiesToEffect.Count);
        foreach (var enemyGO in enemiesToEffect)
        {
            Debug.Log("asdfasd");
            Debug.Log(enemyGO);
            enemyEntities.Add(enemyGO.GetComponent<EntityBaseClass>());
        }


        var currentPos = otherEntity.transform.position;
        foreach (var enemyEntity in enemyEntities)
        {
            if ((ZapRange * ZapRange) < (currentPos - enemyEntity.transform.position).sqrMagnitude) continue;
            //TODO; create particle effect
            Instantiate(particleEffect, enemyEntity.transform.position + Vector3.back * 3, Quaternion.identity);
            enemyEntity.healthClass.TakeDamage(entity.attackerClass.stats.Damage * stats.Damage, entity);
        }
    }
}
