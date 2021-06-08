using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GateType
{
    Hermoor,
    Earth,
    Gronor,
    Raha,
    Wodas,
    Liridian,
    Brenit
}

[CreateAssetMenu(menuName = "ScriptableObjects/GateSO")]
public class GateSO : ScriptableObject
{
    public GateType gateType;
    public string gateName;
    public string gateDescription;
    public string gateRequirementDescription;
    public string adverseEffectsDescription;
    public string positiveEffectsDescription;

    public CraftingRecipe gateRecipe;
    public bool isCrafted;
    public bool isActive;
}
