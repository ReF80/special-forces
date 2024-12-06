using UnityEngine;

namespace Core.Code
{
	[CreateAssetMenu(fileName = "DefaultBullet", menuName = "SO/Weapons/" + nameof(BulletPreset))]
	public class BulletPreset : ScriptableObject
	{
		[SerializeField]
		private BulletData _data;
		public BulletData Data => _data;

		[SerializeField]
		private Sprite _sprite;
		public Sprite Sprite => _sprite;
	}
}