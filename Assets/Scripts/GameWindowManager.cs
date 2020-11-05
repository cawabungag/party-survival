using DB.Units;
using DB.Weapons;
using Ecs.Game;
using SimpleUi.Signals;
using UI.Game.Windows;
using UnityEngine;
using Zenject;

public class GameWindowManager : IInitializable
{
	private readonly SignalBus _signalBus;
	private readonly GameContext _gameContext;
	private readonly ItemContext _itemContext;

	public GameWindowManager(SignalBus signalBus, GameContext gameContext, ItemContext itemContext)
	{
		_signalBus = signalBus;
		_gameContext = gameContext;
		_itemContext = itemContext;
	}

	public void Initialize()
	{
		_signalBus.OpenWindow<InputWindow>();
		_gameContext.CreateUnit(EObjectType.Unit, Vector3.zero);
		_gameContext.CreateUnit(EObjectType.Unit, new Vector3(1.5f, 0, 1.5f));
		_gameContext.CreateUnit(EObjectType.Unit, new Vector3(-1.5f, 0, -1.5f));
		_gameContext.CreateEnemy(EObjectType.ZombieUnit, Vector3.zero);
		_itemContext.CreateWeapon(EWeaponType.AK47, new Vector3(-6, -1, 0));
	}
}