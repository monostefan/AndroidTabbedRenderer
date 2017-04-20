using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using AndroidTabbedRenderer;

[assembly: ExportRenderer(typeof(BottomTabbedPage), typeof(TabbedPageImplementation.iOS.TabbedPageRendereriOS))]
namespace TabbedPageImplementation.iOS
{
    public class TabbedPageRendereriOS : TabbedRenderer, IBottomTabbedPageRenderer
    {
        private bool tabBarHidden;
        private bool tabBarSlidedDown;

        private nfloat tabBarHeight;
        private nfloat screenHeight;

        private nfloat centerX;
        private nfloat centerY;

        IPageController PageController => Element as IPageController;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var tabbedPage = e.OldElement as BottomTabbedPage;
                if (tabbedPage != null)
                {
                    tabbedPage.Renderer = null;
                }
            }

            if (e.NewElement as BottomTabbedPage != null)
            {
                var tabbedPage = e.NewElement as BottomTabbedPage;
                if (tabbedPage != null)
                {
                    tabbedPage.Renderer = this;

                    tabBarHeight = TabBar.Frame.Height;

                    screenHeight = this.View.Frame.Height;

                    centerX = TabBar.Center.X;
                    centerY = TabBar.Center.Y;
                }
            }

            TabBar.BackgroundColor = UIColor.Gray;
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            if (Element == null)
                return;

            var frame = View.Frame;
            PageController.ContainerArea = new Rectangle(0, 0, frame.Width, frame.Height);
        }

        public void Hide()
        {
            if (tabBarHidden || tabBarSlidedDown)
                return;

            tabBarHidden = true;

            TabBar.Hidden = true;
        }

        public void Show()
        {
            if (!(tabBarHidden | tabBarSlidedDown))
                return;

            TabBar.Center = new CGPoint(centerX, centerY);

            tabBarHidden = false;
            tabBarSlidedDown = false;
            TabBar.Hidden = false;
        }

        public void SlideUp()
        {
            if (tabBarHidden)
                return;

            tabBarSlidedDown = false;

            var animationOptions = UIViewAnimationOptions.BeginFromCurrentState |
                                             UIViewAnimationOptions.CurveEaseInOut;

            Action noOpOnCompletion = () => { };

            Action slideUpAction = () =>
            {
                TabBar.LayoutIfNeeded();
                TabBar.Center = new CGPoint(centerX, centerY);
                TabBar.LayoutIfNeeded();
            };

            UIView.Animate(0.5, 0.0, animationOptions, slideUpAction, noOpOnCompletion);
        }

        public void SlideDown()
        {
            if (tabBarHidden)
                return;

            tabBarSlidedDown = true;

            var animationOptions = UIViewAnimationOptions.BeginFromCurrentState |
                                                                     UIViewAnimationOptions.CurveEaseInOut;

            Action noOpOnCompletion = () => { };

            Action slideDownAction = () =>
            {
                var newFrame = TabBar.Frame;
                newFrame.Offset(0, TabBar.Frame.Size.Height);
                TabBar.Frame = newFrame;
            };

            UIView.Animate(0.5, 0.0, animationOptions, slideDownAction, noOpOnCompletion);
        }
    }
}
