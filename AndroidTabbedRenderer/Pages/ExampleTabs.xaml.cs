using System;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms;

namespace AndroidTabbedRenderer
{
	public partial class ExampleTabs : BottomTabbedPage
	{
		public ExampleTabs()
		{
			this.AndroidMenu = BottomMenu.Photos;

			InitializeComponent();

			On<Android>().DisableSwipePaging();

			Children.Add(new ChroniclePage());
			Children.Add(new AlbumsPage());
			Children.Add(
				new NavigationPage(new SharesPage()));
		}

	}
}