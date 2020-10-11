using System;
using System.Collections.Generic;

namespace Ecs.Access.States.Impls
{
	[Serializable]
	public class GameState
	{
		public List<ItemState> Items;
		public List<UnitState> Units;
	}
}