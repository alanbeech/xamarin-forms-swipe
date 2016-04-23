using System;
using Android.Views;
using SwipeableImageExample.CustomRenderer;
using SwipeableImageExample.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SwipeableImage), typeof(SwipeableDroidImageRenderer))]
namespace SwipeableImageExample.Droid.CustomRenderers
{

    public class SwipeableDroidImageRenderer : ImageRenderer
    {
        public float X1 { get; set; }
        public float X2 { get; set; }
        public float Y1 { get; set; }
        public float Y2 { get; set; }

        public SwipeableImage SwipeableImage { get; set; }

        public override bool OnTouchEvent(MotionEvent e)
        {

            if (e.ActionMasked == MotionEventActions.Down)
            {
                X1 = e.GetX();
                Y1 = e.GetY();

                return true;
            }

            X2 = e.GetX();
            Y2 = e.GetY();

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
                    // up
                    SwipeableImage.RaiseSwipedUp();
                }
                else
                {
                    // down
                    SwipeableImage.RaiseSwipedDown();
                }
            }

            return base.OnTouchEvent(e);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> ev)
        {
            base.OnElementChanged(ev);

            SwipeableImage = (SwipeableImage)ev.NewElement;
        }
        
    }

}