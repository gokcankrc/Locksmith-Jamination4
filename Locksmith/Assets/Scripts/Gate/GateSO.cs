using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;
using UnityEngineInternal;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;
using UnityEngineInternal;
using Random = UnityEngine.Random;

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
    public GateStats playerStats;
    public GateStats enemyStats;
    public Effects playerEffects;
    public Effects enemyEffects;
    public List<EnemyDrop.Drop> gateDrops;

    public CraftingRecipe gateRecipe;
    public bool isCrafted;
    public bool isActive;
}

[Serializable]
public class GateStats
{

    public static GateStats operator+(GateStats toBeCloned)
    {
        GateStats buffer = new GateStats();
        buffer.damageAdd = toBeCloned.damageAdd;
        buffer.durationAdd = toBeCloned.durationAdd;
        buffer.maxHealthAdd = toBeCloned.maxHealthAdd;
        return buffer;
    }
    
    public static GateStats operator-(GateStats toBeReversed)
    {
        GateStats buffer = new GateStats();
        // TODO; please for the love of god, tell me how can I automatize this. this is fkn dumb. Same happens with Effects
        buffer.damageAdd = - toBeReversed.damageAdd;
        buffer.durationAdd = - toBeReversed.durationAdd;
        buffer.maxHealthAdd = - toBeReversed.maxHealthAdd;
        /* If we add like multiplications, we use these.
        buffer.damageMult = 1 / toBeReversed.damageMult;
        buffer.durationMult = 1 / toBeReversed.durationMult;
        buffer.healthMult = 1 / toBeReversed.healthMult;
        */
        return buffer;
    }
    public float damageAdd;
    public float durationAdd;
    public int maxHealthAdd;
}
