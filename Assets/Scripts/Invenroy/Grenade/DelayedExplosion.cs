using System.Collections;
using UnityEngine;

namespace Invenroy.Grenade
{
    public class DelayedExplosion : MonoBehaviour
    {
        [SerializeField]
        private float _delayExplosion;
        [SerializeField]
        private float _delayDestroy = 1f;
        [SerializeField]
        private float _blastRadius = 2f;
        [SerializeField]
        private float _blastForce = 500f;
        [SerializeField]
        private float _damage = 25f;

        private void Start()
        {
            StartCoroutine(Explode());
        }

        private IEnumerator Explode()
        {
            yield return new WaitForSeconds(_delayExplosion);
            ExplodeGrenade();
        }

        private void ExplodeGrenade()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _blastRadius);

            foreach (Collider2D other in colliders)
            {
                if (other.gameObject.TryGetComponent(out IAlive alive))
                {
                    alive.TakeDamage(_damage);
                }
            }

            Destroy(gameObject, _delayDestroy);
        }
    }
}