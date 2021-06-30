using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    // fill here up.
    protected bool Hostile = true;
    public BuffType buffType;
    
    
    public enum BuffType
    {
        Doom, ExplodeOnDeath, StatChanger
    }
}
