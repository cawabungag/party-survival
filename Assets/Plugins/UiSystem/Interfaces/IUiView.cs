using UnityEngine;

namespace SimpleUi.Interfaces
{
	public interface IUiView
	{
		void Show();
		void Hide();
		IUiElement[] GetUiElements();
		void SetOrder(int index);
		void SetParent(Transform parent);
		void Destroy();
	}
}