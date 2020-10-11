using System;

namespace UniRx.Rollback
{
	public interface IReactiveRollbackProperty<T> : IReactiveProperty<T>
	{
		IObservable<ChangeHistory<T>> OnHistory();
	}
}