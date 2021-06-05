using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private Vector3 _moveDirection;
    private float _moveMultiplayer;
    
    public Vector3 MoveDirection { get => _moveDirection; }
    public float MoveMultiplayer { get => _moveMultiplayer; }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }
    
    private void MovementInput()
    {
        _moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveMultiplayer = _moveDirection.magnitude;
        _moveDirection = _moveDirection;
    }
}
