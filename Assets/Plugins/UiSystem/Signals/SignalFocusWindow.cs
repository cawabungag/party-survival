using SimpleUi.Interfaces;

namespace SimpleUi.Signals
{
	public class SignalFocusWindow
	{
		public IWindow Window;

		public SignalFocusWindow(IWindow window)
		{
			Window = window;
		}
	}
}