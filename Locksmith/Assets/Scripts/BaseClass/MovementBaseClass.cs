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
    
    public void MoveTowards(Vector3 destination, float speedMultiplier)
    {
        if (!entity.Dashing)
        {
            var velocity = destination.normalized * (speedMultiplier * moveSpeed * Time.fixedDeltaTime);
            rb.velocity = velocity;
        }
        else
        {
            
        }
    }

    public void KnockBack()
    {
        Debug.Log("KnockBack has not been implemented yet");
    }
}
