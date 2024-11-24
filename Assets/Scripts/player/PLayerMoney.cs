using System;
using UnityEngine;
using UnityEngine.UI;

namespace player
{
    public class PLayerMoney : MonoBehaviour
    {
        [SerializeField] public Text moneyText;
        public Player player;

        public void Update()
        {
            moneyText.text = player.money.Value.ToString();
        }
    }
}