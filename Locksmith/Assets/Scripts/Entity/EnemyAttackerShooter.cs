using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackerShooter : AttackerShooterBaseClass
{
    public override void Attack(float direction)
    {
        var a = CreateBullet(transform.position, direction);
        entity.entitySkillClass.onAttack?.Invoke(entity, a.GetComponent<DamagingAbility>());
    }
}
