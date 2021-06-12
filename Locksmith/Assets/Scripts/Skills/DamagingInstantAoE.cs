using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingInstantAoE : DamagingAoE
{
    protected override void Start()
    {
        // Stays for 5 frames
        skillDurationMultiplayer = 1;
        areaOfEffectStats.Duration = 0.1f;
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
