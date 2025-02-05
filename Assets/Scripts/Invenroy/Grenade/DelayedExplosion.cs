using System.Collections;
using UnityEngine;

public class DelayedExplosion : MonoBehaviour
{
    [SerializeField]
    private float blastRadius = 2f;
    [SerializeField]
    private float blastForce = 500f;
    [SerializeField]
    private float damage = 25f;
    [SerializeField]
    private float delayDestroy = 1f;
    [SerializeField] 
    private float delayExplosion = 3f;

    [SerializeField] 
    private SpriteRenderer spriteRenderer;

    [SerializeField] 
    private GameObject exploreEffect;
    
    void Start()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(delayExplosion);
        ExplodeGrenade();
    }

    void ExplodeGrenade()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius);

        foreach (Collider2D other in colliders)
        {
            if (other.gameObject.TryGetComponent(out IAlive alive))
            {
                alive.TakeDamage(damage);
            }
        }

        spriteRenderer.sprite = null;
        Instantiate(exploreEffect, transform.position, transform.rotation);
        Destroy(gameObject, delayDestroy);
    }
}