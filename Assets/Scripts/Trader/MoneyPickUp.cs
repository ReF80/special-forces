using System;
using UnityEngine;

namespace Trader
{
    public class MoneyPickUp : MonoBehaviour
    {
        public Player player;
        [SerializeField] public GameObject moneyPrefab;
        [SerializeField] protected int nominal;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            player.money.AddMoney(nominal);
            Destroy(moneyPrefab);
        }
    }
}
