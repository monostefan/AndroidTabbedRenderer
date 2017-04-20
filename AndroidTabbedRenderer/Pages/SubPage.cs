using System;
using Xamarin.Forms;
namespace AndroidTabbedRenderer
{
	public class SubPage : ContentPage
	{
		public SubPage()
		{
			NavigationPage.SetHasNavigationBar(this, false);

			this.Content = new Label
			{
				Text = "Hey, I'm a Subpage!",
				BackgroundColor = Color.Azure
			};
		}
	}
}
