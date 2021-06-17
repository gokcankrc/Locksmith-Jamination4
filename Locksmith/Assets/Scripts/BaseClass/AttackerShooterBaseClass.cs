using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class AttackerShooterBaseClass : AttackerBaseClass
{
    [SerializeField] protected GameObject bulletPrefab;
    
    
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
        bullet.stats = new Stats(stats);
        bullet.FromPlayer = fromPlayer;
        
        // TODO; Could do this like var transform = bullet.transform
        var bulletTransform = bullet.transform;
        Transform transform1;
        (transform1 = bullet.transform).position = pos;
        transform1.rotation = Quaternion.AngleAxis(dir, Vector3.back);
        transform1.localScale = new Vector3(stats.ProjectileSize, stats.ProjectileSize);
        var bulletRB = newBulletGO.GetComponent<Rigidbody2D>();
        // There should be a better way to just shoot the damn thing in the direction we are facing
        bulletRB.velocity = Quaternion.AngleAxis(dir, Vector3.back) * Vector2.right * stats.ProjectileSpeed;
        return newBulletGO;
    }
}


[Serializable]
public class ProjectileStats_
{
    // this is not used anymore. holding temporarily for archiving and referencing purposes.

    public ProjectileStats_(ProjectileStats_ stats)
    
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

