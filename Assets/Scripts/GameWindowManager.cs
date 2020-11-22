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
		_gameContext.CreateUnit(EObjectType.Unit, new Vector3(1f, -2, 1f));
		_gameContext.CreateUnit(EObjectType.Unit, new Vector3(-1f, -2, -1f));
		_gameContext.CreateEnemy(EObjectType.ZombieUnit, new Vector3(0, 10,0));
		_itemContext.CreateWeapon(EWeaponType.AK47, new Vector3(-6, 6, 0));
		/*_itemContext.CreateWeapon(EWeaponType.M4A1, new Vector3(-4, 6, 0));
		_itemContext.CreateWeapon(EWeaponType.UMP45, new Vector3(-2, 6, 0));
		_itemContext.CreateWeapon(EWeaponType.SkorpionVz, new Vector3(-0, 6, 0));
		_itemContext.CreateWeapon(EWeaponType.DesertEagle, new Vector3(2, 6, 0));
		_itemContext.CreateWeapon(EWeaponType.Magnim500, new Vector3(4, 6, 0));
		_itemContext.CreateWeapon(EWeaponType.GlockG22, new Vector3(6, 6, 0));*/
	}
}