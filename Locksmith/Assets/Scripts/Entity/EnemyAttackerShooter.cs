using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackerShooter : AttackerShooterBaseClass
{
    public override void Attack(float direction)
    {
        CreateBullet(transform.position, direction);
    }
}
