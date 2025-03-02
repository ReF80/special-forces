using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace player
{
    [Serializable]
    public class Health
    {
        [field: SerializeField]
        public float Value { get; private set; } = 100f;
        
        [field: SerializeField]
        [field: Range(0.01f, 1000f)]
        public float MaxValue { get; set; } = 100f;
        
        [field: SerializeField]
        public float MinValue { get; set; } = 0f;
        public event Action OnHit;
        public event Action OnDeath;

        public bool IsDead;
        
        public void Add(float amount)
        {
            float newValue = Value + amount;
            if (newValue > MaxValue)
            {
                newValue = MaxValue;
            }
            Value = newValue;
        }

        public void Remove(float amount)
        {
            float newValue = Value - amount;
            if (newValue < MinValue)
            {
                IsDead = true;
                OnDeath?.Invoke();
            }
            Value = newValue;
            OnHit?.Invoke();
        }
    }
}