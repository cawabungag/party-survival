using System;
using UniRx;

namespace Ecs.Core.Utils
{
	public static class EntityExtensions
	{
		public static IDisposable Listen<TListener>(
			this TListener listener,
			Action<TListener> add,
			Action<TListener, bool> remove
		)
		{
			add(listener);
			return Disposable.Create(() => remove(listener, true));
		}
	}
}