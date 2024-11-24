using UnityEngine;
using UnityEngine.Serialization;

public class DelayedExplosion : MonoBehaviour
{
    [SerializeField] public float damageAmount = 50f;
    [SerializeField] public float damageDelay = 10f;
    [SerializeField] public float damageRadius = 5f;
    [SerializeField] public Animator animator;
    [SerializeField] private GameObject grenadePref;

    private float _startTime;
    
    private void Start()
    {
        _startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time >= _startTime + damageDelay)
        {
            Explode();
        }
    }

    private void Explode()
    {
        animator.SetBool("Explode", true);
        var colliders = Physics.OverlapSphere(transform.position, damageRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IAlive alive))
            {
                alive.Health.Remove(damageAmount);
            }
        }
        Debug.Log("Explode is compl");
        animator.SetBool("Explode", false);
    }

    private void DestroyGrenade()
    {
        Destroy(grenadePref);
    }
}