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
    
    [SerializeField] public int reservAmmo; 
    [SerializeField] public int maxAmmo = 10; 
    [SerializeField] public int currentAmmo = 10; 
    [SerializeField] public Text ammoText;
    [SerializeField] public AudioSource fireSound;
    [SerializeField] public AudioSource reloadSound;
    [SerializeField] public bool isReloading = false;
    
    public void UpdateAmmoCounter()
    {
        ammoText.text = currentAmmo + " / " + reservAmmo;
    }
    
    public void StartShooting(Transform firePoint)
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            Debug.Log("Player patrons " + currentAmmo);
            //ammoText.text = currentAmmo + " / " + reservAmmo;
            UpdateAmmoCounter();
            Shooting(firePoint);
        }
    }
    
    public void Shooting(Transform firePoint)
    {
        fireSound.Play();
        GameObject bullet = Object.Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
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
                //ammoText.text = currentAmmo + " / " + reservAmmo;
                UpdateAmmoCounter();
            }
            else
            {
                currentAmmo += reservAmmo;
                reservAmmo = 0;
                //ammoText.text = currentAmmo + " / " + reservAmmo;
                UpdateAmmoCounter();
            }
        }
        shootAmmo = 0;
        isReloading = false;
        Debug.Log("End reload. Patrons: " + currentAmmo);
    }

    public void AddAmmo(int amount)
    {
        reservAmmo += amount;
        //ammoText.text = currentAmmo + " / " + reservAmmo;
        UpdateAmmoCounter();
    }
}
