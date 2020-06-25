using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WFDMemberStatus.SharedConverters
{
    [ValueConversion(typeof(string), typeof(Visibility))]
    public class CollapsableTextBox : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
