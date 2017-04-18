using Android.Support.Design.Widget;
using Android.Views;
using AndroidTabbedRenderer;
using AndroidTabbedRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

using Android.Support.V4.View;

[assembly: ExportRenderer(typeof(BottomTabbedPage), typeof(BottomTabbedPageRenderer))]
namespace AndroidTabbedRenderer.Droid
{
	public class BottomTabbedPageRenderer : TabbedPageRenderer
	{
		TabLayout tabLayout;
		ViewPager viewPager;

		protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
		{
			base.OnElementChanged(e);

			FindItems();
		}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			int width = r - l;
			int height = b - t;

			base.OnLayout(changed, l, t, r, b);
		}

		private void FindItems()
		{
			for (int i = 0; i < ViewGroup.ChildCount; i++)
			{
				var child = ViewGroup.GetChildAt(i);

				var asViewPager = child as ViewPager;
				if (asViewPager != null)
					this.viewPager = asViewPager;

				var asTabLayout = child as TabLayout;
				if (asTabLayout != null)
					this.tabLayout = asTabLayout;
			}
		}
	}
}