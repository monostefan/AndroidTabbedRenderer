using System;

using Xamarin.Forms;

namespace AndroidTabbedRenderer
{
    public class BottomTabbedPage : TabbedPage
    {
        public IBottomTabbedPageRenderer renderer;

        public BottomMenu AndroidMenu { get; set; }

        public void Hide(object sender, EventArgs e)
        {
            renderer?.Hide();
        }

        public void Show(object sender, EventArgs e)
        {
            renderer?.Show();
        }

        public void SlideUp(object sender, EventArgs e)
        {
            renderer?.SlideUp();
        }

        public void SlideDown(object sender, EventArgs e)
        {
            renderer?.SlideDown();
        }
    }
}

