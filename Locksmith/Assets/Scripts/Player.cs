using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : EntityBaseClass
{
    private PlayerInputs Inputs;

    public Vector3 MoveDirection => Inputs.MoveDirection;
    public float MoveMultiplayer => Inputs.MoveMultiplayer;
    
    

    void FixedUpdate()
    {
        // if move direction is 0, this might still try to move towards the destination. 
        // nomore, with addition of move multiplayer
        MoveTowards(MoveDirection, MoveMultiplayer);
    }

}
