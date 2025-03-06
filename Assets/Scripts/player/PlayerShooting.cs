using System;
using Trader;
using UnityEngine;

namespace player
{
    public class PLayerShooting : MonoBehaviour
    {
        [SerializeField] public Transform firePoint;
        [SerializeField] private Player player;
        [SerializeField] private Trade trade;

        public event Action OnFire;

        private void Update()
        {
        
            if (Input.GetButtonDown("Fire1") && Pause.IsPaused == false && player.shoot.isReloading == false && trade.isTrading == false)
            {
                player.AnimationFire(player.shoot.currentAmmo);
                player.shoot.StartShooting(firePoint);
                OnFire?.Invoke();
            }
        
            if (player.shoot.isReloading)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.R) && player.shoot.currentAmmo < player.shoot.maxAmmo)
            {
                StartCoroutine(player.shoot.Reload());
            }
        }
    }
}
