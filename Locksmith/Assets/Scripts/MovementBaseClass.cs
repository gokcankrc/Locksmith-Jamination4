using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBaseClass : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private EntityBaseClass entity;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void MoveTowards(Vector3 destination, float speedMultiplier)
    {
        if (entity.Dashing)
        {
            rb.velocity = destination * (speedMultiplier * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
