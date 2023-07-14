using System.Globalization;

namespace Tonestro.Prism.Plugin.Mopups.Dialogs;

internal class RelativeContentSizeConverter : IValueConverter
{
    private double relativeSize;
    public double RelativeSize
    {
        get => relativeSize;
        set
        {
            if (value == 0)
            {
                relativeSize = 1;
            }
            else if (value > 1)
            {
                relativeSize = value / 100;
            }
            else
            {
                relativeSize = value;
            }
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var pageSize = double.Parse(value.ToString());
        return RelativeSize * pageSize;
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ConvertBack(value, targetType, parameter, culture);
    }
}