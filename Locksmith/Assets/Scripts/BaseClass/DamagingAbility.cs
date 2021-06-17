using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamagingAbility : MonoBehaviour
{
    [SerializeField] public Effects effects;
    [SerializeField] public Stats stats;
    [SerializeField] public bool FromPlayer;
    
    [SerializeField] protected GameObject burningGround;
    [SerializeField] protected GameObject explosion;

    protected Vector2 effectDirection;
    public virtual Vector2 EffectDirection
    {
        get => effectDirection;
        set => effectDirection = value;
    }

    protected EntityBaseClass _collisionEntity;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Interract(other);
    }

    protected virtual void Interract(Collider2D other)
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

    protected virtual void OnPlayerCollision(EntityBaseClass otherEntity)
    {
        if (!FromPlayer)
        {
            ApplyHostileEffects(otherEntity.GetComponent<EntityBaseClass>());
        }       
        else
        {
            ApplyAllyEffects(otherEntity.GetComponent<EntityBaseClass>());
        }
    }

    protected virtual void OnEnemyCollision(EntityBaseClass otherEntity)
    {
        if (FromPlayer)
        {
            ApplyHostileEffects(otherEntity.GetComponent<EntityBaseClass>());
        }
        else
        {
            ApplyAllyEffects(otherEntity.GetComponent<EntityBaseClass>());
        }
    }

    protected virtual void OnObstacleCollision()
    {
        // Does not interract
    }


    protected void ApplyHostileEffects(EntityBaseClass otherEntity)
    {
        if (effects.DealCollisionDamage)  DealDamage();
        if (effects.KnockBack) otherEntity.GetKnockedBack(this);
    }

    protected void ApplyAllyEffects(EntityBaseClass otherEntity)
    {
        if (effects.Heal) Heal();
    }
    
    protected virtual void OnDestroy()
    {
        if (effects.LeaveBurningGround) LeaveBurningGround();
        if (effects.Explosion) Explode();
    }


    // ----------------------------------------------------
    // These are all effects of some sorts
    // ----------------------------------------------------
    
    protected abstract void DealDamage();
    protected abstract void Heal();

    protected virtual void LeaveBurningGround()
    {
        var burningGroundEffect = Instantiate(burningGround).GetComponent<DamagingPeriodicAoE>();
        // I saw this line randomly. probably an error. leaving as note.
        // burningGroundEffect.FromPlayer = true;
        AoEEffectSync(burningGroundEffect);
        burningGroundEffect.transform.Rotate(Vector3.back, Random.Range(0, 360));
    }
    
    protected virtual void Explode()
    {
        var explosionEffect = Instantiate(explosion).GetComponent<DamagingInstantAoE>();
        AoEEffectSync(explosionEffect);
    }

    protected void AoEEffectSync(DamagingAbility Instance)
    {
        Instance.transform.position = transform.position;
        Instance.effects = effects;
        Instance.effects.Explosion = false;
        Instance.effects.LeaveBurningGround = false;
        Instance.stats = new Stats(stats);
        Instance.FromPlayer = FromPlayer;
    }
}
