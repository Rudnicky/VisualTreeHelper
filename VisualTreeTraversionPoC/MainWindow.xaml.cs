using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using VisualTreeTraversionPoC.Utils;

namespace VisualTreeTraversionPoC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle rectangle)
            {
                var stackPanel = VisualTreeTraverseHelper.FindParent<StackPanel>(rectangle);
                if (stackPanel != null)
                {
                    // we've got this!
                }

                var grid = VisualTreeTraverseHelper.FindParent<Grid>(rectangle);
                if (grid != null)
                {
                    // we've got this!
                }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                var rectangle = VisualTreeTraverseHelper.FindChild<Rectangle>(grid, "MagnificientRectangle");
                if (rectangle != null)
                {
                    // we've got this!
                }
            }
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is StackPanel stackPanel)
            {
                var rectangles = VisualTreeTraverseHelper.FindVisualChildren<Rectangle>(stackPanel);
                if (rectangles != null)
                {
                    foreach (var rectangle in rectangles)
                    {
                        // it should've been here
                    }
                }

                var rect = VisualTreeTraverseHelper.GetChildOfType<Rectangle>(stackPanel);
                if (rect != null)
                {

                }
            }
        }
    }
}
