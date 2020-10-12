using Ecs.Core.Interfaces;
using Entitas;

namespace Ecs.Core.Systems
{
	public abstract class IntervalExecuteSystem : IExecuteSystem
	{
		private readonly ITimeProvider _timeProvider;

		private float _accumulator;

		protected IntervalExecuteSystem(ITimeProvider timeProvider, float interval)
		{
			_timeProvider = timeProvider;
			_accumulator = interval;
			Interval = interval;
		}

		private float _interval;

		protected float Interval
		{
			get => _interval;
			set
			{
				if (value <= 0)
					throw new System.Exception($"[{GetType().Name}] Interval must be greater then zero");
				_interval = value;
			}
		}


		public void Execute()
		{
			_accumulator += _timeProvider.DeltaTime;

			while (_accumulator >= _interval)
			{
				_accumulator -= _interval;
				UpdateInterval();
			}
		}

		protected abstract void UpdateInterval();
	}
}