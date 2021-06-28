using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthBaseClass
{
    private EnemyAI _enemyAI;

    protected override void Awake()
    {
        base.Awake();
        _enemyAI = GetComponent<EnemyAI>();
    }
    public override float TakeDamage(float damageTaken, EntityBaseClass entity)
    {
        base.TakeDamage(damageTaken, entity);
        _enemyAI.ChangeState(EnemyAI.AIState.Idle, EnemyAI.AIState.Chasing);
        return health;
    }
}
