using player;
using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    [SerializeField] public Text ammoText;
    [SerializeField] public PLayerShooting pLayerShooting;
    [SerializeField] public Player player;

    private void Start()
    { 
        pLayerShooting.OnFire += UpdateAmmoCounter;
        player.shoot.OnReload += UpdateAmmoCounter;
    } 

    private void UpdateAmmoCounter()
    {
        if (pLayerShooting != null && ammoText != null)
        {
            ammoText.text = player.shoot.currentAmmo + " / " + player.shoot.reservAmmo;
        }
    }
}
