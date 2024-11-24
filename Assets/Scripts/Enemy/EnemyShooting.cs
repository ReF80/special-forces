using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Shoot shoot;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _shootingRange = 3f; 
    [SerializeField] private float _shootDelay = 1f;
    
    public Transform player;
    public Transform firePoint;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < _shootingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, _moveSpeed * Time.deltaTime);
        }
    }
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        StartCoroutine(Fire());
    }
    
    IEnumerator Fire()
    {
        while (true)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= _shootingRange) 
            {
                shoot.Shooting(firePoint);
                yield return new WaitForSeconds(_shootDelay); 
            }
            else
            {
                yield return null; 
            }
        }
    }
    
    void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= _shootingRange)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
        }
    }
}