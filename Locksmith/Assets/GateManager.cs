﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    GateListSO gateList;
    public List<GateSO> activeGates;

    private void Awake()
    {
        gateList = Resources.Load<GateListSO>(typeof(GateListSO).Name);
    }


    public void AddActiveGate(GateSO target)
    {
        foreach (GateSO gate in gateList.list)
        {
            if (!activeGates.Contains(target) && target.isCrafted)
            {
                target.isActive = true;
                activeGates.Add(gate);

                /* Buradaki 1, image'ın görünürlüğünün full olduğu anlamına geliyor */
                UIManager.Instance.InventoryGateImage(target, 1); 
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
                UIManager.Instance.InventoryGateImage(target, .5f);
                target.isActive = false;
                activeGates.Remove(gate);
            }
        }
    }
}