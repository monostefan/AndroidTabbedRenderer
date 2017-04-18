using System;
using System.Collections.Specialized;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Content.Res;
using Android.Widget;
using AndroidTabbedRenderer;
using AndroidTabbedRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

using Color = Android.Graphics.Color;
using RelativeLayout = Android.Widget.RelativeLayout;


[assembly: ExportRenderer(typeof(BottomTabbedPage), typeof(BottomTabbedPageRenderer))]
namespace AndroidTabbedRenderer.Droid
{
	public class BottomTabbedPageRenderer : TabbedPageRenderer
	{
		BottomNavigationView bottomNavigationView;

		protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
		{
			base.OnElementChanged(e);

			if (bottomNavigationView == null)
			{
				HideTabLayout();

				bottomNavigationView = new BottomNavigationView(this.Context);
				bottomNavigationView.SetBackgroundResource(Resource.Color.indigo);
				bottomNavigationView.ItemIconTintList = ColorStateList.ValueOf(Color.White);
				bottomNavigationView.ItemTextColor = ColorStateList.ValueOf(Color.White);
				bottomNavigationView.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
				AddView(bottomNavigationView);

				bottomNavigationView.InflateMenu(Resource.Menu.main_menu);
			}

			if (e.OldElement != null)
			{
				var page = e.OldElement as BottomTabbedPage;
				((IPageController)page).InternalChildren.CollectionChanged -= OnChildrenCollectionChanged;
			}

			if (e.NewElement != null)
			{
				var page = e.NewElement as BottomTabbedPage;
				((IPageController)page).InternalChildren.CollectionChanged += OnChildrenCollectionChanged;

				OnChildrenCollectionChanged(null, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			}
		}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			base.OnLayout(changed, l, t, r, b);

			int width = r - l;
			int height = b - t;

			bottomNavigationView.Measure(MakeMeasureSpec(width, MeasureSpecMode.Exactly), MakeMeasureSpec(height, MeasureSpecMode.AtMost));

			var viewHeight = Math.Min(height, Math.Max(bottomNavigationView.MeasuredHeight, bottomNavigationView.MinimumHeight));
			var viewY = height - viewHeight;

			bottomNavigationView.Layout(0, viewY, width, height);
		}

		public static int MakeMeasureSpec(int size, MeasureSpecMode mode)
		{
			return size + (int)mode;
		}

		private void HideTabLayout()
		{
			for (int i = 0; i < ViewGroup.ChildCount; i++)
			{
				var child = ViewGroup.GetChildAt(i);
				var tabLayout = child as TabLayout;
				if (tabLayout != null)
				{
					tabLayout.Visibility = ViewStates.Gone;
				}
			}
		}

		void OnChildrenCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}
	}
}