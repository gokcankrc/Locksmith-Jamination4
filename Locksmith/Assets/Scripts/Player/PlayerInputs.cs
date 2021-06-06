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
    private bool pushInput;
    
    public Vector3 MoveDirection { get => _moveDirection; }
    public float MoveMultiplayer { get => _moveMultiplayer; }
    public bool FireInput { get => fireInput; }
    public bool DashInput { get => dashInput; }
    public bool PushInput { get => pushInput; }


    // Update is called once per frame
    void Update()
    {
        MovementInput();
        if (!fireInput) { fireInput = Input.GetKey(KeyCode.Mouse0); }
        if (!dashInput) { dashInput = Input.GetKeyDown(KeyCode.Space); }
        if (!pushInput) { pushInput = Input.GetKeyDown(KeyCode.T); }
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
        pushInput = false;
    }
        
}
