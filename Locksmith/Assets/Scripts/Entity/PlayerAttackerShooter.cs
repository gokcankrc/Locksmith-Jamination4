using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAttackerShooter : AttackerShooterBaseClass
{
    // TODO; determine a specific way to handle this cooldown case.
    // Oh btw, the cooldown on how to attack is determined here by cooldown. In enemies, enemy AI determines the
    // cooldown. That's lame.
    [SerializeField] private float attackCoolDownMax;
    [SerializeField] private float accuracyLoss;
    private float attackCoolDown;
    private PlayerEntity playerEntity;
    private bool attackBuffer = false;

    protected override void Awake()
    {
        base.Awake();
        playerEntity = GetComponent<PlayerEntity>();
        attackCoolDown = attackCoolDownMax;
    }

    private void FixedUpdate()
    {
        attackCoolDown -= Time.fixedDeltaTime;
        if (attackBuffer)
        {
            playerEntity.AttackForPlayerShoot();
        }
    }

    public override void Attack(float direction)
    {
        if (attackCoolDown < 0)
        {
            var movement = playerEntity.MoveDirection.magnitude;
            if (movement > 0.1f) direction += Random.Range(-accuracyLoss, accuracyLoss);
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
