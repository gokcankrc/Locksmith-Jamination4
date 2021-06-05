using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootBaseClass : AttackBaseClass
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected ProjectileStats Stats;
    
    public override void Attack()
    {
        
    }

    // TODO; here probably doesn't work
    protected void CreateBullet(Vector3 pos, Quaternion dir, ProjectileStats stats)
    {
        Instantiate(bulletPrefab);
        var bullet = bulletPrefab.GetComponent<Projectile>();
        bullet.Stats = stats;
        bullet.transform.position = pos;
        bullet.transform.rotation = dir;
    }
}


[Serializable]
public class ProjectileStats
{
    public float Damage = 5;
    public float Speed = 3;
    public float Size = 2;
}
