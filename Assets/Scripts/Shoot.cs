using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

[Serializable]
public class Shoot
{
    [field: SerializeField] 
    public GameObject bulletPref;
    
    [field: SerializeField] 
    public float bulletForce = 20f;

    [SerializeField] private int shootAmmo; 
    [SerializeField] private float reloadTime = 1f;
    [SerializeField] private bool isPauseShoot;
    
    [SerializeField] public int reservAmmo = 30; 
    [SerializeField] public int maxAmmo = 10; 
    [SerializeField] public int currentAmmo = 10; 
    [SerializeField] public AudioSource fireSound;
    [SerializeField] public AudioSource reloadSound;
    [SerializeField] public bool isReloading = false;

    public event Action OnReload;
    
    public void StartShooting(Transform firePoint)
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            Debug.Log("Player patrons " + currentAmmo);
            Shooting(firePoint);
        }
    }
    
    public void Shooting(Transform firePoint)
    {
        fireSound.Play();
        var bullet = Object.Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    
    public IEnumerator Reload()
    {
        shootAmmo = maxAmmo - currentAmmo;
        isReloading = true;
        Debug.Log("Reload...");
        reloadSound.Play();
        yield return new WaitForSeconds(reloadTime);
       
        if (currentAmmo < maxAmmo)
        {
            if(reservAmmo >= shootAmmo)
            {
                currentAmmo += shootAmmo;
                reservAmmo -= shootAmmo;
            }
            else
            {
                currentAmmo += reservAmmo;
                reservAmmo = 0;
            }
        }
        shootAmmo = 0;
        isReloading = false;
        Debug.Log("End reload. Patrons: " + currentAmmo);
        OnReload?.Invoke();
    }

    public void AddAmmo(int amount)
    {
        reservAmmo += amount;
        OnReload?.Invoke();
    }
}
