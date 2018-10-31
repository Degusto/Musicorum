using System.Windows;

namespace Podemski.Musicorum.UI.Extensions
{
    internal static class FrameworkElementExtensions
    {
        internal static T GetDataContext<T>(this FrameworkElement frameworkElement) => (T)frameworkElement.DataContext;
    }
}
