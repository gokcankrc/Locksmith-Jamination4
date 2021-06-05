using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class EnemyShooterAI : MonoBehaviour
{

    [SerializeField] Enemy entity;

    [SerializeField] private float attackRange;
    [SerializeField] private float detectionRange;
    [SerializeField] private float alertDistance;
    [SerializeField] private float attackCooldownMax;

    private AIState _state;
    private Vector3 initialPosition;
    private Vector3 randomVenture;
    private Vector3 playerPos;
    private float attackCooldown;



    enum AIState
    {
        Idle, Attacking, Chasing, Returning
    }
    
    private void Awake()
    {
        initialPosition = transform.position;
        SetNewRandomVenture();
    }


    private void FixedUpdate()
    {
        playerPos = GameManager.Instance.Player.transform.position;
        switch (_state)
        {
            // Attacking is literally during the attack. Exits state when attack ends
            case AIState.Attacking:
                AttackingUpdate();
                break;
            // Chase until close enough to attack. stop chasing if ventured too far away from initial position.
            case AIState.Chasing:
                ChasingUpdate();
                break;
            case AIState.Idle:
                IdleUpdate();
                break;
            // heal during returning, maybe, in the future
            case AIState.Returning:
                MoveTowards(initialPosition, 0.5f);
                if ((transform.position - initialPosition).magnitude < 1.5f)
                {
                    _state = AIState.Idle;
                }
                break;
        }
    }


    private void MoveTowards(Vector3 destination, float speedMultiplayer=1)
    {
        entity.MoveTowards(destination, 1);
    }

    private void ChasingUpdate()
    {
        if (CloseEnough(playerPos, attackRange))
        {
            // switch to attacking state
            MoveTowards(playerPos, 0f);
            _state = AIState.Attacking;
            attackCooldown = 0;
        }
        else
        {
            MoveTowards(playerPos);
        }
    }

    private void AttackingUpdate()
    {
        if (attackCooldown < 0)
        {
            entity.Attack(playerPos);
            attackCooldown = attackCooldownMax;
        }
        attackCooldown -= Time.fixedDeltaTime;
    }

    private void IdleUpdate()
    {
        // venture around randomly
        MoveTowards(randomVenture);
        if (CloseEnough(randomVenture))
        {
            SetNewRandomVenture();
        }
        
        // check if player is in detection range
        if (CloseEnough(playerPos, detectionRange))
        {
            // if in detection range; alert enemies around and switch state
            foreach (var enemyGO in EnemySpawner.I.CurrentlyActiveEnemies)
            {
                if (CloseEnough(enemyGO.transform.position, alertDistance))
                {
                    enemyGO.GetComponent<Enemy>().AI.Alert();
                }
            }
            _state = AIState.Chasing;
        }
    }
    private void SetNewRandomVenture()
    {
        randomVenture = Vector3.right * Random.Range(2, 5);
        randomVenture = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.back) * randomVenture;
    }

    private bool CloseEnough(Vector3 targetPos, float enoughDistance=1.5f)
    {
        var distance = Vector3.Distance(transform.position, targetPos);
        if (distance < enoughDistance) return true;
        else return false;
    }
    
    // oha 1 sn bu nasıl private oluyor!?
    private void Alert()
    {
        if (_state == AIState.Idle)
        {
            _state = AIState.Chasing;
        }
    }
}
