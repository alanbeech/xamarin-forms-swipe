using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SwipeableImageExample
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            SwipeableImage.SwipedUp += (sender, args) => { DirectionInfo.Text = "UP"; };
            SwipeableImage.SwipedDown += (sender, args) => { DirectionInfo.Text = "DOWN"; };
            SwipeableImage.SwipedLeft += (sender, args) => { DirectionInfo.Text = "LEFT"; };
            SwipeableImage.SwipedRight += (sender, args) => { DirectionInfo.Text = "RIGHT"; };
        }
    }
}
