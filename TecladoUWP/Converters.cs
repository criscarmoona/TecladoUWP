using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;


namespace TecladoUWP
{
    public class BoolToSolidBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string str)
        {
            if ((bool)value)
            {
                return new SolidColorBrush(Windows.UI.Color.FromArgb(128, 128, 128, 128));
            }
            else
            {
                return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 128, 128));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string str)
        {
            return null;
        }
    }
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string str)
        {
            switch (parameter as string)
            {
                case "VisibleIfTrue": return (bool)value == true ? Visibility.Visible : Visibility.Collapsed;
                case "CollapsedIfTrue": return (bool)value == true ? Visibility.Collapsed : Visibility.Visible;
                default: return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string str)
        {
            return null;
        }
    }
}
