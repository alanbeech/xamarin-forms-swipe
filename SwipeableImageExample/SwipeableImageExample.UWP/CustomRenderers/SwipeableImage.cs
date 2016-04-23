using System;
using Windows.UI.Xaml.Input;
using SwipeableImageExample.CustomRenderer;
using SwipeableImageExample.UWP.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(SwipeableImage), typeof(SwipeableUwpImageRenderer))]
namespace SwipeableImageExample.UWP.CustomRenderers
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class SwipeableUwpImageRenderer : ImageRenderer
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }

        public SwipeableImage SwipeableImage { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            SwipeableImage = (SwipeableImage)e.NewElement;

            ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
            ManipulationStarted += SwipeableUwpImageRenderer_ManipulationStarted;
            ManipulationCompleted += SwipeableUwpImageRenderer_ManipulationCompleted;
        }

        private void SwipeableUwpImageRenderer_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            X2 = (int)e.Position.X;
            Y2 = (int)e.Position.Y;

            var xChange = X1 - X2;
            var yChange = Y1 - Y2;

            var xChangeSize = Math.Abs(xChange);
            var yChangeSize = Math.Abs(yChange);

            if (xChangeSize > yChangeSize)
            {
                // horizontal
                if (X1 > X2)
                {
                    // left
                    SwipeableImage.RaiseSwipedLeft();
                }
                else
                {
                    // right
                    SwipeableImage.RaiseSwipedRight();
                }
            }
            else
            {
                // vertical
                if (Y1 > Y2)
                {
                    // left
                    SwipeableImage.RaiseSwipedUp();
                }
                else
                {
                    // right
                    SwipeableImage.RaiseSwipedDown();
                }
            }

            
        }

        private void SwipeableUwpImageRenderer_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            X1 = (int) e.Position.X;
            Y1 = (int) e.Position.Y;
        }
    }
}
