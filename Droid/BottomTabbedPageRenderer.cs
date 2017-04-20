using System;
using System.Collections.Specialized;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Content.Res;
using Android.Support.V4.View;
using Android.Support.V7.View;
using AndroidTabbedRenderer;
using AndroidTabbedRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

using Color = Android.Graphics.Color;
using Android.Support.V7.View.Menu;
using Java.Util.Logging;
using Android.Animation;
using Android.Views.Animations;

[assembly: ExportRenderer(typeof(BottomTabbedPage), typeof(BottomTabbedPageRenderer))]
namespace AndroidTabbedRenderer.Droid
{
    public class BottomTabbedPageRenderer : TabbedPageRenderer, BottomNavigationView.IOnNavigationItemSelectedListener, IBottomTabbedPageRenderer
    {
        TabLayout tabLayout;
        ViewPager viewPager;

        BottomNavigationView bottomNavigationView;

        private bool slidingUp;
        private bool slidingDown;

        public bool SlidingDown
        {
            get
            {
                return slidingDown;
            }

            set
            {
                slidingDown = value;
            }
        }

        public bool SlidingUp
        {
            get
            {
                return slidingUp;
            }

            set
            {
                slidingUp = value;
            }
        }

        public BottomNavigationView BottomNavigationView
        {
            get
            {
                return bottomNavigationView;
            }

            private set
            {
                bottomNavigationView = value;
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (BottomNavigationView == null)
            {
                FindViews();

                tabLayout.Visibility = ViewStates.Gone;

                BottomNavigationView = new BottomNavigationView(this.Context);
                BottomNavigationView.SetBackgroundColor(Color.White);
                BottomNavigationView.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
                AddView(BottomNavigationView);

                BottomNavigationView.SetOnNavigationItemSelectedListener(this);
            }

            if (e.OldElement != null)
            {
                var tabbedPage = e.OldElement as BottomTabbedPage;
                if (tabbedPage != null)
                {
                    tabbedPage.Renderer = null;
                }
            }

            if (e.NewElement != null)
            {
                var page = e.NewElement as BottomTabbedPage;

                page.Renderer = this;

                if (page.AndroidMenu == BottomMenu.Photos)
                {
                    BottomNavigationView.InflateMenu(Resource.Menu.photos_menu);
                }
                else if (page.AndroidMenu == BottomMenu.Files)
                {
                    BottomNavigationView.InflateMenu(Resource.Menu.files_menu);
                }
                else if (page.AndroidMenu == BottomMenu.Trash)
                {
                    BottomNavigationView.InflateMenu(Resource.Menu.trash_menu);
                }
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            int width = r - l;
            int height = b - t;

            BottomNavigationView.Measure(MakeMeasureSpec(width, MeasureSpecMode.Exactly), MakeMeasureSpec(height, MeasureSpecMode.AtMost));

            var viewHeight = Math.Min(height, Math.Max(BottomNavigationView.MeasuredHeight, BottomNavigationView.MinimumHeight));
            var viewY = height - viewHeight;

            BottomNavigationView.Layout(0, viewY, width, height);
        }

        public static int MakeMeasureSpec(int size, MeasureSpecMode mode)
        {
            return size + (int)mode;
        }

        private void FindViews()
        {
            for (int i = 0; i < ViewGroup.ChildCount; i++)
            {
                var child = ViewGroup.GetChildAt(i);

                var asTabLayout = child as TabLayout;
                if (asTabLayout != null)
                    this.tabLayout = asTabLayout;

                var asViewPager = child as ViewPager;
                if (asViewPager != null)
                    this.viewPager = asViewPager;
            }
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            var index = item.Order;

            if (index < viewPager.Adapter.Count)
            {
                viewPager.CurrentItem = index;
                return true;
            }

            return false;
        }

        public void Hide()
        {
            BottomNavigationView.Visibility = ViewStates.Invisible;
        }

        public void Show()
        {
            BottomNavigationView.Visibility = ViewStates.Visible;
        }

        public void SlideUp()
        {
            var currentY = BottomNavigationView.TranslationY;

            if (currentY == 0 || slidingUp)
                return;

            bottomNavigationView.Animate().Cancel();

            SlidingUp = true;

            bottomNavigationView
                .Animate()
                .TranslationY(0)
                .SetDuration(250)
                .SetListener(new BottomTabAnimationListener(this))
                .Start();
        }

        public void SlideDown()
        {
            var navigationBarHeight = BottomNavigationView.Height;
            var currentY = BottomNavigationView.TranslationY;
            var currentX = BottomNavigationView.TranslationX;

            if (currentY == navigationBarHeight || slidingDown)
                return;

            bottomNavigationView.Animate().Cancel();

            SlidingDown = true;

            bottomNavigationView
                .Animate()
                .TranslationY(navigationBarHeight)
                .SetDuration(250)
                .SetListener(new BottomTabAnimationListener(this))
                .Start();
        }
    }
    class BottomTabAnimationListener : Java.Lang.Object, Animator.IAnimatorListener
    {
        BottomTabbedPageRenderer renderer;

        public BottomTabAnimationListener(BottomTabbedPageRenderer renderer)
        {
            this.renderer = renderer;
        }
        public void OnAnimationCancel(Animator animation)
        {
            UpdateFlags();
        }

        public void OnAnimationEnd(Animator animation)
        {
            UpdateFlags();
        }

        public void OnAnimationRepeat(Animator animation)
        {
        }

        public void OnAnimationStart(Animator animation)
        {
        }

        private void UpdateFlags()
        {
            if (renderer.SlidingUp)
                renderer.SlidingUp = false;
            
            if (renderer.SlidingDown)
                renderer.SlidingDown = false;
        }
    }
}