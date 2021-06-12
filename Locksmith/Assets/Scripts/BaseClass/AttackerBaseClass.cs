using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public abstract class AttackerBaseClass : MonoBehaviour
{
    [SerializeField] public Effects effects;

    public void Awake()
    {
        effects = new Effects();
    }

    public virtual void Attack(float direction)
    {
        
    }

    public virtual void Collide()
    {
        
    }
    
}

[Serializable]
public class Effects
{
    public Effects()
    {
        // why the fuck you don't work?
        list = new bool[4];
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = false;
        }
    }

    public Effects(Effects effects) 
    {
        list[0] = effects.DealCollisionDamage;
        list[1] = effects.KnockBack;
        list[2] = effects.LeaveBurningGround;
        list[3] = effects.Explosion;
    }
    
    // TODO; public static EffectsEnum[] EnumArray = Enum.GetValues(typeof(EffectsEnum)).Cast<EffectsEnum>().ToArray();
    // TODO; figure out why the fuck you don't work? edit: If you don't edit this value from Unity, it does not create
    // a list that is initialized.
    
    public bool[] list = new []{false,false,false,false};
    
    // TODO; figure out how this won't be a mess like this. Make it possible to easily get items intuitively
    
    public bool DealCollisionDamage
    {
        get => list[0]; set => list[0] = value;
    }
    public bool KnockBack
    {
        get => list[1]; set => list[1] = value;
    }
    public bool LeaveBurningGround
    {
        get => list[2]; set => list[2] = value;
    }
    public bool Explosion
    {
        get => list[3]; set => list[3] = value;
    }
}
