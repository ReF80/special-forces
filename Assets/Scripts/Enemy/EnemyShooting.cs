using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] 
    private Shoot shoot;
    [SerializeField] 
    private float shootDelay = 1f;
    
    public Transform player;
    public Transform firePoint;

    [SerializeField] private int viewAngle = 90;
    [SerializeField] private float viewDistance = 10;
    [SerializeField] private int stoppingDistance = 2;
    [SerializeField] private float rotationSpeed = 1;
    private bool playerInSight = false;

    public NavMeshAgent agent;

    private void Update()
    {
        CheckFieldOfView();
        if (playerInSight) {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer > stoppingDistance) {
                agent.SetDestination(player.position);
            } else {
                agent.SetDestination(transform.position); // Остановить движение
            }
            FacePlayer();
            StartCoroutine(Fire());
        } else {
            //agent.SetDestination(transform.position); // Остановить движение
        }
    }

    private void CheckFieldOfView() {
        var directionToPlayer = (player.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        if (angle <= viewAngle / 2) {
            if (Physics.Raycast(transform.position, directionToPlayer, out var hit, viewDistance))
            {
                playerInSight = hit.collider.gameObject == player.gameObject;
            } else {
                playerInSight = false;
            }
        } else {
            playerInSight = false;
        }
    }
    
    private void Start() => player = GameObject.FindGameObjectWithTag("Player").transform; 
    
    private IEnumerator Fire()
    {
        shoot.Shooting(firePoint);
        yield return new WaitForSeconds(shootDelay); 
    }

    private void FacePlayer() {
        var directionToPlayer = (player.position - transform.position).normalized;
        var desiredRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
}