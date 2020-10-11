using System.Collections.Generic;
using Ecs.Access.States.Impls;
using Unity.Jobs;
using Zenject;

namespace Ecs.Access.Pool
{
	public class GameStatePool : MemoryPool<GameState>
	{
		private readonly IMemoryPool<UnitState> _unitStatePool;
		private readonly IMemoryPool<ItemState> _itemStatePool;
		private readonly IDespawn[] _despawns = new IDespawn[7];

		private DespawnJob _despawnJob;

		public GameStatePool(
			IMemoryPool<UnitState> unitStatePool,
			IMemoryPool<ItemState> itemStatePool
		)
		{
			_unitStatePool = unitStatePool;
			_itemStatePool = itemStatePool;
		}

		protected override void OnCreated(GameState item)
		{
			item.Units = new List<UnitState>();
			item.Items = new List<ItemState>();
		}

		protected override void OnDespawned(GameState item)
		{
			var index = 0;
			CreateDespawn(index++, ref item.Units, _unitStatePool);
			CreateDespawn(index++, ref item.Items, _itemStatePool);
			_despawnJob = new DespawnJob(_despawns);
			_despawnJob.Run(_despawns.Length);
		}

		private void CreateDespawn<TState>(int index, ref List<TState> states, IMemoryPool<TState> pool)
		{
			if (states == null)
				states = new List<TState>();
			_despawns[index] = new Job<TState>(states, pool);
		}


		private struct DespawnJob : IJobParallelFor
		{
			private readonly IDespawn[] _despawns;

			public DespawnJob(IDespawn[] despawns)
			{
				_despawns = despawns;
			}

			public void Execute(int index)
			{
				_despawns[index].Despawn();
			}
		}

		private struct Job<TState> : IDespawn
		{
			private readonly List<TState> _list;
			private readonly IMemoryPool<TState> _pool;

			public Job(List<TState> list, IMemoryPool<TState> pool)
			{
				_list = list;
				_pool = pool;
			}

			public void Despawn()
			{
				var length = _list.Count;
				for (var i = 0; i < length; i++)
					_pool.Despawn(_list[i]);

				_list.Clear();
			}
		}

		private interface IDespawn
		{
			void Despawn();
		}
	}
}