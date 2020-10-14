using SimpleUi.Signals;
using UI.Game.Windows;
using Zenject;

public class GameWindowManager : IInitializable
{
	private readonly SignalBus _signalBus;

	public GameWindowManager(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public void Initialize()
	{
		_signalBus.OpenWindow<InputWindow>();
	}
}