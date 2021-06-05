using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillHolder : MonoBehaviour
{
    [SerializeField] private int skillSlotAmount;

    private Skill[] skillList;

    void Start()
    {
        skillList = new Skill[skillSlotAmount];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
