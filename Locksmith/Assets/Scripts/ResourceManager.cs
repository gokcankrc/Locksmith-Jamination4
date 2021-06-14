using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    public ResourceTypeListSO resourceTypeList;

    public delegate void OnResourceChange();
    public static event OnResourceChange onResourceChange;

    private void Awake()
    {
        Instance = this;

        resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
    }

    public bool ContainsItem(ResourceTypeSO resource, int amount)
    {
        int containAmount = 0;

        foreach (ResourceTypeSO res in resourceTypeList.list)
        {
            if (resource == res)
            {
                containAmount = res.amount;
            }
        }

        Debug.Log(containAmount);

        if (containAmount >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        resourceType.amount += amount;
        onResourceChange?.Invoke();

    }

    public void RemoveResources(ResourceTypeSO resource, int amount)
    {
        if (resource.amount >= amount)
        {
            resource.amount -= amount;
            onResourceChange?.Invoke();
        }
    }
}