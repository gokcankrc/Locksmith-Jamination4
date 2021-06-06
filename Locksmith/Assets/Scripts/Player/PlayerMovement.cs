using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovementBaseClass
{
    private Animator _animator;

    protected void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
    }

    protected void FixedUpdate()
    {
        _animator.SetFloat("VelX", rb.velocity.x);
        _animator.SetFloat("VelY", rb.velocity.y);
        _animator.SetFloat("Speed", rb.velocity.magnitude);
    
    }
}
