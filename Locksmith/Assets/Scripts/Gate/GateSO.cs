using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GateSO")]
public class GateSO : ScriptableObject
{
    public string gateName;
    public string gateDescription;
    public string gateRequirementDescription;
    public string adverseEffectsDescription;
    public string positiveEffectsDescription;

    public CraftingRecipe gateRecipe;
    public bool isCrafted;
}
