using System;
using UnityEngine;
using UnityEngine.UI;

namespace player
{
    public class PLayerMoney : MonoBehaviour
    {
        [SerializeField] public Text moneyText;
        public Player player;

        private void Start() => player.money.UpdateMoney += UpdateMoneyText;
        private void UpdateMoneyText() => moneyText.text = player.money.Value.ToString();
    }
}