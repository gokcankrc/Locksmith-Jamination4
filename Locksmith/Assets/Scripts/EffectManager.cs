using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GateManager.onGateToggle += OnGateToggle; 
    }

    void OnGateToggle(GateSO gateSo, bool activation)
    {
        // this script tells every entity to update themselves with the brand new opening/closing of the gate.
        if (!activation)
        {
            gateSo.EnemyStats = - gateSo.EnemyStats;
            gateSo.PlayerStats = - gateSo.PlayerStats;
        }
        
        var playerEntity = GameManager.Instance.Player.GetComponent<EntityBaseClass>();
        playerEntity.ToggleSkill(gateSo.playerEffects);
        playerEntity.GetGateStats(gateSo.PlayerStats);
        
        var buffer = EnemyManager.I.CurrentlyActiveEnemies;
        foreach (var entity in buffer)
        {
            // TODO; this might go to 2000 enemy entities. we don't want that do we? some kind of load/unload might be required here.
            // TODO; make it so that enemy manager holds them as entitybaseclasses.
            entity.GetComponent<EntityBaseClass>().ToggleSkill(gateSo.enemyEffects);
            entity.GetComponent<EntityBaseClass>().GetGateStats(gateSo.EnemyStats);
        }
    }
}
