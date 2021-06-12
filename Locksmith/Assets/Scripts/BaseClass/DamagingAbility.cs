using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamagingAbility : MonoBehaviour
{
    [SerializeField] private GameObject burningGround;
    [SerializeField] private GameObject explosion;
    [SerializeField] public Effects effects;
    [SerializeField] public BurningGroundStats burningGroundStats;
    
    protected EntityBaseClass _collisionEntity;
    
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        _collisionEntity = other.GetComponent<EntityBaseClass>();
        var Tag = other.tag;
        switch (Tag)
        {
            case Tags.ObstacleTag:
                OnObstacleCollision();
            break;
            case Tags.EnemyTag:
                OnEnemyCollision(other.GetComponent<EntityBaseClass>());
            break;
            case Tags.AllyTag:
                OnPlayerCollision(other.GetComponent<EntityBaseClass>());
            break;
        }
    }
    
    protected abstract void OnPlayerCollision(EntityBaseClass otherEntity);
    protected abstract void OnEnemyCollision(EntityBaseClass otherEntity);
    protected abstract void OnObstacleCollision();
    
    
    
    protected void ApplyEffects(EntityBaseClass otherEntity)
    {
        if (effects.DealCollisionDamage)  DealDamage();
        if (effects.KnockBack) otherEntity.GetKnockedBack(this);
    }


    protected void OnDestroy()
    {
        Debug.Log("on destroy called");
        if (effects.LeaveBurningGround) LeaveBurningGround();
        if (effects.Explosion) Explode();
    }


    // ----------------------------------------------------
    // These are all effects of some sorts
    // ----------------------------------------------------
    
    protected abstract void DealDamage();

    private void LeaveBurningGround()
    {
        var burningGroundEffect = Instantiate(burningGround).GetComponent<BurningGround>();
        burningGroundEffect.effects = effects;
        burningGroundEffect.effects.Explosion = false;
        burningGroundEffect.effects.LeaveBurningGround = false;
        burningGroundEffect.stats = new BurningGroundStats(burningGroundStats);
        burningGroundEffect.FromPlayer = true;
        burningGroundEffect.stats.Duration = 1; // stays for a second
    }
    
    private void Explode()
    {
        var explosionEffect = Instantiate(explosion).GetComponent<Explosion>();
        explosionEffect.effects = effects;
        explosionEffect.effects.Explosion = false;
        explosionEffect.effects.LeaveBurningGround = false;
        explosionEffect.stats = new BurningGroundStats(burningGroundStats);
        explosionEffect.stats.Duration = 1; // stays for a second
    }
}
