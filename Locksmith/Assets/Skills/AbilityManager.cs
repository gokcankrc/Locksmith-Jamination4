using UnityEngine;

public class AbilityManager : ScriptableObject
{
    public enum Abilities
    {
        Dash,
        //other skills
    };
    public Abilities abilityState;
    public Skill[] skills = new Skill[5];
    
    public void ActivateSkill(int slot)
    {
        skills[slot].Activate();
    }

    public void DeactivateSkill(int slot)
    {
        skills[slot].Deactivate();
    }
}
