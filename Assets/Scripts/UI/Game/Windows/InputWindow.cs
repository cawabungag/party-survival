using SimpleUi;
using UI.Game.Input.Impls;

namespace UI.Game.Windows
{
	public class InputWindow : WindowBase
	{
		public override string Name => "INPUT_WINDOWS";

		protected override void AddControllers()
		{
			AddController<InputController>();
		}
	}
}