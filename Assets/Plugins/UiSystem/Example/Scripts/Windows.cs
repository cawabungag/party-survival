using Example.Controller;
using SimpleUi;
using SimpleUi.Interfaces;

namespace Example
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

	public class FirstPopUpWindow : WindowBase, IPopUp, INoneHidden
	{
		public override string Name => "FirstPopUp";

		protected override void AddControllers()
		{
			AddController<FirstPopUpController>();
		}
	}

	public class SecondPopUpWindow : WindowBase, IPopUp
	{
		public override string Name => "SecondPopUp";

		protected override void AddControllers()
		{
			AddController<SecondPopUpController>();
		}
	}

	public class FourthWindow : WindowBase
	{
		public override string Name => "Fourth";

		protected override void AddControllers()
		{
			AddController<FourthController>();
			AddController<FirstController>();
			AddController<SecondController>();
		}
	}

	public class FifthWindow : WindowBase
	{
		public override string Name => "Fifth";

		protected override void AddControllers()
		{
			AddController<FifthController>();
			AddController<FirstController>();
			AddController<SecondController>();
			AddController<ThirdController>();
		}
	}
}