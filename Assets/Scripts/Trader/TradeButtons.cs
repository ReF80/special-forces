using UnityEngine;
using UnityEngine.Serialization;

namespace Trader
{
    public class TradeButtons : MonoBehaviour
    {
        [SerializeField] private AmmoData ammoData1;
        [SerializeField] private AmmoData ammoData2;
        [SerializeField] private MedkitData medkitData;
        [SerializeField] private MedkitData bandageData;
        //[SerializeField] private GrenadeData grenadeData;
        [SerializeField] private EnergyTabletsData energyTabletsData;
        
        public int medkitPrice = 15;
        public int bandagePrice = 7;
        public int ammo1Price = 10;
        public int ammo2Price = 15;
        public int grenadePrice = 20;
        public int energyTabletsPrice = 10;
        
        
        public Inventory inventory;
        public Player player;

        public void BuyAmmo1Buton()
        {
            if (player.money.Value >= ammo1Price)
            {
                inventory.TryAddItem(ammoData1);
                player.money.RemoveMoney(ammo1Price);
            }
        }
        
        public void BuyAmmo2Buton()
        {
            if (player.money.Value >= ammo2Price)
            {
                inventory.TryAddItem(ammoData2);
                player.money.RemoveMoney(ammo2Price);
            }
        }
        
        public void BuyMedkitButon()
        {
            if (player.money.Value >= medkitPrice)
            {
                inventory.TryAddItem(medkitData);
                player.money.RemoveMoney(medkitPrice);
            }
        }
        
        public void BuyBandageButon()
        {
            if (player.money.Value >= bandagePrice)
            {
                inventory.TryAddItem(bandageData);
                player.money.RemoveMoney(bandagePrice);
            }
        }
        
        public void BuyGrenadeButon()
        {
            if (player.money.Value >= grenadePrice)
            {
                //inventory.TryAddItem(grenadeData);
                player.money.RemoveMoney(grenadePrice);
            }
        }
        
        public void BuyEnergyTabletsButon()
        {
            if (player.money.Value >= energyTabletsPrice)
            {
                inventory.TryAddItem(energyTabletsData);
                player.money.RemoveMoney(energyTabletsPrice);
            }
        }
    }
}