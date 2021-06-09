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
    }


    public void AddActiveGate(GateSO target)
    {
        if (!activeGates.Contains(target) && target.isCrafted)
        {
            target.isActive = true;
            activeGates.Add(target);

            /* Buradaki 1, image'ın görünürlüğünün full olduğu anlamına geliyor */
            UIManager.Instance.SetInventoryGateImage(target, 1);
        }

    }

    public void RemoveGateFromList(GateSO target)
    {
        if (activeGates.Contains(target))
        {
            /* Buradaki .5f, image'ın görünürlüğünün yarım olduğu anlamına geliyor */
            UIManager.Instance.SetInventoryGateImage(target, .5f);
            target.isActive = false;
            activeGates.Remove(target);
        }
    }
    public void SetGateStatus(GateSO target, bool isActive, bool isCrafted)
    {
        target.isActive = isActive;
        target.isCrafted = isCrafted;
    }
    public void SetGateStatus(GateSO target, bool isCrafted)
    {
        target.isCrafted = isCrafted;
        UIManager.Instance.SetInventoryGateImage(target, .5f);
    }




}