using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AndroidTabbedRenderer
{
    public partial class SharesPage : ContentPage
    {
        public SharesPage()
        {
			NavigationPage.SetHasNavigationBar(this, false);


            InitializeComponent();
            Title = "Shares";
            this.Icon = "TabbarShare.png";
        }

		protected override void OnAppearing()
		{
			var bla = new TabBarController();
			bla.Hide();
		}

		void OnOpenSubpage(object sender, EventArgs e)
		{
			Navigation.PushAsync(new SubPage());
		}
	}
}
