﻿using System;
using System.Collections.Generic;
using Ecs.Core.Interfaces;
using Entitas;
using Zenject;

namespace Ecs.Core.Bootstrap
{
	public class MainBootstrap : IBootstrap, ITickable, ILateTickable, IFixedTickable,
		IGuiRenderable
	{
		private readonly List<IContext> _contexts;
		private readonly Feature _feature;
		private readonly List<IStartable> _startables;
		private readonly List<IResetable> _resetables;
		private readonly List<ILateSystem> _late = new List<ILateSystem>();
		private readonly List<IFixedSystem> _fixed = new List<IFixedSystem>();
		private readonly List<ILateFixedSystem> _lateFixed = new List<ILateFixedSystem>();
		private readonly List<IGuiSystem> _gui = new List<IGuiSystem>();
		private readonly List<IGizmoSystem> _gizmo = new List<IGizmoSystem>();
		private readonly List<IDisposeSystem> _disposables = new List<IDisposeSystem>();
		private bool _isInitialized;
		private bool _isPaused;

		public MainBootstrap(
			string name,
			[Inject(Source = InjectSources.Local)] List<IContext> contexts,
			[Inject(Source = InjectSources.Local)] List<ISystem> systems,
			[Inject(Source = InjectSources.Local)] List<IStartable> startables,
			[Inject(Source = InjectSources.Local)] List<IResetable> resetables
		)
		{
			_contexts = contexts;
			_startables = startables;
			_resetables = resetables;
			_feature = new Feature($"Bootstrap [{name}]");
			for (var i = 0; i < systems.Count; i++)
			{
				var system = systems[i];
				_feature.Add(system);
				if (system is ILateSystem late)
					_late.Add(late);
				if (system is IFixedSystem @fixed)
					_fixed.Add(@fixed);
				if (system is ILateFixedSystem lateFixed)
					_lateFixed.Add(lateFixed);
				if (system is IGuiSystem gui)
					_gui.Add(gui);
				if (system is IGizmoSystem gizmo)
					_gizmo.Add(gizmo);
				if (system is IDisposeSystem dispose)
					_disposables.Add(dispose);
			}
		}

		public void Initialize()
		{
			if (_isInitialized)
				throw new Exception("[MainBootstrap] Bootstrap already is initialized");

			if (_startables != null)
				foreach (var pool in _startables)
					pool.Start();
			_feature.Initialize();
			_isInitialized = true;
		}

		public void Tick()
		{
			if (_isPaused)
				return;

			_feature.Execute();
		}

		public void FixedTick()
		{
			if (_isPaused)
				return;

			for (var i = 0; i < _fixed.Count; i++)
				_fixed[i].Fixed();
		}

		public void LateFixed()
		{
			if (_isPaused)
				return;
			for (var i = 0; i < _lateFixed.Count; i++)
				_lateFixed[i].LateFixed();
		}

		public void LateTick()
		{
			if (_isPaused)
				return;

			for (var i = 0; i < _late.Count; i++)
				_late[i].Late();

			_feature.Cleanup();
		}

		public void GuiRender()
		{
			if (_isPaused)
				return;

			for (var i = 0; i < _gui.Count; i++)
				_gui[i].Gui();
		}

		public void GizmoRender()
		{
			if (_isPaused)
				return;

			for (var i = 0; i < _gizmo.Count; i++)
				_gizmo[i].Gizmo();
		}

		public void Pause(bool isPaused) => _isPaused = isPaused;

		public void Reset()
		{
			_feature.DeactivateReactiveSystems();
			_feature.ClearReactiveSystems();

			foreach (var disposable in _disposables)
				disposable.Dispose();

			foreach (var context in _contexts)
			{
				context.DestroyAllEntities();
				context.ResetCreationIndex();
			}

			foreach (var resetable in _resetables)
				resetable.Reset();

			_feature.ActivateReactiveSystems();
			_isInitialized = false;
		}

		public void Dispose()
		{
			foreach (var disposable in _disposables)
				disposable.Dispose();

			_feature.DeactivateReactiveSystems();
			_feature.ClearReactiveSystems();
			foreach (var context in _contexts)
				context.Reset();
		}
	}
}