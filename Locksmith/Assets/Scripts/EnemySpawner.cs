using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("In seconds")]
    [SerializeField] private int waveCDMax;
    [Tooltip("Rolls a d100 this many times")]
    [SerializeField] private int waveSpawnAttempt;
    
    // TODO; make this more easy to adjust by visual squares or colliders with only purpose of giving coordinates
    [SerializeField] private Vector2 fieldMin;
    [SerializeField] private Vector2 fieldMax;
    [SerializeField] private float minSpawnDistance;
    
    [SerializeField] public Spawnable[] spawnableEnemies;
    
    private Transform _playerTransform;
    private float _waveCd;
    private GameObject[] _currentlyActiveEnemies;


    private void Awake()
    {

        _playerTransform = GameManager.I.Player.transform; // game manager olunca bunu güzelleştirelim
        _currentlyActiveEnemies = new GameObject[] { };
    }

    void Start()
    {
        _waveCd = waveCDMax;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        _waveCd -= 1 * Time.fixedDeltaTime;
        if (_waveCd < 0)
        {
            _waveCd = waveCDMax;
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < waveSpawnAttempt; i++)
        {
            var roll = UnityEngine.Random.Range(0f, 100f);
            Debug.Log("rolled for: " + roll);
            foreach (var spawnable in spawnableEnemies)
            {
                if (spawnable.chance > roll)
                {
                    // TOOD; they have a limit of some sorts.

                    var spawnedEnemy = GameObject.Instantiate(spawnable.enemy);
                    spawnedEnemy.transform.position = getCool420Positionfkyea();
                    Debug.Log("spawned enemy in position" + spawnedEnemy.transform.position);
                    _currentlyActiveEnemies.Append(spawnedEnemy);
                }
            }

        }
    }

    private Vector3 getCool420Positionfkyea()
    {
        // TODO; if they spawn on blocks, don't
        // TODO; they dont spawn just around character
        var playerPos = _playerTransform.position;
        var spawnPos = new Vector3(Random.Range(fieldMin.x, fieldMax.x), Random.Range(fieldMin.y, fieldMax.y));
        var playerToSpawnPos = spawnPos - playerPos;
        while (playerToSpawnPos.magnitude < minSpawnDistance)
        {
            spawnPos += playerToSpawnPos.normalized * minSpawnDistance;
            playerToSpawnPos = spawnPos - playerPos;
            Debug.Log("spawn pos adjustement");
        }
        // check for if in limits
        
        return spawnPos;
    }
}

[Serializable]
public class Spawnable
{
    public GameObject enemy;
    [Tooltip("%chance for these to spawn each wave when a d100 is rolled")]
    public float chance; // Can't make this a private with a getter and setter.
}