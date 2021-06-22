using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovementBaseClass
{
    protected void FixedUpdate()
    {
        animator.SetFloat("VelX", facing.x);
        animator.SetFloat("VelY", facing.y);
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }
}
