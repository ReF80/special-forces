using UnityEngine;

namespace Invenroy.Grenade
{
	public class DestroyAction : MonoBehaviour
	{
		public void Invoke()
		{
			Destroy(gameObject);
		}
	}
}