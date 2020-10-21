using System.Collections.Generic;
using Ecs.Access.States.Impls;
using Unity.Jobs;

namespace Ecs.Access.EntityState.Impls
{
	public class GameStateAccess : IAccess<GameState>
	{
		private readonly IAccess<List<UnitState>> _unitStateAccess;
		private readonly IAccess<List<ItemState>> _itemStateAccess;
		private readonly IWriteJob[] _writeJobs = new IWriteJob[7];

		private WriteStateJob _writeStateJob;

		public GameStateAccess(
			IAccess<List<UnitState>> unitStateAccess,
			IAccess<List<ItemState>> itemStateAccess
		)
		{
			_unitStateAccess = unitStateAccess;
			_itemStateAccess = itemStateAccess;
		}

		public void ReadState(GameState state)
		{
			_unitStateAccess.ReadState(state.Units);
			_itemStateAccess.ReadState(state.Items);
		}

		public void WriteState(GameState state)
		{
			var index = 0;
			_writeJobs[index++] = new WriteJob<UnitState>(state.Units, _unitStateAccess);
			_writeJobs[index++] = new WriteJob<ItemState>(state.Items, _itemStateAccess);
			_writeStateJob = new WriteStateJob(_writeJobs);
			_writeStateJob.Run(_writeJobs.Length);
		}

		private struct WriteStateJob : IJobParallelFor
		{
			private readonly IWriteJob[] _jobs;

			public WriteStateJob(IWriteJob[] jobs)
			{
				_jobs = jobs;
			}

			public void Execute(int index) => _jobs[index].Write();
		}

		private struct WriteJob<TState> : IWriteJob
		{
			private readonly List<TState> _states;
			private readonly IAccess<List<TState>> _access;

			public WriteJob(List<TState> states, IAccess<List<TState>> access)
			{
				_states = states;
				_access = access;
			}

			public void Write() => _access.WriteState(_states);
		}

		private interface IWriteJob
		{
			void Write();
		}
	}
}