using UnityEngine;

public abstract class PickUpBase : MonoBehaviour
{
    protected abstract IItem Item { get; }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Inventory inventory))
        {
            if (inventory.TryAddItem(Item))
            {
                Destroy(gameObject);
            }
        }
    }   
}