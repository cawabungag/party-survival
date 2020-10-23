using SimpleUi;
using UI.Game.Input.Impls;
using UnityEngine;
using Zenject;

namespace Installers
{
	[CreateAssetMenu(menuName = "Installers/GameUiInstaller", fileName = "GameUiInstaller")]
	public class GameUiInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private Canvas canvas;
		[SerializeField] private Object inputView;

		public override void InstallBindings()
		{
			var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(canvas);
			var canvasTransform = canvasInstance.transform;
			Container.BindUiView<InputController, InputView>(inputView, canvasTransform);
		}
	}
}