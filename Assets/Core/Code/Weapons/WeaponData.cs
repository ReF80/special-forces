using UnityEngine;

namespace Core.Code
{
	[CreateAssetMenu(fileName = "DefaultWeapon", menuName = "SO/Weapons/" + nameof(WeaponData))]
	public class WeaponData : ScriptableObject
	{
		[SerializeField]
		private int _magazineSize = 30; 
		[SerializeField]
		private int _maxAmmo = 120; 
		[SerializeField]
		private float _reloadTime = 1f;
		[SerializeField]
		private float _bulletSpread;
	}
}