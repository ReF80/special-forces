using System.Collections;
using ModestTree;
using player;
using UnityEngine;
using UnityEngine.Serialization;

public class DelayedExplosion : MonoBehaviour
{
    public float blastRadius = 2f;
    public float blastForce = 500f;
    public float damage = 25f;
    [SerializeField]private Animator explodeAnimation;
    [SerializeField]private AudioSource explodeSound;
    private bool isExploded = false;

    void Start()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(5f);

        ExplodeGrenade();
    }

    void ExplodeGrenade()
    {
        if (isExploded) return;
        // explodeAnimation.Play("New Animation");
        // explodeSound.Play();
        isExploded = true;
        Debug.Log("VAR");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius);

        foreach (Collider2D other in colliders)
        {
            if (other.gameObject.TryGetComponent(out IAlive alive))
            {
                alive.TakeDamage(damage);
            }
        }

        Debug.Log("2");
        Destroy(gameObject);
    }
}