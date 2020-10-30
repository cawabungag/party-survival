using DB.Units;
using DB.Weapons;
using Ecs.Game;
using Entitas;
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
		m_gameContext.CreateUnit(EObjectType.Unit, new Vector3(1.5f, 0, 1.5f));
		m_gameContext.CreateUnit(EObjectType.Unit, new Vector3(-1.5f, 0, -1.5f));
		m_gameContext.CreateEnemy(EObjectType.ZombieUnit, Vector3.zero);
		m_gameContext.CreateWeapon(EWeaponType.AK47, Vector3.zero);

	}
}