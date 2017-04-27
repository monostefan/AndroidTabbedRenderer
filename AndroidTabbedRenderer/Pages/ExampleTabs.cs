using System;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

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

            var page = new TabNavigationPage(new SharesPage(), "Share", "TabbarShare.png");

            page.On<iOS>().EnableTranslucentNavigationBar();

			Children.Add(page);

			CurrentPage = page;
		}

	}
}

