using System;
using UnityEngine;

namespace Core.Code
{
	[Serializable]
	public class WeaponInstance
	{
		[SerializeField]
		private WeaponPreset _weaponPreset;
		public WeaponData WeaponData => _weaponPreset.WeaponData;

		[SerializeField]
		private WeaponState _weaponState;
		public WeaponState WeaponState => _weaponState;

		public bool HasMagazineAmmo => _weaponState.MagazineAmmoLeft > 0;
		public bool HasTotalAmmo => _weaponState.TotalAmmoLeft > 0;

		public void SetWeapon(WeaponPreset weaponPreset, WeaponState weaponState)
		{
			_weaponPreset = weaponPreset;
			_weaponState = weaponState;
		}
	}
}