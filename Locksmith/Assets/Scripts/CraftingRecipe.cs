using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/BaseItem")]
public class CraftingRecipe : ScriptableObject
{
    public GateSO result;
    public Materials[] materials;

    public bool CanCraft()
    {
        foreach (Materials material in materials)
        {
            bool containsCurrentMaterial = ResourceManager.Instance.ContainsItem(material.material, material.amount);

            if (!containsCurrentMaterial)
            {
                return false;
            }
        }

        return true;
    }

    public void RemoveMaterialsFromList()
    {
        foreach (Materials material in materials)
        {
            ResourceManager.Instance.RemoveResources(material.material, material.amount);
        }
    }

    public void Use()
    {
        if (CanCraft())
        {
            RemoveMaterialsFromList();

            result.isCrafted = true;
        }
        else
        {
            Debug.Log("money is no");
        }
    }

    [Serializable]
    public class Materials
    {
        public ResourceTypeSO material;
        /* kapı için gerekli miktar */
        public int amount;
    }
}




