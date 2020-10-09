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
			InstallWindows();
			InstallCamera();
		}

		private void InstallCamera()
		{
			Container.BindInterfacesTo<Camera>().FromInstance(_camera);
		}

		private void InstallWindows()
		{
			Container.BindWindow<InputWindow>();
		}
	}
}