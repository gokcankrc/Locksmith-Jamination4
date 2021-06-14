using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GateManager : MonoBehaviour
{
    GateListSO gateList;
    public List<GateSO> activeGates;

    public delegate void OnGateToggle(GateSO gateSo, bool activation);
    public static event OnGateToggle onGateToggle;
    public static GateManager Instance;

    private void Awake()
    {
        CheckActiveGates();

        gateList = Resources.Load<GateListSO>(typeof(GateListSO).Name);
        Instance = this;
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
        foreach (GateSO gate in gateList.list)
        {
            if (!activeGates.Contains(target) && target.isCrafted)
            {
                target.isActive = true;
                activeGates.Add(gate);
                onGateToggle?.Invoke(target, true);
                /* Buradaki 1, image'ın görünürlüğünün full olduğu anlamına geliyor */
                UIManager.Instance.SetInventoryGateImage(target, 1); 
            }
        }
    }

    public void RemoveGateFromList(GateSO target)
    {
        foreach (GateSO gate in gateList.list)
        {
            if (activeGates.Contains(gate))
            {
                /* Buradaki .5f, image'ın görünürlüğünün yarım olduğu anlamına geliyor */
                UIManager.Instance.SetInventoryGateImage(target, .5f);
                target.isActive = false;
                activeGates.Remove(gate);
                onGateToggle?.Invoke(target, false);
            }
        }
    }
}