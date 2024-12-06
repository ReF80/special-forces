using UnityEngine;

namespace Core.Code.Actions
{
	public class DestroyAction : MonoBehaviour
	{
		public void Invoke()
		{
			Destroy(gameObject);
		}
	}
}