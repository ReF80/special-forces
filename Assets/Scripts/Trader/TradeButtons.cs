using Invenroy;
using UnityEngine;

namespace Trader
{
    public class TradeButtons : MonoBehaviour
    {
        [SerializeField] private AmmoData ammoData1;
        [SerializeField] private AmmoData ammoData2;
        [SerializeField] private MedkitData medkitData;
        [SerializeField] private MedkitData bandageData;
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
                Buy(ammoData1,ammo1Price);
            }
        }
        
        public void BuyAmmo2Buton()
        {
            if (player.money.Value >= ammo2Price)
            {
                Buy(ammoData2,ammo2Price);
            }
        }
        
        public void BuyMedkitButon()
        {
            if (player.money.Value >= medkitPrice)
            {
                Buy(medkitData,medkitPrice);
            }
        }
        
        public void BuyBandageButon()
        {
            if (player.money.Value >= bandagePrice)
            {
                Buy(bandageData, bandagePrice);
            }
        }
        
        public void BuyGrenadeButon()
        {
            if (player.money.Value >= grenadePrice)
            {
                player.grenadeAmount += 1;
                player.money.RemoveMoney(grenadePrice);
            }
        }
        
        public void BuyEnergyTabletsButon()
        {
            if (player.money.Value >= energyTabletsPrice)
            {
                Buy(energyTabletsData,energyTabletsPrice);
            }
        }

        private void Buy(IItem item, int value)
        {
            inventory.TryAddItem(item);
            player.money.RemoveMoney(value);
        }
    }
}