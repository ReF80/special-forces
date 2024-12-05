using player;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Code
{
	public class LiveEntity : MonoBehaviour, IDamageable
	{
		[SerializeField]
		private Health _health;

		public event UnityAction OnDeath;
		
		public void TakeDamage(float damage)
		{
			_health.Remove(damage);
			if (_health.IsDead)
			{
				OnDeath?.Invoke();
			}
		}
	}
}