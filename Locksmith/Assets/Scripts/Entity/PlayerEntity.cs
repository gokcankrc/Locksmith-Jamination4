using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class PlayerEntity : EntityBaseClass
{
    [SerializeField] private PlayerInputs Inputs;
    [SerializeField] private float firingSlowDown;

    private Vector2 facingDirection;
    private List<Vector2> facingDirectionQueue = new List<Vector2>();
    
    

    public Vector3 MoveDirection => Inputs.MoveDirection;
    public float MoveMultiplayer => Inputs.MoveMultiplayer;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            facingDirectionQueue.Add(Vector2.down);
        }
    }

    void FixedUpdate()
    {
        
         
        if (MoveDirection.magnitude > 0.1f)
        {
            var moveMulti = MoveMultiplayer;
            if (Inputs.FireInput) { moveMulti *= firingSlowDown;}
            MoveTowards(transform.position + MoveDirection, moveMulti);
            

            
            facingDirectionQueue.RemoveAt(0);
            facingDirectionQueue.Add(MoveDirection);
            facingDirection = Vector2Average(facingDirectionQueue).normalized;
        }
        else
        {
            moveClass.Stop();
        }
        if (Inputs.FireInput)
        {
            // attacks in direction player is facing
            var direction = Vector3.SignedAngle(Vector3.right,facingDirection, Vector3.back);
            Attack(direction);
        }

        moveClass.facing = facingDirection;

        if (Inputs.DashInput) GetComponent<Dash>().UseSkill();
        /*
        if (Inputs.PushInput)
        {
            GetComponent<BulletPush>().UseSkill();
            if (pushing)
            {
                var direction = Vector3.SignedAngle(Vector3.right, facingDirection, Vector3.back);
                Attack(direction);
            }
        }*/
        
        if (Inputs.AddPushEffect)
        {
            Debug.Log("added or removed knockback skill");
            Inputs.AddPushEffect = false;
            
            var _skill = new Effects();
            _skill.KnockBack = true;
            ToggleSkill(_skill);
        }

        Inputs.Flush();
    }

    private Vector2 Vector2Average(List<Vector2> array)
    {
        var sum = array.Aggregate(Vector2.zero, (current, vector) => current + vector);
        return sum / array.Count;
    }

    public void AttackForPlayerShoot()
    {
        var direction = Vector3.SignedAngle(Vector3.right,facingDirection, Vector3.back);
        Attack(direction);
    }

}
