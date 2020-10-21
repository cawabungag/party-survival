using NUnit.Framework;
using SimpleUi.Signals;
using SimpleUi.Utils;
using Tests.Abstracts;
using Zenject;

namespace SimpleUi
{
	[TestFixture]
	public class PopUpTest : ZenjectUnitTestFixture
	{
		[Inject] private SignalBus _signalBus;

		[Inject] private FirstController _firstController;
		[Inject] private PopUpFirstController _popUpFirstController;
		[Inject] private PopUpSecondController _popUpSecondController;
		[Inject] private PopUpThirdController _popUpThirdController;

		protected override void Install(DiContainer container)
		{
			container.BindUiSignals(EWindowLayer.Local);

			container.BindInterfacesAndSelfTo<FirstController>().AsSingle();
			container.BindInterfacesAndSelfTo<PopUpFirstController>().AsSingle();
			container.BindInterfacesAndSelfTo<PopUpSecondController>().AsSingle();
			container.BindInterfacesAndSelfTo<PopUpThirdController>().AsSingle();

			container.Bind<FirstWindow>().AsSingle();
			container.Bind<FirstPopUpWindow>().AsSingle();
			container.Bind<SecondPopUpWindow>().AsSingle();
			container.Bind<ThirdPopUpWindow>().AsSingle();

			container.BindWindowsController<WindowsController>(EWindowLayer.Local);
		}

		[Test]
		public void WindowController()
		{
			_signalBus.OpenWindow<FirstWindow>();

			AssertController.Open(_firstController);
			AssertController.Closed(_popUpFirstController);
			AssertController.Closed(_popUpSecondController);
			AssertController.Closed(_popUpThirdController);

			_signalBus.OpenWindow<FirstPopUpWindow>();

			AssertController.Background(_firstController);
			AssertController.Open(_popUpFirstController);
			AssertController.Closed(_popUpSecondController);
			AssertController.Closed(_popUpThirdController);

			_signalBus.OpenWindow<SecondPopUpWindow>();

			AssertController.Background(_firstController);
			AssertController.Background(_popUpFirstController);
			AssertController.Open(_popUpSecondController);
			AssertController.Closed(_popUpThirdController);

			_signalBus.OpenWindow<ThirdPopUpWindow>();

			AssertController.Background(_firstController);
			AssertController.Background(_popUpFirstController);
			AssertController.Closed(_popUpSecondController);
			AssertController.Open(_popUpThirdController);

			_signalBus.BackWindow();

			AssertController.Background(_firstController);
			AssertController.Background(_popUpFirstController);
			AssertController.Open(_popUpSecondController);
			AssertController.Closed(_popUpThirdController);

			_signalBus.BackWindow();

			AssertController.Background(_firstController);
			AssertController.Open(_popUpFirstController);
			AssertController.Closed(_popUpSecondController);
			AssertController.Closed(_popUpThirdController);

			_signalBus.OpenWindow<SecondPopUpWindow>();

			AssertController.Background(_firstController);
			AssertController.Background(_popUpFirstController);
			AssertController.Open(_popUpSecondController);
			AssertController.Closed(_popUpThirdController);

			_signalBus.BackWindow();

			AssertController.Background(_firstController);
			AssertController.Open(_popUpFirstController);
			AssertController.Closed(_popUpSecondController);
			AssertController.Closed(_popUpThirdController);

			_signalBus.BackWindow();

			AssertController.Open(_firstController);
			AssertController.Closed(_popUpFirstController);
			AssertController.Closed(_popUpSecondController);
			AssertController.Closed(_popUpThirdController);
		}
	}
}