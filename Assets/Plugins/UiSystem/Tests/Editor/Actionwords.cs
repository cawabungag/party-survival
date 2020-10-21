using SimpleUi.Signals;
using SimpleUi.Utils;
using Zenject;

namespace SimpleUi
{
	public class Actionwords
	{
		[Inject] private FirstController _firstController;
		[Inject] private SecondController _secondController;
		[Inject] private ThirdController _thirdController;
		[Inject] private PopUpFirstController _popUpFirst;
		[Inject] private PopUpSecondController _popUpSecond;
		[Inject] private SignalBus _signalBus;

		public void OpenFirstIsActive()
		{
			_signalBus.OpenWindow<FirstWindow>();

			AssertController.Open(_firstController);
			AssertController.Closed(_secondController);
			AssertController.Closed(_thirdController);
			AssertController.Closed(_popUpFirst);
			AssertController.Closed(_popUpSecond);
		}

		public void OpenSecondIsActive()
		{
			_signalBus.OpenWindow<SecondWindow>();

			AssertController.Closed(_firstController);
			AssertController.Open(_secondController);
			AssertController.Closed(_thirdController);
			AssertController.Closed(_popUpFirst);
			AssertController.Closed(_popUpSecond);
		}

		public void OpenThirdIsActive()
		{
			_signalBus.OpenWindow<ThirdWindow>();

			AssertController.Closed(_firstController);
			AssertController.Closed(_secondController);
			AssertController.Open(_thirdController);
			AssertController.Closed(_popUpFirst);
			AssertController.Closed(_popUpSecond);
		}

		public void OpenPopUpFirstIsActive()
		{
			_signalBus.OpenWindow<FirstPopUpWindow>();

			AssertController.Closed(_firstController);
			AssertController.Closed(_secondController);
			AssertController.Background(_thirdController);
			AssertController.Open(_popUpFirst);
			AssertController.Closed(_popUpSecond);
		}

		public void OpenPopUpSecondIsActive()
		{
			_signalBus.OpenWindow<SecondPopUpWindow>();

			AssertController.Closed(_firstController);
			AssertController.Closed(_secondController);
			AssertController.Background(_thirdController);
			AssertController.Background(_popUpFirst);
			AssertController.Open(_popUpSecond);
		}

		public void BackPopUpSecondClosed()
		{
			_signalBus.BackWindow();

			AssertController.Closed(_firstController);
			AssertController.Closed(_secondController);
			AssertController.Background(_thirdController);
			AssertController.Open(_popUpFirst);
			AssertController.Closed(_popUpSecond);
		}

		public void OpenTwoControllerWindowFirstSecondIsActive()
		{
			_signalBus.OpenWindow<WindowTwoControllers>();

			AssertController.Open(_firstController);
			AssertController.Open(_secondController);
			AssertController.Closed(_thirdController);
			AssertController.Closed(_popUpFirst);
			AssertController.Closed(_popUpSecond);
		}

		public void OpenThreeControllerWindowFirstSecondThirdIsActive()
		{
			_signalBus.OpenWindow<WindowThreeControllers>();

			AssertController.Open(_firstController);
			AssertController.Open(_secondController);
			AssertController.Open(_thirdController);
			AssertController.Closed(_popUpFirst);
			AssertController.Closed(_popUpSecond);
		}

		public void BackThreeControllerWindowThirdClosed()
		{
			_signalBus.BackWindow();

			AssertController.Open(_firstController);
			AssertController.Open(_secondController);
			AssertController.Closed(_thirdController);
			AssertController.Closed(_popUpFirst);
			AssertController.Closed(_popUpSecond);
		}

		public void BackTwoControllerWindowSecondClosedPopUpFirstIsActive()
		{
			_signalBus.BackWindow();

			AssertController.Closed(_firstController);
			AssertController.Closed(_secondController);
			AssertController.Background(_thirdController);
			AssertController.Open(_popUpFirst);
			AssertController.Closed(_popUpSecond);
		}

		public void BackPopUpFirstPopUpFirstClosedThirdIsActive()
		{
			_signalBus.BackWindow();

			AssertController.Closed(_firstController);
			AssertController.Closed(_secondController);
			AssertController.Open(_thirdController);
			AssertController.Closed(_popUpFirst);
			AssertController.Closed(_popUpSecond);
		}

		public void BackThirdThirdClosedSecondIsActive()
		{
			_signalBus.BackWindow();

			AssertController.Closed(_firstController);
			AssertController.Open(_secondController);
			AssertController.Closed(_thirdController);
			AssertController.Closed(_popUpFirst);
			AssertController.Closed(_popUpSecond);
		}

		public void BackSecondSecondClosedFirstIsActive()
		{
			_signalBus.BackWindow();

			AssertController.Open(_firstController);
			AssertController.Closed(_secondController);
			AssertController.Closed(_thirdController);
			AssertController.Closed(_popUpFirst);
			AssertController.Closed(_popUpSecond);
		}

		public void BackFirstFirstIsActive()
		{
			_signalBus.BackWindow();

			AssertController.Closed(_firstController);
			AssertController.Closed(_secondController);
			AssertController.Closed(_thirdController);
			AssertController.Closed(_popUpFirst);
			AssertController.Closed(_popUpSecond);
			AssertController.Closed(_popUpSecond);
		}
	}
}