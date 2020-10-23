using DB.Units;
using Ecs.Game;
using SimpleUi.Signals;
using UI.Game.Windows;
using UnityEngine;
using Zenject;

public class GameWindowManager : IInitializable
{
	private readonly SignalBus _signalBus;
	private readonly GameContext m_gameContext;

	public GameWindowManager(SignalBus signalBus, GameContext gameContext)
	{
		_signalBus = signalBus;
		m_gameContext = gameContext;
	}

	public void Initialize()
	{
		_signalBus.OpenWindow<InputWindow>();
		m_gameContext.CreateUnit(EObjectType.Unit, Vector3.zero);
	}
}