using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    public ResourceTypeListSO resourceTypeList;

    public delegate void OnItemChange();
    public OnItemChange onItemChange = delegate { };


    private void Awake()
    {
        Instance = this;

        resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
    }

    private void Update()
    {

    }

    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        resourceType.amount += amount;
    }

    public void RemoveResource(ResourceTypeSO resourceType, int amount)
    {
        if (resourceType.amount <= 0)
        {
            resourceType.amount -= amount;
        }
    }

    public void AddResource(ResourceTypeSO resource)
    {
        resourceTypeList.list.Add(resource);
        onItemChange.Invoke();
    }
    public void RemoveResource(ResourceTypeSO resource)
    {
        resourceTypeList.list.Remove(resource);
        onItemChange.Invoke();
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

    public void RemoveResources(ResourceTypeSO resource, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            RemoveResource(resource);
        }
    }
}