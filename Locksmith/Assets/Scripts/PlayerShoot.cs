using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : ShootBaseClass
{
    private GameObject _bullet;
    public override void Attack()
    {
        CreateBullet();
        
    }

    private void CreateBullet()
    {
        throw new System.NotImplementedException();
    }
}
