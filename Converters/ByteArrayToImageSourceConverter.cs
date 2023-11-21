using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;

namespace RecipeApp.Converters
{
    [ContentProperty(nameof(Source))]
    public class ByteArrayToImageSourceConverter : IValueConverter, IMarkupExtension
    {
        public ImageSource Source { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] byteArray)
            {
                return ImageSource.FromStream(() => new System.IO.MemoryStream(byteArray));
            }

            return Source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
