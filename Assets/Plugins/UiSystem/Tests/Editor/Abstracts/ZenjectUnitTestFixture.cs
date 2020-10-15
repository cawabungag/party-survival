using System;
using System.Collections.Generic;
using NUnit.Framework;
using Zenject;

namespace Tests.Abstracts {
	public abstract class ZenjectUnitTestFixture {
		[Inject] private List<IInitializable> _initializables;
		[Inject] private List<IDisposable> _disposables;
		private DiContainer _container;

		[SetUp]
		public virtual void Setup() {
			_container = new DiContainer();
			SignalBusInstaller.Install(_container);
			Install(_container);
			_container.ResolveRoots();
			_container.Inject(this);

			if (_initializables == null)
				return;
			foreach (var initializable in _initializables)
				initializable.Initialize();
		}

		protected abstract void Install(DiContainer container);

		[TearDown]
		public virtual void TearDown() {
			if (_disposables == null)
				return;
			foreach (var disposable in _disposables)
				disposable.Dispose();
		}
	}
}