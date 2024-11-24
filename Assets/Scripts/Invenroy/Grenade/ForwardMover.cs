using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    private void FixedUpdate()
    {
        transform.position = transform.forward * _speed;
    }
}