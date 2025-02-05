using Trader;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    [SerializeField]  AudioSource moveSound;
    [SerializeField] Vector2 moveVector;
    [SerializeField] public Trade trade;

    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        if (moveVector.x > 0 || moveVector.x < 0 || moveVector.y > 0 || moveVector.y < 0)
        {
            if (moveSound.isPlaying) return;
            moveSound.Play();
        }
        else
        {
            moveSound.Stop();
        }
    }
  
}
