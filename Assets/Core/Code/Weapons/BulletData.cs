using UnityEngine;

namespace Core.Code
{
	[CreateAssetMenu(fileName = "DefaultBullet", menuName = "SO/Weapons/" + nameof(BulletData))]
	public class BulletData : ScriptableObject
	{
		[SerializeField]
		private int _damage = 10;
		[SerializeField]
		private float _speed = 120;
		[SerializeField]
		private float _range = 100;
	}
}