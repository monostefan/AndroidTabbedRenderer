using System;
using Xamarin.Forms;
namespace AndroidTabbedRenderer
{
	public class TabBarController
	{
		public void Hide()
		{
			MessagingCenter.Send(this, "HideTabbar");
		}

		public void Show()
		{
			MessagingCenter.Send(this, "ShowTabbar");
		}

		public void SlideUp()
		{
			MessagingCenter.Send(this, "SlideUpTabbar");
		}

		public void SlideDown()
		{
			MessagingCenter.Send(this, "SlideDownTabbar");
		}
	}
}
