using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ResourceType")]
public class ResourceTypeSO : ScriptableObject
{
    public enum ResourceType
    {
        ObjectA,
        ObjectB,
        ObjectC
    }

    public ResourceType resourceType;
    public int amount;
}

