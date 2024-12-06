using UnityEngine;

namespace Core.Code
{
	[CreateAssetMenu(fileName = "EnemyData", menuName = "SO/EnemyData" + nameof(EnemyData))]
	public class EnemyData : ScriptableObject
	{
		[SerializeField]
		private WeaponPreset _weaponToUse;
		
		[SerializeField]
		private BulletPreset _bulletsToShoot;
	}
}
