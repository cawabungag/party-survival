using System;
using SimpleUi.Abstracts;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Game.Input.Impls
{
	public class InputController : UiController<InputView>, IInitializable,
		IDisposable
	{
		private readonly InputContext _inputContext;
		private CompositeDisposable _disposable = new CompositeDisposable();
		private ReactiveProperty<float> _onHorizontal;
		private ReactiveProperty<float> _onVertical;
		private ReactiveProperty<Vector2> _onDirection;

		public InputController(InputContext inputContext)
		{
			_inputContext = inputContext;
		}

		public void Initialize()
		{
			FloatingJoystick floatingJoystick = View.Joystick;
			_onHorizontal = new ReactiveProperty<float>(floatingJoystick.Horizontal).AddTo(_disposable);
			_onVertical = new ReactiveProperty<float>(floatingJoystick.Vertical).AddTo(_disposable);
			_onDirection = new ReactiveProperty<Vector2>(floatingJoystick.Direction).AddTo(_disposable);
			_onHorizontal.Subscribe(OnHorizontal).AddTo(_disposable);
			_onVertical.Subscribe(OnVertical).AddTo(_disposable);
			_onDirection.Subscribe(OnDirection).AddTo(_disposable);
		}

		private void OnHorizontal(float value)
		{
			_inputContext.ReplaceEcsInputHorizontal(value);
		}

		private void OnVertical(float value)
		{
			_inputContext.ReplaceEcsInputVertical(value);
		}

		private void OnDirection(Vector2 value)
		{
			_inputContext.ReplaceEcsInputDirectional(value);
		}


		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}