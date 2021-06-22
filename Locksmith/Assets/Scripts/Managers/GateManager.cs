using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GateManager : MonoBehaviour
{
    public static GateManager Instance;
    GateListSO gateList;
    public List<GateSO> activeGates;

    public delegate void OnGateToggle(GateSO gateSo, bool activation);
    public static event OnGateToggle onGateToggle;

    private void Awake()
    {
        Instance = this;
        gateList = Resources.Load<GateListSO>(typeof(GateListSO).Name);
        if (GameManager.Instance.resetCraftedGatesOnStart)
        {
            foreach (var VARIABLE in gateList.list)
            {
                VARIABLE.isActive = false;
                VARIABLE.isCrafted = false;
            }
        }
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
            onGateToggle?.Invoke(target, true);
            target.isActive = true;
            activeGates.Add(target);
            EnemyDrop.I.AddDrops(target.gateDrops);
            // UseGateEffect
            UIManager.Instance.SetInventoryGateImage(target, UIManager.Instance.Opaque);
        }

    }

    public void RemoveGateFromList(GateSO target)
    {
        if (activeGates.Contains(target))
        {
            onGateToggle?.Invoke(target, false);
            target.isActive = false;
            activeGates.Remove(target);
            EnemyDrop.I.RemoveDrops(target.gateDrops);
            // RemoveGateEffect
            UIManager.Instance.SetInventoryGateImage(target, UIManager.Instance.Transparent);
        }
    }

}