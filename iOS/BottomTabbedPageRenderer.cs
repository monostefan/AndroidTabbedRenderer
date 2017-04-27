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
            if (TabBar.Hidden)
                return;

            TabBar.Hidden = true;
            TabBar.Alpha = 0;
        }

        public void Show()
        {
            if (!TabBar.Hidden)
                return;

            TabBar.Hidden = false;
            TabBar.Alpha = 1;
        }

        public void SlideUp()
        {
            if (TabBar.Hidden)
                return;

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
            if (TabBar.Hidden)
                return;

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
