using UnityEngine;
using UnityEngine.Events;

namespace Core.Code.Actions
{
	public abstract class ActionInvoker : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent _event;

		protected void InvokeAction()
		{
			_event.Invoke();
		}
	}
}