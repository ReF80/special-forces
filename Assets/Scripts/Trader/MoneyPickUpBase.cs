using UnityEngine;

namespace Trader
{
    public class MoneyPickUpBase : MonoBehaviour
    {
        public Player player;
        [SerializeField] public GameObject moneyPrefab;
        [SerializeField] protected int nominal = 1;

        public void OnTriggerEnter2D(Collider2D other)
        {
            player.money.AddMoney(nominal);
            Destroy(moneyPrefab);
        }
    }
}