using Xamarin.Forms;

namespace SwipeableImageExample
{
    public partial class SwipeableExamplePage : ContentPage
    {
        public SwipeableExamplePage()
        {
            InitializeComponent();

            SwipeableImage.SwipedUp += (sender, args) => { DirectionInfo.Text = "UP"; };
            SwipeableImage.SwipedDown += (sender, args) => { DirectionInfo.Text = "DOWN"; };
            SwipeableImage.SwipedLeft += (sender, args) => { DirectionInfo.Text = "LEFT"; };
            SwipeableImage.SwipedRight += (sender, args) => { DirectionInfo.Text = "RIGHT"; };
        }
    }
}
