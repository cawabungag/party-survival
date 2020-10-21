namespace UniRx.Rollback
{
	public class ChangeHistory<T>
	{
		public readonly T OldValue;
		public readonly T NewValue;

		public ChangeHistory(T oldValue, T newValue)
		{
			OldValue = oldValue;
			NewValue = newValue;
		}
	}
}