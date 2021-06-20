using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthBaseClass
{
    [SerializeField] private float outOfCombatRegen;
    private float outOfCombatRegenDelay = 3;
    private int RegenPeriod;

    protected override void Start()
    {
        base.Start();
        RegenPeriod = 60;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (outOfCombatDuration > outOfCombatRegenDelay)
        {
            PeriodicRegen(outOfCombatRegen);
        }

    }

    void PeriodicRegen(float regenAmount)
    {
        RegenPeriod -= 1;
        if (RegenPeriod <= 0)
        {
            RegenPeriod += 60;
            Heal(regenAmount);
        }
    }
}
