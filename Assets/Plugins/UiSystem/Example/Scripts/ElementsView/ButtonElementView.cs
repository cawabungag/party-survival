using SimpleUi.Abstracts;
using UnityEngine;

namespace Example.ElementsView
{
	public class ButtonElementView : UiElementView
	{
		[SerializeField] private string _name;

		public override string Name => _name;

		public override void Highlight()
		{
		}

		public override void Reset()
		{
		}
	}
}