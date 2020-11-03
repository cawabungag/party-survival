using Ecs.Core.Impls;
using Ecs.Game.Camera;
using Game.Ai.Impls;
using Game.Ai.Tasks.Impls;
using Game.Ai.Tasks.Impls.Enemy;
using Game.Ai.Tasks.Impls.PlayerUnit;
using Services.Items.Impls;
using Services.Unit.Impls;
using Services.Unit.Impls.Strategies;
using Services.Weapone.Impls;
using Services.Weapone.Impls.Strategies;
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

			Container.BindInterfacesTo<AiTaskBuildersLibrary>().AsSingle();
			Container.BindInterfacesTo<BehaviourTreeFactory>().AsSingle();
			
			Container.BindInterfacesTo<UnityTimeProvider>().AsSingle();
			Container.BindInterfacesTo<UnityRandomProvider>().AsSingle();
		}

		private void BindStrategies()
		{
			Container.BindInterfacesTo<InstantiateUnitStrategy>().AsSingle();
			Container.BindInterfacesTo<InstantiateWeaponStrategy>().AsSingle();
		}

		private void BindFactories()
		{
			Container.BindInterfacesTo<UnitFactory>().AsSingle();
			Container.BindInterfacesTo<WeaponFactory>().AsSingle();

			//Ai task builder
			Container.BindInterfacesTo<WanderActionBuilder>().AsSingle();
			Container.BindInterfacesTo<FindClosestUnitsBuilder>().AsSingle();
			Container.BindInterfacesTo<GoToTargetActionBuilder>().AsSingle();
			Container.BindInterfacesTo<AttackActionBuilder>().AsSingle();
			Container.BindInterfacesTo<ItemDetectionBuilder>().AsSingle();
		}
	}
}