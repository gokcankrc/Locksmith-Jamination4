using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] private Drops[] drops;
    [SerializeField] private GameObject DroppedItem;
    [Range(0.0F, 10.0F)]
    [SerializeField] private float lootDistance;

    public static EnemyDrop I;
    
    private void Awake()
    {
        I = this;
    }
    
    [Serializable]
    private class Drops
    {
        public GameObject prefab;
        public int chance; //TODO; implement chances
    }

    public void DropOnDeath(Transform dyingEnemyPos)
    {
        foreach (var droppable in drops)
        {
            var angle = Random.Range(0f, 360f);
            var distance = Random.Range(0f, lootDistance);
            var drop = Instantiate(droppable.prefab);
            var randomizePos = Quaternion.AngleAxis(angle, Vector3.back) * Vector3.right * distance;
            drop.transform.position = dyingEnemyPos.position + randomizePos;
        }
    }
}
