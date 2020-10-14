using Example.Views;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Example.Controller
{
	public class FirstController : UiController<FirstView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public FirstController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Next.OnClickAsObservable()
				.Subscribe(s => _signalBus.OpenWindow<SecondWindow>())
				.AddTo(View.Next);
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.BackWindow()).AddTo(View.Back);
		}
	}

	public class SecondController : UiController<SecondView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public SecondController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Next.OnClickAsObservable()
				.Subscribe(s => _signalBus.OpenWindow<ThirdWindow>())
				.AddTo(View.Next);
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.BackWindow()).AddTo(View.Back);
		}
	}

	public class ThirdController : UiController<ThirdView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public ThirdController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Next.OnClickAsObservable()
				.Subscribe(s => _signalBus.OpenWindow<FirstPopUpWindow>())
				.AddTo(View.Next);
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.BackWindow()).AddTo(View.Back);
		}
	}

	public class FirstPopUpController : UiController<FirstPopUpView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public FirstPopUpController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Next.OnClickAsObservable()
				.Subscribe(s => _signalBus.OpenWindow<SecondPopUpWindow>())
				.AddTo(View.Next);
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.BackWindow()).AddTo(View.Back);
		}
	}

	public class SecondPopUpController : UiController<SecondPopUpView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public SecondPopUpController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Next.OnClickAsObservable()
				.Subscribe(s => _signalBus.OpenWindow<FourthWindow>())
				.AddTo(View.Next);
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.BackWindow()).AddTo(View.Back);
		}
	}

	public class FourthController : UiController<FourthView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public FourthController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Next.OnClickAsObservable()
				.Subscribe(s => _signalBus.OpenWindow<FifthWindow>())
				.AddTo(View.Next);
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.BackWindow()).AddTo(View.Back);
		}
	}

	public class FifthController : UiController<FifthView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public FifthController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.BackWindow()).AddTo(View.Back);
		}
	}
}