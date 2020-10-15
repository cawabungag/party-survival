using NUnit.Framework;
using SimpleUi.Interfaces;

namespace SimpleUi.Utils
{
	public static class AssertController
	{
		public static void Open(IUiController controller)
		{
			Assert.True(controller.IsActive);
			Assert.True(controller.InFocus);
		}

		public static void Closed(IUiController controller)
		{
			Assert.False(controller.IsActive);
			Assert.False(controller.InFocus);
		}

		public static void Background(IUiController controller)
		{
			Assert.True(controller.IsActive);
			Assert.False(controller.InFocus);
		}
	}
}