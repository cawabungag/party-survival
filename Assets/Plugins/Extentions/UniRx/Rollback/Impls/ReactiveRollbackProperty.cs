using System;

namespace UniRx.Rollback
{
	public class ReactiveRollbackProperty<T> : ReactiveProperty<T>, IReactiveRollbackProperty<T>
	{
		private bool _isDisposed;

		[NonSerialized] private Subject<ChangeHistory<T>> _changeHistory;

		public IObservable<ChangeHistory<T>> OnHistory()
		{
			if (_isDisposed) return Observable.Empty<ChangeHistory<T>>();
			return _changeHistory ?? (_changeHistory = new Subject<ChangeHistory<T>>());
		}

		protected override void SetValue(T value)
		{
			var oldValue = Value;
			base.SetValue(value);
			_changeHistory?.OnNext(new ChangeHistory<T>(oldValue, value));
		}

		protected override void Dispose(bool disposing)
		{
			_isDisposed = true;
			base.Dispose(disposing);
		}
	}
}