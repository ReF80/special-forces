using System;

namespace Core.Code
{
	[Serializable]
	public class WeaponData
	{
		public int MagazineSize = 30; 
		public int MaxAmmo = 120; 
		public float ReloadTime = 1f;
		public float BulletSpread = 0f;
		public float TimeBetweenShots = 0.2f;
	}
}