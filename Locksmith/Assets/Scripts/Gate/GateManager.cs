using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public static GateManager Instance;
    GateListSO gateList;
    public List<GateSO> activeGates;

    private void Awake()
    {
        Instance = this;
        gateList = Resources.Load<GateListSO>(typeof(GateListSO).Name);
        CheckActiveGates();
    }

    public void CheckActiveGates()
    {
        foreach (GateSO gate in gateList.list)
        {
            if (gate.isActive)
            {
                activeGates.Add(gate);
            }
        }
    }

    public void AddActiveGate(GateSO target)
    {
        if (!activeGates.Contains(target) && target.isCrafted)
        {
            target.isActive = true;
            activeGates.Add(target);

            UIManager.Instance.SetInventoryGateImage(target, UIManager.Instance.Opaque);
        }

    }

    public void RemoveGateFromList(GateSO target)
    {
        if (activeGates.Contains(target))
        {
            target.isActive = false;
            activeGates.Remove(target);

            UIManager.Instance.SetInventoryGateImage(target, UIManager.Instance.Transparent);
        }
    }
}