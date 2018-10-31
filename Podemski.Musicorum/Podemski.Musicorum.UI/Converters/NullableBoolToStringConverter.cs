using System;
using System.Globalization;
using System.Windows.Data;

namespace Podemski.Musicorum.UI.Converters
{
    [ValueConversion(typeof(bool?), typeof(string))]
    public sealed class NullableBoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return ThreeStateComboBoxItemsSource.None;
            }

            return (bool)value ? ThreeStateComboBoxItemsSource.Yes : ThreeStateComboBoxItemsSource.No;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case ThreeStateComboBoxItemsSource.Yes:
                    return true;
                case ThreeStateComboBoxItemsSource.No:
                    return false;
                default:
                    return null;
            }
        }
    }

    public static class ThreeStateComboBoxItemsSource
    {
        public const string None = "(none)";
        public const string Yes = "Yes";
        public const string No = "No";

        public static readonly string[] ItemsSource = new[] { None, Yes, No };
    }
}
