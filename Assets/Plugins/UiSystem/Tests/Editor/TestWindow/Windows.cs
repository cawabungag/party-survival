using SimpleUi.Interfaces;

namespace SimpleUi
{
	public class FirstWindow : WindowBase
	{
		public override string Name => "First";


		protected override void AddControllers()
		{
			AddController<FirstController>();
		}
	}

	public class SecondWindow : WindowBase
	{
		public override string Name => "Second";

		protected override void AddControllers()
		{
			AddController<SecondController>();
		}
	}

	public class ThirdWindow : WindowBase
	{
		public override string Name => "Third";

		protected override void AddControllers()
		{
			AddController<ThirdController>();
		}
	}

	public class WindowTwoControllers : WindowBase
	{
		public override string Name => "TwoControllers";

		protected override void AddControllers()
		{
			AddController<FirstController>();
			AddController<SecondController>();
		}
	}

	public class WindowThreeControllers : WindowBase
	{
		public override string Name => "ThreeControllers";

		protected override void AddControllers()
		{
			AddController<FirstController>();
			AddController<SecondController>();
			AddController<ThirdController>();
		}
	}

	public class FirstPopUpWindow : WindowBase, IPopUp, INoneHidden
	{
		public override string Name => "FirstPopUp";

		protected override void AddControllers()
		{
			AddController<PopUpFirstController>();
		}
	}

	public class SecondPopUpWindow : WindowBase, IPopUp
	{
		public override string Name => "SecondPopUp";

		protected override void AddControllers()
		{
			AddController<PopUpSecondController>();
		}
	}

	public class ThirdPopUpWindow : WindowBase, IPopUp
	{
		public override string Name => "ThirdPopUp";

		protected override void AddControllers()
		{
			AddController<PopUpThirdController>();
		}
	}
}