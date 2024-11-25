using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField]
    private float throwForce = 10f;

    [SerializeField] private GameObject grenadePrefab;
    public void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation); // Instantiate grenade prefab
        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>(); // Get Rigidbody component of the grenade

        // Calculate throw direction using mouse position
        Vector2 throwDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        // Apply throw force to the grenade
        rb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
    }
}