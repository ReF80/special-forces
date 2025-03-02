using UnityEngine;
using UnityEngine.UI;

namespace Trader
{
    public class MoneyController : MonoBehaviour
    {
        [SerializeField] private Text moneyAmoutText;
        public Player player;

        private void Start()
        {
            player.money.UpdateMoney += Controller;
        }
        private void Controller() => moneyAmoutText.text = player.money.Value.ToString();
    }
}