using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAttackerShooter : AttackerShooterBaseClass
{
    [SerializeField] private float attackCoolDownMax;
    [SerializeField] private float accuracyLoss;
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
            var movement = entity.MoveDirection.magnitude;
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
