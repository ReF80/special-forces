using System;
using UnityEngine;

namespace Core.Code.Actions
{
	public class KeyboardInputActionInvoker : ActionInvoker
	{
		[SerializeField]
		private KeyCode _keyCode;
		[SerializeField]
		private InputMode _inputMode;
		
		private void Update()
		{
			switch (_inputMode)
			{
				case InputMode.Hold:
					if (Input.GetKey(_keyCode))
					{
						InvokeAction();
					}
					break;
				case InputMode.Press:
					if (Input.GetKeyDown(_keyCode))
					{
						InvokeAction();
					}
					break;
				case InputMode.Release:
					if (Input.GetKeyUp(_keyCode))
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