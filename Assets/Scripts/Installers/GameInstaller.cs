using Ecs.Core.Impls;
using Ecs.Game.Camera;
using Services.Items.Impls;
using Services.Unit.Impls;
using Services.Unit.Impls.Strategies;
using UI.Game.Windows;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class GameInstaller : MonoInstaller
	{
		[SerializeField] private CameraView _camera;

		public override void InstallBindings()
		{
			BindWindows();
			BindCamera();
			BindServices();
			BindStrategies();
			BindFactories();
		}

		private void BindCamera()
		{
			Container.BindInterfacesTo<CameraView>().FromInstance(_camera);
		}

		private void BindWindows()
		{
			Container.BindInterfacesTo<GameWindowManager>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<InputWindow>().AsSingle();
		}

		private void BindServices()
		{
			Container.BindInterfacesTo<ItemService>().AsSingle();
		}

		private void BindStrategies()
		{
			Container.BindInterfacesTo<InstantiateUnitStrategy>().AsSingle();
			Container.BindInterfacesTo<InstantiateEnemyStrategy>().AsSingle();
		}

		private void BindFactories()
		{
			Container.BindInterfacesTo<UnitFactory>().AsSingle();
		}
	}
}