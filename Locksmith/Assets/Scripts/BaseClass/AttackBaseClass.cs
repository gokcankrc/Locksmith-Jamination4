using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public abstract class AttackBaseClass : MonoBehaviour
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

    // why the fuck you don't work?
    public bool[] list = new []{false,false,false,false};


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
