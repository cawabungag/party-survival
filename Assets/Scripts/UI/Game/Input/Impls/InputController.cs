using System;
using Plugins.Joystick_Pack.Scripts.Joysticks;
using SimpleUi.Abstracts;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Game.Input.Impls
{
	public class InputController : UiController<InputView>, IInitializable,
		IDisposable
	{
		private readonly GameContext _gameContext;
		private CompositeDisposable _disposable = new CompositeDisposable();

		public InputController(GameContext gameContext)
		{
			_gameContext = gameContext;
		}

		public void Initialize()
		{
			FloatingJoystick floatingJoystick = View.Joystick;
			floatingJoystick.OnPointerUpHandler.Subscribe(unit => OnPointerUp()).AddTo(_disposable);
			Observable.EveryUpdate().Subscribe(l =>
			{
				OnHorizontal(floatingJoystick.Horizontal);
				OnVertical(floatingJoystick.Vertical);
				OnDirection(floatingJoystick.Direction);
			}).AddTo(_disposable);
		}

		private void OnHorizontal(float value)
		{
			_gameContext.ReplaceEcsGameInputHorizontal(value);
		}

		private void OnVertical(float value)
		{
			_gameContext.ReplaceEcsGameInputVertical(value);
		}

		private void OnDirection(Vector2 value)
		{
			_gameContext.ReplaceEcsGameInputDirectional(value);
		}

		private void OnPointerUp()
		{
			_gameContext.ReplaceEcsGameInputDirectional(Vector2.zero);
			_gameContext.ReplaceEcsGameInputVertical(0f);
			_gameContext.ReplaceEcsGameInputHorizontal(0f);
		}

		public void Dispose()
		{
			_disposable.Dispose();
		}
	}
}