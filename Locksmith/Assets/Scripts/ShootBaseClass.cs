using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootBaseClass : AttackBaseClass
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected BulletStats Stats;
    
    public override void Attack()
    {
        
    }

    protected void CreateBullet(Vector3 pos, Quaternion dir, BulletStats stats)
    {
        Instantiate(bulletPrefab);
        var bullet = bulletPrefab.GetComponent<Bullet>();
        bullet.Stats = stats;
        bullet.transform.position = pos;
        bullet.transform.rotation = dir;
    }
}


[Serializable]
public class BulletStats
{
    public float Damage = 5;
    public float Speed = 3;
    public float Size = 2;
}
