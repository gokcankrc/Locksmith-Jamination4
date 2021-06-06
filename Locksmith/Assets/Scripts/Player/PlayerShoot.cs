using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : ShootBaseClass
{
    public override void Attack(float direction)
    {
        CreateBullet(transform.position, direction);
    }
}
