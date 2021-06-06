using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ResourceType")]
public class ResourceTypeSO : ScriptableObject
{
    public enum ResourceType
    {
        HermitStone,
        AeroIron,
        WaterStone,
        HermoWaterStone,
        IronStone,
        AirStone,
        HydroIronStone,
        AeroWaterStone,
        Fixaron
    }

    public ResourceType resourceType;
    public int amount;
}

