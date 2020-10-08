using SimpleUi.Interfaces;

namespace SimpleUi.Signals
{
	public class SignalCloseWindow
	{
		public IWindow Window;

		public SignalCloseWindow(IWindow window)
		{
			Window = window;
		}
	}
}