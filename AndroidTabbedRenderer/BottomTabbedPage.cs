using System;

using Xamarin.Forms;

namespace AndroidTabbedRenderer
{
	public class BottomTabbedPage : TabbedPage
	{
		public IBottomTabbedPageRenderer Renderer { get; set; }

		public BottomMenu AndroidMenu { get; set; }

		public BottomTabbedPage()
		{
			Init();
		}

		public void Init()
		{
			MessagingCenter.Subscribe<TabBarController>(this, "HideTabbar", Hide);
			MessagingCenter.Subscribe<TabBarController>(this, "ShowTabbar", Show);
			MessagingCenter.Subscribe<TabBarController>(this, "SlideDownTabbar", SlideDown);
			MessagingCenter.Subscribe<TabBarController>(this, "SlideUpTabbar", SlideUp);
		}

		~BottomTabbedPage()
		{
			MessagingCenter.Unsubscribe<TabBarController>(this, "HideTabbar");
			MessagingCenter.Unsubscribe<TabBarController>(this, "ShowTabbar");
			MessagingCenter.Unsubscribe<TabBarController>(this, "SlideDownTabbar");
			MessagingCenter.Unsubscribe<TabBarController>(this, "SlideUpTabbar");
		}

		public void Hide(object sender)
		{
			Renderer?.Hide();
		}

		public void Show(object sender)
		{
			Renderer?.Show();
		}

		public void SlideUp(object sender)
		{
			Renderer?.SlideUp();
		}

		public void SlideDown(object sender)
		{
			Renderer?.SlideDown();
		}
	}
}

