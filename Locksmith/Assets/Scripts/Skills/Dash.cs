using UnityEngine;

public class Dash : Skill
{
    //Mode 0: Dash according to mouse position --- Mode 1: Dash according to player direction.
    public int mode;
    private Vector2 direction;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashMaxDuration;
    [SerializeField] private float dashMaxCdTime;
    [SerializeField] private EntityBaseClass entity; //check for boolean somewhere instead
    private float dashDuration;
    private float dashCdTime;
    public bool onCooldown;


    private void Awake()
    {
        entity = GetComponent<EntityBaseClass>();
        dashDuration = dashMaxDuration;
    }

    private void Update()
    {
        if(dashDuration > 0 && entity.Dashing)
        {
            dashDuration -= Time.deltaTime;
            if(dashDuration <= 0)
            {
                dashDuration = dashMaxDuration;
                entity.Dashing = false;
            }
        }
        if (onCooldown)
        {
            dashCdTime -= Time.deltaTime;
            if(dashCdTime < 0)
                onCooldown = false;
        }
    }

    public override void UseSkill()
    {
        if (!onCooldown)
        {
            dashCdTime = dashMaxCdTime;
            dashDuration = dashMaxDuration;
            onCooldown = true;
            entity.Dashing = true;
            if (mode == 0) //Mouse position
            {
                Vector2 mousePos = Input.mousePosition;
                Vector2 entityPos = cam.WorldToScreenPoint(transform.position);
                direction = mousePos - entityPos;
                direction.Normalize();
                rb.velocity = direction * dashSpeed;
            }
            else if (mode == 1) //Player direction
            {
                direction = rb.velocity.normalized;
                rb.velocity = direction * dashSpeed;
            }
        }
    }
}