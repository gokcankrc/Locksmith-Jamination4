using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public enum Abilities
    {
        Dash,
        //other skills
    };
    public Abilities abilityState;
    public Skill[] skills = new Skill[5];

    public void AddSkill(Skill newSkill, int slot)
    {
        skills[slot] = newSkill;
    }

    public void ActivateSkill(int slot)
    {
        skills[slot].UseSkill();
    }

  /*public void ActivateSkill(int slot)
    {
        skills[slot].Activate();
    }

    public void DeactivateSkill(int slot)
    {
        skills[slot].Deactivate();
    }*/
}
