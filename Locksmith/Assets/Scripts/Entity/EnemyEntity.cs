using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : EntityBaseClass
{
    [NonSerialized] public EnemyAI AI;

    protected override void Awake()
    {
        base.Awake();
        AI = GetComponent<EnemyAI>();
    }
    
    public override void Die()
    {
        
        EnemyDrop.I.DropOnDeath(transform);
        EnemyManager.I.RemoveSelf(gameObject);
        base.Die();
    }

}
