using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float distance;
    [SerializeField] public float damage;
    [SerializeField] public LayerMask whatIsSolid;

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().health.Remove(damage);
            }
            Destroy(gameObject);
            if(hitInfo.collider.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<Player>().health.Remove(damage);
            }
        }
    }
}
