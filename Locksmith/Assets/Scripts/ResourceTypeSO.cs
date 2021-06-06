using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ResourceType
{
    HermitStone,
    AeroIronStone,
    WaterStone,
    HermoWaterStone,
    IronStone,
    AirStone,
    HydroIronStone,
    AeroWaterStone,
    Fixaron,
    Metacore
}

[CreateAssetMenu(menuName = "ScriptableObjects/ResourceType")]
public class ResourceTypeSO : ScriptableObject
{
    public ResourceType resourceType;
    public int amount;
}

