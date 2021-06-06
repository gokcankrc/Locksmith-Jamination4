using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private Player player;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovementInput();
    }

    private void FixedUpdate()
    {
        //if (!player.Dashing)
        //{
        //    rb.velocity = moveDirection * (moveSpeed * Time.fixedDeltaTime);
        //}
    }
    private void MovementInput()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDirection = moveDirection.normalized;
    }
}
