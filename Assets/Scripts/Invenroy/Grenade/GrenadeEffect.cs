using System;
using UnityEngine;

namespace player
{
    public class GrenadeEffect : MonoBehaviour
    {
        [SerializeField] 
        private Animator animator;
        [SerializeField] 
        private AudioSource audioSource;

        [SerializeField] private float delayDestroy = 2f;
        private void Start()
        {
            animator.Play("New Animation");
            audioSource.Play();
            Destroy(gameObject,delayDestroy);
        }
    }
}