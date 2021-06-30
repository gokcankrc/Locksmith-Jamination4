using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect
{
    /*
    public static void Interract()
    {
            protected void ApplyHostileEffects(EntityBaseClass otherEntity)
            {
                entity.AttackerClass.AttackhitInvoke();
                if (effects.DealCollisionDamage)  DealDamage();
                if (effects.KnockBack) otherEntity.GetKnockedBack(this);
                
            }
    }
    */


    public static List<Transform> FindClosestUniques(Vector3 mainPos, List<Transform> listOfTargets, int amountOfTargets)
    {
        // TODO; optimize
        // Right now here is really not optimized because it goes through the list many times. like, really bad BigO.
        // Also much easier if we just had a collider.
        // OR enemies were held in little amounts using colliders on players.
        
        List<Transform> closestUniques = new List<Transform>(amountOfTargets);
        for (int i = 0; i < amountOfTargets; i++)
        {
            
            closestUniques.Add(FindClosest(mainPos, listOfTargets));
            listOfTargets.Remove(closestUniques[i]);
        }
        return closestUniques;
    }
    
    public static Transform FindClosest(Vector3 mainPos, IEnumerable<Transform> listOfTargets)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (var potentialTarget in listOfTargets )
        {
            var distanceToTarget = mainPos - potentialTarget.position;
            if (distanceToTarget.sqrMagnitude < closestDistanceSqr)
            {
                closestDistanceSqr = distanceToTarget.sqrMagnitude;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }


    
    public static void AOESync(DamagingAbility instance, EntityBaseClass entity, Vector3 pos, Effects effects)
    {
        var attackerClass = entity.AttackerClass;
        instance.transform.position = pos;
        instance.effects = effects;
        instance.effects.Explosion = false;
        instance.effects.LeaveBurningGround = false;
        instance.stats = new Stats(attackerClass.stats);
        instance.FromPlayer = attackerClass.fromPlayer;
        instance.entity = entity;
    }
}
