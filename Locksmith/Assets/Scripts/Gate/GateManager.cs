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
            // UseGateEffect
            UIManager.Instance.SetInventoryGateImage(target, UIManager.Instance.Opaque);
        }

    }

    public void RemoveGateFromList(GateSO target)
    {
        if (activeGates.Contains(target))
        {
            target.isActive = false;
            activeGates.Remove(target);
            // RemoveGateEffect
            UIManager.Instance.SetInventoryGateImage(target, UIManager.Instance.Transparent);
        }
    }

    private void UseGateEffect(GateSO gate)
    {
        switch (gate.gateType)
        {
            case GateType.Hermoor:
                //Use skills
                /*  set boolean true, while boolean true 
                 * some effects active 
                 * 
                 * 
                 */
                break;
            case GateType.Earth:
                //Use skills
                break;
            case GateType.Gronor:
                //Use skills
                break;
            case GateType.Raha:
                //Use skills
                break;
            case GateType.Wodas:
                //Use skills
                break;
            case GateType.Liridian:
                //Use skills
                break;
            case GateType.Brenit:
                //Use skills
                break;
        }
    }
    private void RemoveGateEffect(GateSO gate)
    {
        switch (gate.gateType)
        {
            case GateType.Hermoor:
                
                /* Set boolean false  
                 * 
                 * 
                 * 
                 */
                break;
            case GateType.Earth:
                //Use skills
                break;
            case GateType.Gronor:
                //Use skills
                break;
            case GateType.Raha:
                //Use skills
                break;
            case GateType.Wodas:
                //Use skills
                break;
            case GateType.Liridian:
                //Use skills
                break;
            case GateType.Brenit:
                //Use skills
                break;
        }
    }


}