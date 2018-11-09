using System.Windows;
using System.Windows.Media;

namespace VisualTreeTraversionPoC.Utils
{
    public static class VisualTreeTraverseHelper
    {
        public static T FindParent<T>(this DependencyObject child)
            where T : DependencyObject
        {
            var parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) return null;

            if (parentObject is T parent)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }
    }
}
