using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Territory;

public class ColourConverter : IValueConverter
{
    private static readonly Color[] Palette =
    {
        Colors.Red,
        Colors.Blue,
        Colors.Green,
        Colors.Orange,
        Colors.Gold,
        Colors.MediumPurple,
        Colors.DeepPink,
        Colors.Teal
    };

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo cultureInfo)
    {
        // if value is a Player object, use their custom color
        if (value is Player player)
        {
            if (!string.IsNullOrWhiteSpace(player.Color) && player.Color.StartsWith("#"))
            {
                try
                {
                    var col = Color.Parse(player.Color);
                    return new SolidColorBrush(col);
                }
                catch
                {
                    // fallback to palette if custom color fails
                    if (int.TryParse(player.Id, out var id) && id >= 1)
                    {
                        var index = (id - 1) % Palette.Length;
                        return new SolidColorBrush(Palette[index]);
                    }
                    return new SolidColorBrush(Colors.LightGray);
                }
            }
            // no custom color, use default palette by ID
            if (int.TryParse(player.Id, out var playerId) && playerId >= 1)
            {
                var index = (playerId - 1) % Palette.Length;
                return new SolidColorBrush(Palette[index]);
            }
            return new SolidColorBrush(Colors.LightGray);
        }

        // if value is a string (for backward compat)
        if (value is string colorName)
        {
            // if value is numeric id use palette
            if (int.TryParse(colorName, out var playerId) && playerId >= 1)
            {
                var index = (playerId - 1) % Palette.Length;
                return new SolidColorBrush(Palette[index]);
            }

            // if value is a hex color string like #RRGGBB or #AARRGGBB
            if (!string.IsNullOrWhiteSpace(colorName) && colorName.StartsWith("#"))
            {
                try
                {
                    var col = Color.Parse(colorName);
                    return new SolidColorBrush(col);
                }
                catch
                {
                    return new SolidColorBrush(Colors.LightGray);
                }
            }

            if (string.IsNullOrEmpty(colorName))
                return new SolidColorBrush(Colors.LightGray);

            return new SolidColorBrush(Colors.LightGray);
        }

        return new SolidColorBrush(Colors.LightGray);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo cultureInfo)
    {
        throw new NotSupportedException();
    }
}
