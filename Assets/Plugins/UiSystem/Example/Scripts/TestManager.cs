using SimpleUi.Signals;
using Zenject;

namespace Example
{
	public class TestManager : IInitializable
	{
		private readonly SignalBus _signalBus;

		public TestManager(
			SignalBus signalBus
		)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			_signalBus.OpenWindow("First");
		}
	}
}