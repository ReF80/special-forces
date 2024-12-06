using System;
using UnityEngine;

namespace Core.Code.Actions
{
	public class MouseInputActionInvoker : ActionInvoker
	{
		[SerializeField]
		private int _keyCode;
		[SerializeField]
		private InputMode _inputMode;
		
		private void Update()
		{
			switch (_inputMode)
			{
				case InputMode.Hold:
					if (Input.GetMouseButton(_keyCode))
					{
						InvokeAction();
					}
					break;
				case InputMode.Press:
					if (Input.GetMouseButtonDown(_keyCode))
					{
						InvokeAction();
					}
					break;
				case InputMode.Release:
					if (Input.GetMouseButtonUp(_keyCode))
					{
						InvokeAction();
					}
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}