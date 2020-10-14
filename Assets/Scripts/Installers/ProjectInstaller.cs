using SimpleUi;
using SimpleUi.Signals;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindUiSignals(EWindowLayer.Project);
			Container.BindWindowsController<WindowsController>(EWindowLayer.Project);
			SignalBusInstaller.Install(Container);
		}
	}
}