using Services.Items.Impls;
using SimpleUi;
using UI.Game.Windows;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class GameInstaller : MonoInstaller
	{
		[SerializeField] private Camera _camera;

		public override void InstallBindings()
		{
			BindWindows();
			BindCamera();
			BindServices();
		}

		private void BindCamera()
		{
			Container.BindInterfacesTo<Camera>().FromInstance(_camera);
		}

		private void BindWindows()
		{
			Container.BindWindow<InputWindow>();
		}

		private void BindServices()
		{
			Container.BindInterfacesTo<ItemService>().AsSingle();
		}
	}
}