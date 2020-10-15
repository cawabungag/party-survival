using SimpleUi;
using SimpleUi.Signals;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		[SerializeField] private EWindowLayer windowLayer;

		public override void InstallBindings()
		{
			SignalBusInstaller.Install(Container);
			Container.BindUiSignals(windowLayer);
			Container.BindWindowsController<WindowsController>(EWindowLayer.Local);
		}
	}
}