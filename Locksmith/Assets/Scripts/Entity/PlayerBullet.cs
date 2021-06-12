using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBullet : DamagingProjectileBaseClass
{
    protected override void OnPlayerCollision(EntityBaseClass otherEntity)
    {
        // Does not interact
        return;
    }

    protected override void OnEnemyCollision(EntityBaseClass otherEntity)
    {
        // Enemy takes damage
        ApplyEffects(otherEntity.GetComponent<EntityBaseClass>());
        Debug.Log("destroyed due to collision");
        Destroy(gameObject);
    }

    protected override void OnObstacleCollision()
    {
        Destroy(gameObject);
    }
}

