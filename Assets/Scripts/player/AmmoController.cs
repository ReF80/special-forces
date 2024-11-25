using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    [SerializeField] public Text ammoText;
    [SerializeField] public PLayerShooting pLayerShooting;
    [SerializeField] public Player player;
    
    private void Update() => UpdateAmmoCounter();

    public void UpdateAmmoCounter()
    {
        if (pLayerShooting != null && ammoText != null)
        {
            ammoText.text = player.shoot.currentAmmo + " / " + player.shoot.reservAmmo;
        }
    }
}
