using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Projectile
{
    protected override void OnPlayerCollision(EntityBaseClass otherEntity)
    {
        // player takes damage
        ApplyEffects(otherEntity);
    }

    protected override void OnEnemyCollision(EntityBaseClass otherEntity)
    {
        // Does not interact
    }

    protected override void OnObstacleCollision()
    {
        Destroy(gameObject);
    }
}
