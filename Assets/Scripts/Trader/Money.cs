using System;
using UnityEngine;

namespace Trader
{
    [Serializable]
    public class Money
    {
        [field: SerializeField] 
        public int minValue = 0;

        [field: SerializeField] 
        public int Value { get; private set; } = 10;

        public event Action UpdateMoney;
        
        public void AddMoney(int amount)
        {
            Value += amount;
            UpdateMoney?.Invoke();
        }

        public void RemoveMoney(int amount)
        {
            int newValue = Value - amount;
            if (newValue < minValue)
            {
                Debug.Log("not enough money");
                newValue = Value;
                UpdateMoney?.Invoke();
            }
            Value = newValue;
        }
    }
}
