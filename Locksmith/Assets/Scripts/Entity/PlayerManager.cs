using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : EntityBaseClass
{
    [SerializeField] private PlayerInputs Inputs;
    [SerializeField] private float firingSlowDown;

    private Vector2 facingDirection;


    public Vector3 MoveDirection => Inputs.MoveDirection;
    public float MoveMultiplayer => Inputs.MoveMultiplayer;
    
    void FixedUpdate()
    {
         
        if (MoveDirection.magnitude > 0.1f)
        {
            var moveMulti = MoveMultiplayer;
            if (Inputs.FireInput) { moveMulti *= firingSlowDown;}
            MoveTowards(transform.position + MoveDirection, moveMulti);
            facingDirection = MoveDirection;
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

    public void AttackForPlayerShoot()
    {
        var direction = Vector3.SignedAngle(Vector3.right,facingDirection, Vector3.back);
        Attack(direction);
    }

}
