using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class AttackerShooterBaseClass : AttackerBaseClass
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected ProjectileStats Stats;
    
    
    /* No need
    protected void Awake()
    {
        effects = new Effects(effects)
        {
            DealCollisionDamage = true, KnockBack = false, LeaveBurningGround = false,
            Explosion = false
        };
    }
    */

    protected GameObject CreateBullet(Vector3 pos, float dir)
    {
        var newBulletGO = Instantiate(bulletPrefab);
        var bullet = newBulletGO.GetComponent<DamagingProjectileBaseClass>();
        bullet.effects = new Effects(effects);
        bullet.areaOfEffectStats = new AreaOfEffectStats(areaOfEffectStats);
        bullet.projectileStats = new ProjectileStats(Stats);
        bullet.FromPlayer = fromPlayer;
        
        // TODO; Could do this like var transform = bullet.transform
        var bulletTransform = bullet.transform;
        Transform transform1;
        (transform1 = bullet.transform).position = pos;
        transform1.rotation = Quaternion.AngleAxis(dir, Vector3.back);
        transform1.localScale = new Vector3(Stats.Size, Stats.Size);
        var bulletRB = newBulletGO.GetComponent<Rigidbody2D>();
        // There should be a better way to just shoot the damn thing in the direction we are facing
        bulletRB.velocity = Quaternion.AngleAxis(dir, Vector3.back) * Vector2.right * Stats.Speed;
        return newBulletGO;
    }
}


[Serializable]
public class ProjectileStats
{
    // TODO; make "size" more intuitive, such as "range"

    public ProjectileStats(ProjectileStats stats)
    {
        Damage = stats.Damage;
        Speed = stats.Speed;
        Size = stats.Size;
        Duration = stats.Duration;
        Pierce = stats.Pierce;
    }
    
    public float Damage = 5;
    public float Speed = 3;
    public float Size = 2;
    public float Duration = 2.5f;
    public int Pierce = 0;
}


[Serializable]
public class AreaOfEffectStats
{
    // TODO; make "size" more intuitive, such as "range"

    public AreaOfEffectStats(AreaOfEffectStats stats)
    {
        Damage = stats.Damage;
        Size = stats.Size;
        Duration = stats.Duration;
    }

    public AreaOfEffectStats(float damage,float size,float duration)
    {
        Damage = damage;
        Size = size;
        Duration = duration;
    }
    
    public float Damage = 5;
    public float Size = 1;
    public float Duration = 1f;
}


