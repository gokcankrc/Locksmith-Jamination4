using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : EntityBaseClass
{
    [SerializeField] private PlayerInputs Inputs;

    public Vector3 MoveDirection => Inputs.MoveDirection;
    public float MoveMultiplayer => Inputs.MoveMultiplayer;
    
    void FixedUpdate()
    {
        MoveTowards(MoveDirection, MoveMultiplayer);
    }

}
