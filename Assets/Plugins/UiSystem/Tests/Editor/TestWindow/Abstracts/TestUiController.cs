using System.Collections.Generic;
using SimpleUi.Interfaces;
using SimpleUi.Models;

namespace SimpleUi.Abstracts
{
	public abstract class TestUiController : IUiController
	{
		private readonly UiControllerState _defaultState = new UiControllerState(false, false, 0);
		private readonly Stack<UiControllerState> _states = new Stack<UiControllerState>();
		private UiControllerState _currentState;

		public bool IsActive { get; private set; }
		public bool InFocus { get; private set; }

		public void SetState(UiControllerState state)
		{
			_currentState = state;
			_states.Push(state);
		}

		public void ProcessStateOrder()
		{
		}

		public void ProcessState()
		{
			IsActive = _currentState.IsActive;
			InFocus = _currentState.InFocus;
		}

		public void Back()
		{
			if (_states.Count > 0)
				_states.Pop();
			if (_states.Count == 0)
			{
				_currentState = _defaultState;
				return;
			}

			SetState(_states.Pop());
		}

		public IUiElement[] GetUiElements() => new IUiElement[0];
	}
}