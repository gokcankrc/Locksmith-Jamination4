using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/GateListSO")]
public class GateListSO : ScriptableObject
{
    public List<GateSO> list;
}

