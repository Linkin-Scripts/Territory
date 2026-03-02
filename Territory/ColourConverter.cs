using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Territory;

public class ColourConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo cultureInfo)
    {
        if (value is string colorName)
        {
            return colorName switch 
            {
                "0" => new SolidColorBrush(Colors.Red),
                "1" => new SolidColorBrush(Colors.Blue),
                "2" => new SolidColorBrush(Colors.Green),
                _ => new SolidColorBrush(Colors.LightGray)
            };
        }
        return new SolidColorBrush(Colors.LightGray);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo cultureInfo)
    {
        throw new NotSupportedException();
    }
}