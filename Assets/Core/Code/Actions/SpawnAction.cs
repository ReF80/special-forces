using UnityEngine;

namespace Core.Code.Actions
{
	public class SpawnAction : MonoBehaviour
	{
		[SerializeField]
		private GameObject _prefab;

		public void Invoke()
		{
			Instantiate(_prefab, transform.position, Quaternion.identity);
		}
	}
}