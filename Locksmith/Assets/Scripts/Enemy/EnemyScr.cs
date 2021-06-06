using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : EntityBaseClass
{
    [NonSerialized] public EnemyAI AI;

    public void Awake()
    {
        AI = GetComponent<EnemyAI>();
    }
    
    public override void Die()
    {
        EnemyDrop.I.DropOnDeath(transform);
        base.Die();
    }

}
