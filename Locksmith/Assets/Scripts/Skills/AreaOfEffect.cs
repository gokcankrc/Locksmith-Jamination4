using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect
{
    public static void AOESync(DamagingAbility instance, EntityBaseClass entity, Vector3 pos, Effects effects)
    {
        var attackerClass = entity.AttackerClass;
        instance.transform.position = pos;
        instance.effects = effects;
        instance.effects.Explosion = false;
        instance.effects.LeaveBurningGround = false;
        instance.stats = new Stats(attackerClass.stats);
        instance.FromPlayer = attackerClass.fromPlayer;
        instance.entity = entity;
    }
}
