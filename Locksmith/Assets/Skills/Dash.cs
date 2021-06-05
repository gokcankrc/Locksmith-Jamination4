using UnityEngine;

public class Dash : ScriptableObject
{
    //Mode 0: Dash according to mouse position --- Mode 1: Dash according to player direction.
    [SerializeField] private int mode;

    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Transform transform;
    [SerializeField] private Vector2 direction;

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashDuration;

    private void Start()
    {
        //rigidbody = GetComponent<Rigidbody2D>();
        //transform = GetComponent<Transform>();
    }

    public void SpecialMove()
    {
        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
            if(mode == 0) //Mouse position
            {
                
                rigidbody.velocity = direction * dashSpeed;
            }
            else if(mode == 1) //Player direction
            {
                if(rigidbody.velocity.x > 0)    direction.x = 1f;
                else                            direction.x = -1f;
                
                if(rigidbody.velocity.y > 0)    direction.y = 1f;
                else                            direction.y = -1f;

                rigidbody.velocity = direction * dashSpeed;
            }
        }
        else
        {
            dashCooldown = dashDuration;
        }
    }
   
    

}
