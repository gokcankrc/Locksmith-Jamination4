using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerInputs : MonoBehaviour
{
    private Vector3 _moveDirection;
    private float _moveMultiplayer;
    private bool fireInput;
    private bool dashInput;
    
    public Vector3 MoveDirection { get => _moveDirection; }
    public float MoveMultiplayer { get => _moveMultiplayer; }
    public bool FireInput { get => fireInput; }
    public bool DashInput { get => dashInput; }
    
    
    // Update is called once per frame
    void Update()
    {
        MovementInput();
        if (!fireInput) { fireInput = Input.GetKeyDown(KeyCode.Mouse0); }
        if (!dashInput) { dashInput = Input.GetKeyDown(KeyCode.Space); }
    }
    
    private void MovementInput()
    {
        _moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveMultiplayer = _moveDirection.magnitude;
    }

    public void Flush()
    {
        fireInput = false;
        dashInput = false;
    }
        
}
