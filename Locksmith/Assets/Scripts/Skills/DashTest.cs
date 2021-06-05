using UnityEngine;

public class DashTest : MonoBehaviour
{
    public Dash dash;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            dash.UseSkill();
        }
    }
}
