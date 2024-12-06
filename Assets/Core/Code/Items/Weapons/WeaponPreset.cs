using UnityEngine;

namespace Core.Code
{
	[CreateAssetMenu(fileName = "DefaultWeapon", menuName = "SO/Weapons/" + nameof(WeaponPreset))]
	public class WeaponPreset : ScriptableObject
	{
		[SerializeField]
		private WeaponData _weaponData;
		public WeaponData WeaponData => _weaponData;

		[SerializeField]
		private Sprite _sprite;
	}
}