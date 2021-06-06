using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBaseClass : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    private EntityBaseClass entity;
    protected Rigidbody2D rb;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        entity = GetComponent<EntityBaseClass>();
    }
    
    public void MoveTowards(Vector3 destination, float speedMultiplier=1f)
    {
        if (!entity.Dashing && !entity.Pushing)
        {
            var direction = (destination - transform.position).normalized;
            var velocity = direction * (speedMultiplier * moveSpeed * Time.fixedDeltaTime);
            rb.velocity = velocity;
        }
    }

    public void Stop()
    {
        rb.velocity = rb.velocity * 0.000000001f;
    }
}
