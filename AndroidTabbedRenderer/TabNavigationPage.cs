using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AndroidTabbedRenderer
{
	public class TabNavigationPage : NavigationPage
	{
		private TabBarController TabBar = new TabBarController();

		public TabNavigationPage()
		{
            Init();
		}

		public TabNavigationPage(Page root) : base(root)
		{
            Init();
		}

		public TabNavigationPage(Page root, string title, string icon) : base(root)
		{
			this.Title = title;
			this.Icon = icon;

			Init();
		}

		private void Init()
		{
			var controller = this as INavigationPageController;
			controller.PushRequested += PushRequested;
			controller.PopToRootRequested += PopToRootRequested;
			Popped += OnPopped;
		}

		private void PushRequested(object sender, NavigationRequestedEventArgs e)
		{
			TabBar.SlideDown();
		}

		private void PopToRootRequested(object sender, NavigationRequestedEventArgs e)
		{
			TabBar.SlideUp();
		}

		private void OnPopped(object sender, NavigationEventArgs e)
		{
			if (Navigation.NavigationStack.Count == 1)
			{
				TabBar.SlideUp();
			}
		}
	}
}
