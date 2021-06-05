using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : ShootBaseClass
{
    public override void Attack()
    {
        CreateBullet(transform.position, transform.rotation, Stats);
    }
}
