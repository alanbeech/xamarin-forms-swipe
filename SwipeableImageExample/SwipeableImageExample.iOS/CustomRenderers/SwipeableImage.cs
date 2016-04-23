using System;
using SwipeableImageExample.CustomRenderer;
using SwipeableImageExample.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SwipeableImage), typeof(SwipeableIosImageRenderer))]
namespace SwipeableImageExample.iOS.CustomRenderers
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);
    public class SwipeableIosImageRenderer : ImageRenderer
    {

        UISwipeGestureRecognizer swipeUpGestureRecognizer;
        UISwipeGestureRecognizer swipeDownGestureRecognizer;
        UISwipeGestureRecognizer swipeLeftGestureRecognizer;
        UISwipeGestureRecognizer swipeRightGestureRecognizer;


        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            swipeUpGestureRecognizer = new UISwipeGestureRecognizer(() => {
                var picture = (SwipeableImage)e.NewElement;
                if (swipeUpGestureRecognizer.Direction == UISwipeGestureRecognizerDirection.Up)
                    picture.RaiseSwipedUp();
            });
            swipeUpGestureRecognizer.Direction = UISwipeGestureRecognizerDirection.Up;

            swipeDownGestureRecognizer = new UISwipeGestureRecognizer(() => {
                var picture = (SwipeableImage)e.NewElement;
                if (swipeDownGestureRecognizer.Direction == UISwipeGestureRecognizerDirection.Down)
                    picture.RaiseSwipedDown();
            });
            swipeDownGestureRecognizer.Direction = UISwipeGestureRecognizerDirection.Down;
            
            swipeLeftGestureRecognizer = new UISwipeGestureRecognizer(() => {
                var picture = (SwipeableImage)e.NewElement;
                if (swipeLeftGestureRecognizer.Direction == UISwipeGestureRecognizerDirection.Left)
                    picture.RaiseSwipedLeft();
            });
            swipeLeftGestureRecognizer.Direction = UISwipeGestureRecognizerDirection.Left;
            
            swipeRightGestureRecognizer = new UISwipeGestureRecognizer(() => {
                var picture = (SwipeableImage)e.NewElement;
                if (swipeRightGestureRecognizer.Direction == UISwipeGestureRecognizerDirection.Right)
                    picture.RaiseSwipedRight();
            });
            swipeRightGestureRecognizer.Direction = UISwipeGestureRecognizerDirection.Right;

            if (e.NewElement == null)
            {

                if (swipeUpGestureRecognizer != null)
                {
                    this.RemoveGestureRecognizer(swipeUpGestureRecognizer);
                }
                if (swipeDownGestureRecognizer != null)
                {
                    this.RemoveGestureRecognizer(swipeDownGestureRecognizer);
                }
                if (swipeLeftGestureRecognizer != null)
                {
                    this.RemoveGestureRecognizer(swipeLeftGestureRecognizer);
                }
                if (swipeRightGestureRecognizer != null)
                {
                    this.RemoveGestureRecognizer(swipeRightGestureRecognizer);
                }

            }

            if (e.OldElement == null)
            {
                this.AddGestureRecognizer(swipeUpGestureRecognizer);
                this.AddGestureRecognizer(swipeDownGestureRecognizer);
                this.AddGestureRecognizer(swipeLeftGestureRecognizer);
                this.AddGestureRecognizer(swipeRightGestureRecognizer);
            }
        }
    }
}

