using System;
using Ecs.Core.Bootstrap;
using Entitas;
using Zenject;

namespace Ecs.Installers
{
	public abstract class AEcsInstaller : MonoInstaller, IDisposable
	{
		public override void InstallBindings()
		{
			Container.Bind<IDisposable>().FromInstance(this).AsTransient();

			var contexts = Contexts.sharedInstance;
			Container.BindInstance(contexts).WhenInjectedInto<MainBootstrap>();
			Container.BindInterfacesTo<MainBootstrap>().AsSingle().WithArguments(gameObject.name).NonLazy();
			InstallSystems();
		}

		protected void BindContextFromInstance<TContext>(TContext context)
			where TContext : IContext
		{
			Container.BindInterfacesAndSelfTo<TContext>().FromInstance(context).AsSingle();
		}

		protected abstract void InstallSystems();

		public void Dispose()
		{
		}
	}
}