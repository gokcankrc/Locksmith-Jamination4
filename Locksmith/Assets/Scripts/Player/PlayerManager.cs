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
        MoveTowards(transform.position + MoveDirection, MoveMultiplayer);
        if (Inputs.FireInput)
        {
            // attacks in direction player is facing

            var direction = Vector3.SignedAngle(Vector3.right,MoveDirection, Vector3.back);
            Attack(direction);
        }

        if (Inputs.DashInput)
        {
            
        }

        Inputs.Flush();
    }

}
