using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamagingAoE : DamagingAbility
{
    // Make this scriptable object so that mthrfkn all area of effects won't require a new script
    // Maybe not. If we make weird area of effects, we will need many behaviors in here. Maybe that's ok. 
    
    [SerializeField] protected float expireTime;

    public override Vector2 EffectDirection
    {
        get =>_collisionEntity.transform.position - transform.position;
        set => effectDirection = value;
    }
    
    protected virtual void Start()
    {
        expireTime = stats.AreaDuration * skillDurationMultiplayer;
            
        /*
        foreach (var enemyGO in EnemySpawner.I.CurrentlyActiveEnemies)
        {
            var enemyPos = enemyGO.transform.position;
            var pos = transform.position;
            var dist = enemyPos - pos;
            if ( CloseEnough(enemyGO.transform.position, alertDistance))
                // if (enemyGO && CloseEnough(enemyGO.transform.position, alertDistance))
            {
                enemyGO.GetComponent<EnemyScr>().AI.Alert();
            }
        }
        */
    }
    

    protected virtual void FixedUpdate()
    {
        expireTime -= Time.fixedDeltaTime;
        if (expireTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
