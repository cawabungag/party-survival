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
		m_gameContext.CreateWeapon(EWeaponType.AK47, new Vector3(-6,-1,0));
	/*	m_gameContext.CreateWeapon(EWeaponType.M4A1, new Vector3(-12, -1, 0));
		m_gameContext.CreateWeapon(EWeaponType.UMP45, new Vector3(-10, -1, 0));
		m_gameContext.CreateWeapon(EWeaponType.SkorpionVz, new Vector3(-8, -1, 0));
		m_gameContext.CreateWeapon(EWeaponType.DesertEagle, new Vector3(-6, -1, 0));
		m_gameContext.CreateWeapon(EWeaponType.Magnim500, new Vector3(-4, -1, 0));
		m_gameContext.CreateWeapon(EWeaponType.GlockG22,new Vector3(-2, -1, 0));*/

	}
}