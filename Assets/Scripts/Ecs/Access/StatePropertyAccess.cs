using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Ecs.Access
{
	public abstract class StatePropertyAccess<TObject, TState> : IObjectAccess<TObject, TState>, IInitializable
		where TState : IProperty
	{
		private readonly List<IPropertyAccess<TObject, TState>> _originators =
			new List<IPropertyAccess<TObject, TState>>();

		public abstract void Initialize();

		public void SetState(TObject obj, TState state)
		{
			for (var i = 0; i < _originators.Count; i++)
				try
				{
					var originator = _originators[i];
					originator.SetObjectValue(obj, state);
				}
				catch (Exception e)
				{
					Debug.LogError("obj: " + obj + ", state: " + state + ", e: " + e.Message);
					throw;
				}
		}

		public void GetState(TObject obj, ref TState state)
		{
			for (var i = 0; i < _originators.Count; i++)
			{
				var originator = _originators[i];
				originator.SetPropertyValue(obj, state);
			}
		}

		public void Reset(TState state)
		{
			for (var i = 0; i < _originators.Count; i++)
			{
				var originator = _originators[i];
				originator.Reset(state);
			}
		}

		public StatePropertyAccess<TObject, TState> AddOriginator<TPropertyAccess>()
			where TPropertyAccess : IPropertyAccess<TObject, TState>, new()
		{
			_originators.Add(new TPropertyAccess());
			return this;
		}

		public StatePropertyAccess<TObject, TState> AddOriginator(
			IPropertyAccess<TObject, TState> access
		)
		{
			_originators.Add(access);
			return this;
		}
	}
}