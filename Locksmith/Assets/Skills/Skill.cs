using UnityEngine;

public class Skill : MonoBehaviour
{
    protected bool skillEnabled;
    public void Activate()
    {
        skillEnabled = true;
    }

    public void Deactivate()
    {
        skillEnabled = false;
    }
}
