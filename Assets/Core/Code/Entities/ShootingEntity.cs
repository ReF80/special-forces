using System.Collections;
using UnityEngine;

namespace Core.Code
{
	public class ShootingEntity : MonoBehaviour
	{
		[SerializeField]
		private WeaponInstance _weapon;

		[SerializeField]
		private WeaponMuzzle _weaponMuzzle;

		public bool IsReloading { get; private set; }

		public bool CanShoot => false == IsReloading 
				&& _weapon.HasMagazineAmmo 
				&& Time.time >= _lastShotTime + _weapon.WeaponData.TimeBetweenShots;

		private float _lastShotTime;

		public void Shoot()
		{
			if (false == CanShoot)
			{
				Debug.LogError("Trying to shoot without ability to shoot!");
				return;
			}
			Debug.Log("Shooting...");
			ShootInternal();
		}

		private void ShootInternal()
		{
			_lastShotTime = Time.time;
			_weapon.WeaponState.MagazineAmmoLeft--;
			//Instantiate(bullet, _weaponMuzzle.transform.position, _weaponMuzzle.transform.up);
		}

		public bool CanReload =>
				false == IsReloading &&
				_weapon.WeaponState.TotalAmmoLeft > 0 &&
				_weapon.WeaponData.MagazineSize > _weapon.WeaponState.MagazineAmmoLeft;

		public void Reload()
		{
			if (false == CanReload)
			{
				Debug.LogError("Trying to reload without ability to reload!");
				return;
			}
			Debug.Log("Reloading...");
			IsReloading = true;
			StartCoroutine(ReloadInternal());
		}

		private IEnumerator ReloadInternal()
		{
			yield return new WaitForSeconds(_weapon.WeaponData.ReloadTime);
			FinishReload();
		}

		private void FinishReload()
		{
			int amountToReload = _weapon.WeaponData.MagazineSize - _weapon.WeaponState.MagazineAmmoLeft;
			if (_weapon.WeaponState.TotalAmmoLeft >= amountToReload)
			{
				_weapon.WeaponState.MagazineAmmoLeft = _weapon.WeaponData.MagazineSize;
				_weapon.WeaponState.TotalAmmoLeft -= amountToReload;
			}
			else
			{
				_weapon.WeaponState.MagazineAmmoLeft += _weapon.WeaponState.TotalAmmoLeft;
				_weapon.WeaponState.TotalAmmoLeft = 0;
			}
			IsReloading = false;
			Debug.Log("Reloaded!");
		}
	}
}