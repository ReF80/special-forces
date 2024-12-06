using System;

namespace Core.Code
{
	[Serializable]
	public class BulletInstance
	{
		private BulletPreset _bulletPreset;
		
		public void SetBullet(BulletPreset bulletPreset)
		{
			_bulletPreset = bulletPreset;
		}
	}
}