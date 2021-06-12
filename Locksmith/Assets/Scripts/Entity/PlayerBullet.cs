using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBullet : DamagingProjectileBaseClass
{
    protected override void OnPlayerCollision(EntityBaseClass otherEntity)
    {
        // Does not interact
    }

    protected override void OnEnemyCollision(EntityBaseClass otherEntity)
    {
        // default behavior: enemy gets affected
        base.OnEnemyCollision(otherEntity);
    }

    protected override void OnObstacleCollision()
    {
        base.OnObstacleCollision();
    }
}

