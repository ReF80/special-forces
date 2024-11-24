using System.Collections;
using System.Collections.Generic;
using Trader;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PLayerShooting : MonoBehaviour
{
    [SerializeField] public Transform firePoint;
    [SerializeField] private Shoot Shoot;
    [SerializeField] private Trade trade;

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && Pause.isPaused == false && Shoot.isReloading == false && trade.isTrading == false)
        {
            GetComponent<Player>().AnimationFire(Shoot.currentAmmo);
            Shoot.StartShooting(firePoint);
        }
        
        if (Shoot.isReloading)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R) && Shoot.currentAmmo < Shoot.maxAmmo)
        {
            StartCoroutine(Shoot.Reload());
        }
    }
}
