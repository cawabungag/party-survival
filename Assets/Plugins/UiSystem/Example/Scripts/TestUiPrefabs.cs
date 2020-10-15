using Example.Controller;
using Example.Views;
using SimpleUi;
using SimpleUi.Interfaces;
using UnityEngine;
using Zenject;

namespace Example
{
	[CreateAssetMenu(menuName = "Settings/TestUiPrefabs", fileName = "TestUiPrefabs")]
	public class TestUiPrefabs : ScriptableObjectInstaller
	{
		[SerializeField] private Canvas _canvas;
		[SerializeField] private FirstView _firstView;
		[SerializeField] private SecondView _secondView;
		[SerializeField] private ThirdView _thirdView;
		[SerializeField] private FourthView _fourthView;
		[SerializeField] private FifthView _fifthView;
		[SerializeField] private FirstPopUpView _firstPopUpView;
		[SerializeField] private SecondPopUpView _secondPopUpView;

		public override void InstallBindings()
		{
			var canvas = Instantiate(_canvas);
			var parent = canvas.transform;
			Container.Bind<IUiFilter>().To<CustomGraphicRaycaster>().FromComponentOn(canvas.gameObject).AsSingle();
			Container.BindUiView<FirstController, FirstView>(_firstView, parent);
			Container.BindUiView<SecondController, SecondView>(_secondView, parent);
			Container.BindUiView<ThirdController, ThirdView>(_thirdView, parent);
			Container.BindUiView<FourthController, FourthView>(_fourthView, parent);
			Container.BindUiView<FifthController, FifthView>(_fifthView, parent);
			Container.BindUiView<FirstPopUpController, FirstPopUpView>(_firstPopUpView, parent);
			Container.BindUiView<SecondPopUpController, SecondPopUpView>(_secondPopUpView, parent);
		}
	}
}