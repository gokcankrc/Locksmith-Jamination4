﻿using System;
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
    public gateStats PlayerStats;
    public gateStats EnemyStats;
    public Effects playerEffects;
    public Effects enemyEffects;

    public CraftingRecipe gateRecipe;
    public bool isCrafted;
    public bool isActive;
}

[Serializable]
public class gateStats
{
    public static gateStats operator-(gateStats toBeReversed)
    {
        // If gate is being closed, this will make them inversed.

        // TODO; please for the love of god, tell me how can I automatize this. this is fkn dumb. Same happens with Effects
        toBeReversed.damageAdd = - toBeReversed.damageAdd;
        toBeReversed.durationAdd = - toBeReversed.durationAdd;
        toBeReversed.maxHealthAdd = - toBeReversed.maxHealthAdd;
        /* If we add like multiplications, we use these.
        toBeReversed.damageMult = 1 / toBeReversed.damageMult;
        toBeReversed.durationMult = 1 / toBeReversed.durationMult;
        toBeReversed.healthMult = 1 / toBeReversed.healthMult;
        */
        return toBeReversed;
    }
    public float damageAdd;
    public float durationAdd;
    public int maxHealthAdd;
}
