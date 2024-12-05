using UnityEngine;

namespace Core.Code
{
	[CreateAssetMenu(fileName = "EnemyData", menuName = "SO/EnemyData" + nameof(EnemyData))]
	public class EnemyData : ScriptableObject
	{
		[SerializeField]
		private WeaponData _weapon;
		[SerializeField]
		private BulletData _bullet;
	}
}
