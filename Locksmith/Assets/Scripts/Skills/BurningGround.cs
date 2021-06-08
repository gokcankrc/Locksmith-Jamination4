using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningGround : DamagingAbility
{
    [SerializeField] public float Damage;
    [SerializeField] public float expireTime;
    [SerializeField] public float Damage2;
    [SerializeField] public BurningGroundStats stats;

    [SerializeField] public bool FromPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnPlayerCollision(EntityBaseClass otherEntity)
    {
        if (!FromPlayer)
        {
            ApplyEffects(otherEntity.GetComponent<EntityBaseClass>());
        }
    }

    protected override void OnEnemyCollision(EntityBaseClass otherEntity)
    {
        if (FromPlayer)
        {
            ApplyEffects(otherEntity.GetComponent<EntityBaseClass>());
        }
    }

    protected override void OnObstacleCollision()
    {
        // Does not interract
    }

    protected override void DealDamage() { _collisionEntity.healthClass.TakeDamage(burningGroundStats.Damage); }

}
