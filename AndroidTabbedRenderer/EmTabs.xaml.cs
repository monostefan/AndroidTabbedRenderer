using System;

namespace AndroidTabbedRenderer
{
	public partial class EmTabs : BottomTabbedPage
	{
		public EmTabs()
		{
			InitializeComponent();

			Children.Add(new FuckPage());
			Children.Add(new ThisPage());
			Children.Add(new ShitPage());
		}

	}
}