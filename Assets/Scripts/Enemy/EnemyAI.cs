using System;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public Transform player; // Ссылка на игрока

    private NavMeshAgent navAgent;
    public float viewDistance = 15f; // Дистанция видимости
    public float viewAngle = 60f; // Угол видимости (в градусах)
    public LayerMask obstacleLayer; // Слой препятствий
    private bool isPlayerVisible = false;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateUpAxis = false;
        navAgent.updateRotation = false;
    }

    // private void Update()
    // {
    //     ChasePlayer();
    // }

    void Update()
    {
        if (IsPlayerInSight())
        {
            isPlayerVisible = true;
            ChasePlayer();
        }
        else
        {
            isPlayerVisible = false;
            StopChasing();
        }
    }
    
    bool IsPlayerInSight()
    {
        // if (!player) return false;
        //
        // var directionToPlayer = player.position - transform.position;
        // float distanceToPlayer = directionToPlayer.magnitude;
        //
        // if (distanceToPlayer > viewDistance) return false;
        //
        // float angle = Vector3.Angle(transform.forward, directionToPlayer);
        // if (angle > viewAngle / 2) return false;
        //
        // if (Physics.Raycast(transform.position, directionToPlayer.normalized, distanceToPlayer, obstacleLayer))
        // {
        //     return false; // Игрок не виден из-за препятствий
        // }
        //
        return true; // Игрок в поле зрения
    }
    
    void ChasePlayer()
    {
        navAgent.SetDestination(player.position); // Враг движется к игроку
    }
    
    void StopChasing()
    {
        navAgent.ResetPath(); // Останавливаем движение
    }
}