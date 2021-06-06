﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : EntityBaseClass
{
    [SerializeField] private PlayerInputs Inputs;
    [SerializeField] private float firingSlowDown;

    private Vector2 facingDirection;


    public Vector3 MoveDirection => Inputs.MoveDirection;
    public float MoveMultiplayer => Inputs.MoveMultiplayer;
    
    void FixedUpdate()
    {
         
        if (MoveDirection.magnitude > 0.1f)
        {
            var moveMulti = MoveMultiplayer;
            if (Inputs.FireInput) { moveMulti *= firingSlowDown;}
            MoveTowards(transform.position + MoveDirection, moveMulti);
            facingDirection = MoveDirection;
        }
        else
        {
            moveClass.Stop();
        }
        if (Inputs.FireInput)
        {
            
            // attacks in direction player is facing
            var direction = Vector3.SignedAngle(Vector3.right,facingDirection, Vector3.back);
            Attack(direction);
        }

        if (Inputs.DashInput)
        {
            GetComponent<Dash>().UseSkill();
        }

        Inputs.Flush();
    }

    public void AttackForPlayerShoot()
    {
        var direction = Vector3.SignedAngle(Vector3.right,facingDirection, Vector3.back);
        Attack(direction);
    }

}