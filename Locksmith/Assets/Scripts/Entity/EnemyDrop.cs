using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] public List<Drop> drops;
    [Range(0.0F, 2.0F)]
    [SerializeField] private float lootDistance;

    public static EnemyDrop I;
    
    private void Awake()
    {
        I = this;
    }
    
    [Serializable]
    public class Drop
    {
        public GameObject prefab;
        public int chance;
        public int amount;
    }

    public void DropOnDeath(Transform dyingEnemyPos)
    {
        foreach (var droppable in drops)
        {
            for (int i = 0; i < droppable.amount; i++)
            {
                var chanceCheck = (Random.Range(0, 100f) - droppable.chance < 0);
                if (!chanceCheck) continue;
                
                var angle = Random.Range(0f, 360f);
                var distance = Random.Range(0f, lootDistance);
                var randomizePos = Quaternion.AngleAxis(angle, Vector3.back) * Vector3.right * distance;
                
                var drop = Instantiate(droppable.prefab);
                drop.transform.position = dyingEnemyPos.position + randomizePos;
            }
        }
    }


    public void AddDrops(List<Drop> dropsToAdd)
    {
        foreach (var VARIABLE in dropsToAdd)
        {
            drops.Add(VARIABLE);
        }
    }
    
    public void RemoveDrops(List<Drop> dropsToRemove)
    {
        foreach (var VARIABLE in dropsToRemove)
        {
            drops.Remove(VARIABLE);
        }
    }
}
