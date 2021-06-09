﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBullet : ProjectileBaseClass
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
        Destroy(gameObject);
    }

    protected override void OnObstacleCollision()
    {
        Destroy(gameObject);
    }
}

