using UnityEngine;

public class Dash : MonoBehaviour
{
    //Mode 0: Dash according to mouse position --- Mode 1: Dash according to player direction.
    public int mode;

    [SerializeField] private Vector2 direction;

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration = 30f;
    [SerializeField] private float dashBoundary;
    private float dashCooldown;
    private bool dashPressed;

    private void Update()
    {
        if (dashPressed)
        {
            dashCooldown -= Time.deltaTime;
        }
    }

    public void SpecialMove(Rigidbody2D rigidbody, Transform transform, Camera cam)
    {
        dashCooldown = dashDuration;
        if (dashCooldown > 0 && !dashPressed)
        {
            dashPressed = true;
            if(mode == 0) //Mouse position
            {
                Vector2 mousePos = Input.mousePosition;
                Vector2 entityPos = cam.WorldToScreenPoint(transform.position);
                direction = entityPos - mousePos;

                if (Mathf.Abs(direction.x) > dashBoundary)
                {
                    if (direction.x < 0)    direction.x = -dashBoundary;
                    else                    direction.x = dashBoundary;
                }

                if (Mathf.Abs(direction.y) > dashBoundary)
                {
                    if (direction.y < 0)    direction.y = -dashBoundary;
                    else                    direction.y = dashBoundary;
                }

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
            dashPressed = false;
            dashCooldown = dashDuration;
            rigidbody.velocity = Vector2.zero;
        }
    }
}