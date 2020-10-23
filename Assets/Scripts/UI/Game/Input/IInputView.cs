using Plugins.Joystick_Pack.Scripts.Joysticks;

namespace UI.Game.Input
{
	public interface IInputView
	{
		FloatingJoystick Joystick { get; }
	}
}