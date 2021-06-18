using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EntityType = EntityBaseClass.EntityType;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;

    void Start()
    {
        Instance = this;
        GateManager.onGateToggle += OnGateToggle; 
    }

    void OnGateToggle(GateSO gateSo, bool activation)
    {
        // Normally I wanted to create a local copy of GateSO, but making a deep copy of anything not monobehaviour 
        // seems to be pretty hard cuz you have to write a DeepCopy method yourself.
        // TODO; Maybe such thing exists for scriptable object, maybe we should make these MonoBehaviour.
        var playerStats = + gateSo.playerStats;
        var enemyStats = + gateSo.enemyStats;
        // this script tells every entity to update themselves with the brand new opening/closing of the gate.
        if (!activation)
        {
            playerStats = - playerStats;
            enemyStats = - enemyStats;
        }
        var playerEntity = GameManager.Instance.Player.GetComponent<EntityBaseClass>();
        playerEntity.ToggleSkill(gateSo.playerEffects);
        playerEntity.GetGateStats(playerStats);
        
        var buffer = EnemyManager.I.CurrentlyActiveEnemies;
        
        Debug.Log("Enemy count: " + EnemyManager.I.CurrentlyActiveEnemies.Count());
        foreach (var entity in buffer)
        {
            // TODO; this might go to 2000 enemy entities. we don't want that do we? some kind of load/unload might be required here.
            // TODO; make it so that enemy manager holds them as entitybaseclasses.
            entity.GetComponent<EntityBaseClass>().ToggleSkill(gateSo.enemyEffects);
            entity.GetComponent<EntityBaseClass>().GetGateStats(enemyStats);
        }
    }

    public static void GetEffectsOnFreshSpawn(EntityBaseClass entity)
    {
        foreach (var gate in GateManager.Instance.activeGates)
        {
            if (gate.isActive)
            {
                switch (entity.type)
                {
                    case EntityType.Player:
                        entity.GetGateStats(gate.playerStats);
                        break;
                    case EntityType.EnemyShooter:
                        entity.GetGateStats(gate.enemyStats);
                        break;
                    default:
                        Debug.Log("The entity did not have type. aborting");
                        break;
                }
            }
        }
    }
}
