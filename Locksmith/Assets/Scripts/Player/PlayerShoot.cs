using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : ShootBaseClass
{
    [SerializeField] private float attackCoolDownMax;
    private float attackCoolDown;
    private PlayerManager entity;
    private bool attackBuffer = false;

    private void Awake()
    {
        entity = GetComponent<PlayerManager>();
        attackCoolDown = attackCoolDownMax;
    }

    private void FixedUpdate()
    {
        attackCoolDown -= Time.fixedDeltaTime;
        if (attackBuffer)
        {
            entity.AttackForPlayerShoot();
        }
    }

    public override void Attack(float direction)
    {
        if (attackCoolDown < 0)
        {
            CreateBullet(transform.position, direction);
            attackCoolDown = attackCoolDownMax;
            attackBuffer = false;
        }
        else
        {
            attackBuffer = true;
        }
    }
}
