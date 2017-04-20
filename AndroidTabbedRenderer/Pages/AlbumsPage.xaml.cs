using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AndroidTabbedRenderer
{
	public partial class AlbumsPage : BasePage
    {
        public AlbumsPage()
        {
            InitializeComponent();
            Title = "Albums";

            this.Content = GetPageContent();

            this.Icon = "TabbarAlbums.png";
        }

        private ContentView GetPageContent()
        {
            var contentView = new ContentView();
            var stack = new StackLayout();
            stack.Margin = new Thickness(0, 50, 0, 0);
            var hideButton = new Button
            {
                Text = "Hide"
            };
			hideButton.Clicked += (s,e) => TabBar.Hide();


            var showButton = new Button
            {
                Text = "Show"
            };

			showButton.Clicked += (s,e) => TabBar.Show();


            var slideUpButton = new Button
            {
                Text = "SlideUp"
            };

			slideUpButton.Clicked += (s,e) => TabBar.SlideUp();



            var slideDownButton = new Button
            {
                Text = "SlideDown"
            };


			slideDownButton.Clicked += (s,e) => TabBar.SlideDown();

            stack.Children.Add(hideButton);
            stack.Children.Add(showButton);

            stack.Children.Add(slideUpButton);
            stack.Children.Add(slideDownButton);

            contentView.Content = stack;
            return contentView;
        }
    }
}
