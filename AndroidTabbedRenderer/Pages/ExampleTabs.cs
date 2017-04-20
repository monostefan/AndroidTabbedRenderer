using System;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace AndroidTabbedRenderer
{
	public class ExampleTabs : BottomTabbedPage
	{
		public ExampleTabs()
		{
			this.AndroidMenu = BottomMenu.Photos;

			On<Android>().DisableSwipePaging();

			Children.Add(new ChroniclePage());
			Children.Add(new AlbumsPage());

			var page = new NavigationPage(new SharesPage());
			page.Title = "Shares";
			page.Icon = "TabbarShare.png";
			Children.Add(page);

			CurrentPage = page;
		}

	}
}

