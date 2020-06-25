using System;
using System.Windows.Data;
using System.Globalization;

namespace WFDMemberStatus.SharedConverters
{
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is DateTime && (DateTime)value < new DateTime(2, 1, 1))
            {
                return "";
            }
            else return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
