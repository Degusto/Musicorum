using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

using ValueDescription = System.Collections.Generic.KeyValuePair<System.Enum, string>;

namespace Podemski.Musicorum.UI.Converters
{
    [ValueConversion(typeof(Enum), typeof(IEnumerable<ValueDescription>))]
    public class EnumToCollectionConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return EnumHelper.GetAllValuesAndDescriptions(value.GetType());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

    public static class EnumHelper
    {
        public static string Description(this Enum value)
        {
            object[] attributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Any())
            {
                return (attributes.First() as DescriptionAttribute).Description;
            }

            return value.ToString();
        }

        public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions(Type t)
        {
            if (!t.IsEnum)
            {
                throw new ArgumentException($"{nameof(t)} must be an enum type");
            }

            return Enum.GetValues(t).Cast<Enum>().Select((e) => new KeyValuePair<Enum, string>(e, e.Description())).ToList();
        }
    }
}
