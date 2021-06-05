﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("In seconds")]
    [SerializeField] private int waveCDMax;
    [Tooltip("Rolls a d100 this many times")]
    [SerializeField] private int waveSpawnAttempt;
    
    // TODO; make this more easy to adjust by visual squares or colliders with only purpose of giving coordinates
    [SerializeField] private Bounds spawnBounds;
    [SerializeField] private float minSpawnDistance;
    
    [SerializeField] private Spawnable[] spawnableEnemies;
    [SerializeField] private int enemyCountLimit;
    
    private Transform _playerTransform;
    private float _waveCd;
    private GameObject[] _currentlyActiveEnemies;
    public GameObject[] CurrentlyActiveEnemies => _currentlyActiveEnemies;


    public static EnemySpawner I;
    
    private void Awake()
    {
        I = this;
        _playerTransform = GameManager.Instance.Player.transform; // game manager olunca bunu güzelleştirelim
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
            foreach (var spawnable in spawnableEnemies)
            {
                if (!(spawnable.chance > roll)) continue;
                if (enemyCountLimit < _currentlyActiveEnemies.Length) continue;
                // TOOD; they have a limit of some sorts.
                var spawnedEnemy = GameObject.Instantiate(spawnable.enemy);
                spawnedEnemy.transform.position = GetCool420Positionfkyea();
                _currentlyActiveEnemies.Append(spawnedEnemy);
                Debug.Log("Current enemy amount: " + _currentlyActiveEnemies.Length);
            }
        }
    }

    private Vector3 GetCool420Positionfkyea(bool checkAgain=true)
    {
        // TODO; if they spawn on blocks, don't
        // TODO; they dont spawn just around character
        var playerPos = _playerTransform.position;
        var spawnPos = new Vector3(Random.Range(spawnBounds.min.x, spawnBounds.max.x),
            Random.Range(spawnBounds.min.y, spawnBounds.max.y));
        var playerToSpawnPos = spawnPos - playerPos;
        while (playerToSpawnPos.magnitude < minSpawnDistance)
        {
            spawnPos += playerToSpawnPos.normalized * minSpawnDistance;
            playerToSpawnPos = spawnPos - playerPos;
            Debug.Log("spawn pos adjustement");
        }
        // check for if in limits
        if (!spawnBounds.Contains(spawnPos))
        {
            // If spawn position is an illegal position, like out of bounds or touching a block,
            // we need to reroll or adjust.
            // For now, we try once again and if it is illegal again we give up.
            // TODO; better adjustment, check for if spawning on top of a block.
            Debug.Log("Out of bounds spawn detected.");
            if (checkAgain)
            {
                spawnPos = GetCool420Positionfkyea(false);
            }
        }
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