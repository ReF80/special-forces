using System.Collections;
using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToThrow;
    [SerializeField]
    private float throwForce = 10f;
    [SerializeField]
    private float maxDistance = 5f;

    public void Throw()
    {
        GameObject thrownObject = Instantiate(objectToThrow, transform.position, Quaternion.identity);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = (mousePosition - (Vector2)transform.position).normalized;
        thrownObject.GetComponent<Rigidbody2D>().velocity = throwDirection * throwForce;

        StartCoroutine(DistanceCheck(thrownObject));
    }

    private IEnumerator DistanceCheck(GameObject thrownObject)
    {
        Vector2 initialPosition = thrownObject.transform.position;
        float distance = 0f;

        while (distance < maxDistance)
        {
            distance = Vector2.Distance(thrownObject.transform.position, initialPosition);
            yield return null;
        }
        thrownObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}