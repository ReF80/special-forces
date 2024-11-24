using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    [SerializeField] public Text ammoText;
    [SerializeField] public PLayerShooting pLayerShooting;
    [SerializeField] public Shoot Shoot;
    
    private void Update() => UpdateAmmoCounter();

    public void UpdateAmmoCounter()
    {
        if (pLayerShooting != null && ammoText != null)
        {
            ammoText.text = Shoot.currentAmmo + " / " + Shoot.reservAmmo;
        }
    }
}
