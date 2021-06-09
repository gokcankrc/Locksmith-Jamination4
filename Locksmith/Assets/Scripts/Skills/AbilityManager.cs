using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public enum Abilities
    {
        Dash,
        //other skills
    };
    public Abilities abilityState;
    public SkillBaseClass[] skills = new SkillBaseClass[5];

    public void AddSkill(SkillBaseClass newSkillBaseClass, int slot)
    {
        skills[slot] = newSkillBaseClass;
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
