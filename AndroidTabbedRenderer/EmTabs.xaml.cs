using System;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace AndroidTabbedRenderer
{
	public partial class EmTabs : BottomTabbedPage
	{
		public EmTabs()
		{
			this.AndroidMenu = BottomMenu.Photos;

			InitializeComponent();

			On<Android>().DisableSwipePaging();

			Children.Add(new FuckPage());
			Children.Add(new ThisPage());
			Children.Add(new ShitPage());
		}

	}
}