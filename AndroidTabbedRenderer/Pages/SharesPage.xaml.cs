using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AndroidTabbedRenderer
{
    public partial class SharesPage : BasePage
    {
        public SharesPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            Title = "Shares";
            this.Icon = "TabbarShare.png";
        }

        void OnOpenSubpage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SubPage());
        }

        void HideTabbar(object sender, EventArgs e)
        {
            TabBar.Hide();
        }

        void ShowTabbar(object sender, EventArgs e)
        {
            TabBar.Show();
        }
    }
}
