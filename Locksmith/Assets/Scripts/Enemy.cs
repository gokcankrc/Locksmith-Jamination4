using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EntityBaseClass
{
    
    public EnemyShooterAI AI;
    protected override void Die()
    {
        EnemyDrop.I.DropOnDeath(transform);
        base.Die();
    }


    
    
    
}
