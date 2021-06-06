using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBaseClass : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    private EntityBaseClass entity;
    Rigidbody2D rb;

    private void Awake()
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
