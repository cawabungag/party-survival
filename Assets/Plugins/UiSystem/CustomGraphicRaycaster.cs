using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SimpleUi
{
	public class CustomGraphicRaycaster : GraphicRaycaster, IUiFilter
	{
		private readonly List<int> _filter = new List<int>();

		public void SetFilter(List<int> objectsId)
		{
			_filter.AddRange(objectsId);
		}

		public void DropFilter()
		{
			_filter.Clear();
		}

		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
			base.Raycast(eventData, resultAppendList);
			if (_filter.Count == 0)
				return;
			resultAppendList.RemoveAll(f => !_filter.Contains(f.gameObject.GetInstanceID()));
		}
	}
}