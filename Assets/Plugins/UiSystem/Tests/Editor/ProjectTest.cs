using NUnit.Framework;
using SimpleUi.Signals;
using Tests.Abstracts;
using Zenject;

namespace SimpleUi {
	[TestFixture]
	public class ProjectTest : ZenjectUnitTestFixture {
		private Actionwords _actionwords;

		protected override void Install(DiContainer container) {
			_actionwords = new Actionwords();

			container.BindUiSignals(EWindowLayer.Local);

			container.BindInterfacesAndSelfTo<FirstController>().AsSingle();
			container.BindInterfacesAndSelfTo<SecondController>().AsSingle();
			container.BindInterfacesAndSelfTo<ThirdController>().AsSingle();
			container.BindInterfacesAndSelfTo<PopUpFirstController>().AsSingle();
			container.BindInterfacesAndSelfTo<PopUpSecondController>().AsSingle();

			container.Bind<FirstWindow>().AsSingle();
			container.Bind<SecondWindow>().AsSingle();
			container.Bind<ThirdWindow>().AsSingle();
			container.Bind<FirstPopUpWindow>().AsSingle();
			container.Bind<SecondPopUpWindow>().AsSingle();
			container.Bind<WindowTwoControllers>().AsSingle();
			container.Bind<WindowThreeControllers>().AsSingle();
			
			container.BindWindowsController<WindowsController>(EWindowLayer.Local);

			container.Inject(_actionwords);
		}

		[Test]
		public void WindowController() {
			_actionwords.OpenFirstIsActive();
			_actionwords.OpenSecondIsActive();
			_actionwords.OpenThirdIsActive();
			_actionwords.OpenPopUpFirstIsActive();
			_actionwords.OpenPopUpSecondIsActive();
			_actionwords.BackPopUpSecondClosed();
			_actionwords.OpenTwoControllerWindowFirstSecondIsActive();
			_actionwords.OpenThreeControllerWindowFirstSecondThirdIsActive();
			_actionwords.BackThreeControllerWindowThirdClosed();
			_actionwords.BackTwoControllerWindowSecondClosedPopUpFirstIsActive();
			_actionwords.BackPopUpFirstPopUpFirstClosedThirdIsActive();
			_actionwords.BackThirdThirdClosedSecondIsActive();
			_actionwords.BackSecondSecondClosedFirstIsActive();
			_actionwords.BackFirstFirstIsActive();
		}
	}
}