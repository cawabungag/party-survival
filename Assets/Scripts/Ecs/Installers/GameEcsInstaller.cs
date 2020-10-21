using Ecs.Core.Extensions;
using Entitas.Generated.Installer;

namespace Ecs.Installers
{
	public class GameEcsInstaller : AEcsInstaller
	{
		protected override void InstallSystems()
		{
			var contexts = Contexts.sharedInstance;
			BindContextFromInstance(contexts.game);
			BindContextFromInstance(contexts.item);

			EcsGameSystems.Install(Container);

			Container.BindInterfacesTo<GameEventSystems>().FromInstance(new GameEventSystems(contexts)).AsSingle();
			Container.BindInterfacesTo<ItemEventSystems>().FromInstance(new ItemEventSystems(contexts)).AsSingle();

			Container.BindDestroyedCleanup<GameContext, GameEntity>(GameMatcher.EcsCommonComponentsDestroyed);
			Container.BindDestroyedCleanup<ItemContext, ItemEntity>(ItemMatcher.EcsCommonComponentsDestroyed);
		}
	}
}