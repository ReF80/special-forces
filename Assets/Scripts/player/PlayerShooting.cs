using System.Collections;
using System.Collections.Generic;
using Trader;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PLayerShooting : MonoBehaviour
{
    [SerializeField] public Transform firePoint;
    [SerializeField] private Player player;
    [SerializeField] private Trade trade;

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && Pause.isPaused == false && player.shoot.isReloading == false && trade.isTrading == false)
        {
            GetComponent<Player>().AnimationFire(player.shoot.currentAmmo);
            player.shoot.StartShooting(firePoint);
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
