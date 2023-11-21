// StrikeThroughConverter.cs
using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace RecipeApp.Converters
{
    public class StrikeThroughConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 1 && values[0] is bool isChecked)
            {
                if (isChecked)
                {
                    return TextDecorations.Strikethrough;
                }
            }
            return TextDecorations.None;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
