using UnityEngine;
using UnityEngine.Serialization;

namespace Trader
{
    public class Trade: MonoBehaviour
    {
        [SerializeField] public GameObject panel;
        public bool isTrading = false;
        
        public void Trading()
        {
            isTrading = true;
            Time.timeScale = 0f; 
            panel.SetActive(true);
        }

        public void ExitTrade()
        {
            isTrading = false;
            Time.timeScale = 1f; 
            panel.SetActive(false);
        }
    }
}