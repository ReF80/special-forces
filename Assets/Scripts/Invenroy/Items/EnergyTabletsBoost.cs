using System;
using UnityEngine;

namespace player
{
    public class EnergyTabletsBoost : MonoBehaviour
    {
        [SerializeField] public float actionTime = 20f;
        public Player player;

        public void Boost(int value)
        {
            float elapsedTime = 0f;
            player.speed += value;
            while (elapsedTime < actionTime)
            {
                elapsedTime += Time.deltaTime;
            }

            player.speed -= value;
        }
    }
}