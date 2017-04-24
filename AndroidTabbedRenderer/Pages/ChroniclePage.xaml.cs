using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AndroidTabbedRenderer
{
	public partial class ChroniclePage : ContentPage
	{
		public ChroniclePage()
		{
			InitializeComponent();
			Title = "Chronicle";
			this.Icon = "TabbarPhotos.png";
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
