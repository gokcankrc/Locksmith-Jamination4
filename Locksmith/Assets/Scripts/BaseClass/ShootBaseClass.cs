using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootBaseClass : AttackBaseClass
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected ProjectileStats Stats;
    

    protected void Awake()
    {
        effects = new Effects(effects)
        {
            DealCollisionDamage = true, KnockBack = false, LeaveBurningGround = false,
            Explosion = false
        };
    }

    public override void Attack(float direction)
    {
        
    }

    // TODO; here probably doesn't work
    protected GameObject CreateBullet(Vector3 pos, float dir)
    {
        var newBulletGO = Instantiate(bulletPrefab);
        var bullet = newBulletGO.GetComponent<Projectile>();
        bullet.stats = new ProjectileStats(Stats);
        bullet.transform.position = pos;
        bullet.transform.rotation = Quaternion.AngleAxis(dir, Vector3.back);
        bullet.transform.localScale = new Vector3(Stats.Size, Stats.Size);
        bullet.effects = new Effects(effects);
        var bulletRB = newBulletGO.GetComponent<Rigidbody2D>();
        // There should be a better way to just shoot the damn thing in the direction we are facing
        bulletRB.velocity = Quaternion.AngleAxis(dir, Vector3.back) * Vector2.right * Stats.Speed;
        return newBulletGO;
    }
}


[Serializable]
public class ProjectileStats
{
    public ProjectileStats(ProjectileStats stats)
    {
        Damage = stats.Damage;
        Speed = stats.Speed;
        Size = stats.Size;
        Duration = stats.Duration;
    }
    
    public float Damage = 5;
    public float Speed = 3;
    public float Size = 2;
    public float Duration = 2.5f;
}


