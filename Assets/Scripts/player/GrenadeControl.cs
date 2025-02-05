using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace player
{
    public class GrenadeControl : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] public Player player;

        public void AmountController()
        {
            text.text = player.grenadeAmount.ToString();
        }
        
    }
}