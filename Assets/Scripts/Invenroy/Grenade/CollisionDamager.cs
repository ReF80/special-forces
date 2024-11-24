using UnityEngine;

public class CollisionDamager : MonoBehaviour
{
    [SerializeField] public float _damageAmount = 10f;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out IAlive alive))
        {
            //alive.Health.Remove(_damageAmount);
        }
    }
}