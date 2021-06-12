using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : DamagingProjectileBaseClass
{
    protected override void OnPlayerCollision(EntityBaseClass otherEntity)
    {
        // default behavior: player gets affected
        base.OnPlayerCollision(otherEntity);
    }

    protected override void OnEnemyCollision(EntityBaseClass otherEntity)
    {
        // Does not interact
    }

    protected override void OnObstacleCollision()
    {
        base.OnObstacleCollision();
    }
}
