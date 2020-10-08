using SimpleUi.Abstracts;
using UnityEngine;

namespace UI.Game.Input.Impls
{
	public class InputView : UiView, IInputView
	{
		[SerializeField] private FloatingJoystick _floatingJoystick;
		public FloatingJoystick Joystick => _floatingJoystick;
	}
}