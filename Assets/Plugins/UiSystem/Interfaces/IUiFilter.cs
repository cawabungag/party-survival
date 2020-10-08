using System.Collections.Generic;

namespace SimpleUi.Interfaces
{
	public interface IUiFilter
	{
		void SetFilter(List<int> objectsId);
		void DropFilter();
	}
}