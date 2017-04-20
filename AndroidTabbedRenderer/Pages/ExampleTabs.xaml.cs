using System;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

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
			Children.Add(new AlbumsPage(this));
			Children.Add(new SharesPage());
		}

	}
}