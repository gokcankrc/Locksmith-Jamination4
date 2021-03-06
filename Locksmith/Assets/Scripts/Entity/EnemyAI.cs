using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    
    [SerializeField] private float attackRange;
    [SerializeField] private float detectionRange;
    [SerializeField] private float alertDistance;
    [SerializeField] private float disengageDistance;
    [SerializeField] private float attackCooldownMax;
    [SerializeField] private float minCloseEnoughDistance;

    private EnemyEntity entity;
    [SerializeField]private AIState _state;
    private Vector3 initialPosition;
    private Vector3 randomVenture;
    private Vector3 playerPos;
    private float attackCooldown;

    public enum AIState
    {
        Idle, Attacking, Chasing, Returning
    }
    
    private void Awake()
    {
        _state = AIState.Idle;
        entity = GetComponent<EnemyEntity>();
    }

    private void Start()
    {        
        SetNewRandomVenture();
        initialPosition = transform.position;
    }


    private void FixedUpdate()
    {
        if (!GameManager.PlayerAlive) return;

        playerPos = GameManager.Instance.Player.transform.position;
        
        //Debug.Log(_state);
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
        entity.MoveTowards(destination, speedMultiplayer);
    }

    private void ChasingUpdate()
    {
        if (CloseEnough(playerPos, attackRange))
        {
            // switch to attacking state
            MoveTowards(playerPos, 0f);
            ChangeState(AIState.Chasing, AIState.Attacking);
            attackCooldown = 0;
        }
        else
        {
            MoveTowards(playerPos);
            //disengageDistance
        }
    }

    private void AttackingUpdate()
    {
        // TODO; determine a specific way to handle this cooldown case.
        // Oh btw, the cooldown on how to attack is determined here by cooldown from AI. In player, PlayerAttackerShooter
        // has cooldown implemented.
        if (attackCooldown < 0)
        {
            MoveTowards(playerPos, 0.00f);
            var direction = Vector3.SignedAngle(Vector3.right,playerPos - transform.position, Vector3.back);
            entity.Attack(direction);
            attackCooldown = attackCooldownMax;
        }
        attackCooldown -= Time.fixedDeltaTime;
    }

    private void IdleUpdate()
    {
        // venture around randomly
        Debug.DrawLine(transform.position, randomVenture, Color.magenta);
        MoveTowards(randomVenture, 0.3f);
        if (CloseEnough(randomVenture))
        {
            SetNewRandomVenture();
        }
        
        // check if player is in detection range
        if (CloseEnough(playerPos, detectionRange))
        {
            // if in detection range; alert enemies around and switch state
            foreach (var enemyGO in EnemyManager.I.CurrentlyActiveEnemies)
            {
                if ( CloseEnough(enemyGO.transform.position, alertDistance))
                // if (enemyGO && CloseEnough(enemyGO.transform.position, alertDistance))
                {
                    enemyGO.GetComponent<EnemyEntity>().AI.Alert();
                }
            }

            ChangeState(AIState.Idle, AIState.Chasing);
        }
    }

    public void ChangeState(AIState from, AIState to)
    {
        if (from != _state) return;
        _state = to;
    }

    private void SetNewRandomVenture()
    {
        randomVenture = Vector3.right * Random.Range(0.5f, 1.5f);
        randomVenture = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.back) * randomVenture;
        randomVenture += transform.position;
    }

    private bool CloseEnough(Vector3 targetPos, float enoughDistance=-1)
    {
        if (enoughDistance < 0)
        {
            enoughDistance = minCloseEnoughDistance;
        }
        var distance = Vector2.Distance(transform.position, targetPos);
        if (distance < enoughDistance) return true;
        else return false;
    }
    
    // oha 1 sn bu nasıl private oluyor!?
    private void Alert()
    {
        ChangeState(AIState.Idle, AIState.Chasing);
    }
}
