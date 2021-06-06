using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPush : Skill
{
    [SerializeField] private float pushMaxCdTime;
    [SerializeField] private float pushMaxDuration;
    [SerializeField] private float pushSpeed;
    [SerializeField] private EntityBaseClass entity;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool onCooldown;

    public Projectile bullet;
    
    private float pushCdTime;
    private float pushDuration;
    private Vector2 direction;

    private void Awake()
    {
        entity = GetComponent<EntityBaseClass>();
        pushDuration = pushMaxDuration;
    }

    private void Update()
    {
        if (pushDuration > 0 && entity.Pushing)
        {
            pushDuration -= Time.deltaTime;
            if (pushDuration <= 0)
            {
                pushDuration = pushMaxDuration;
                entity.Pushing = false;
            }
        }
        if (onCooldown)
        {
            pushCdTime -= Time.deltaTime;
            if (pushCdTime < 0)
                onCooldown = false;
        }
    }

    public override void UseSkill()
    {
        if (!onCooldown)
        {
            pushCdTime = pushMaxCdTime;
            pushDuration= pushMaxDuration;
            onCooldown = true;
            // entity.Pushing = true;
            direction = bullet.GetComponent<Rigidbody2D>().velocity.normalized;
            rb.velocity = direction * pushSpeed;
        }
    }
}
