using System;
using System.Windows.Data;
using System.Globalization;

namespace WFDMemberStatus.SharedConverters
{
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class MarkTrainingIncomplete : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value is DateTime time && time == default ? "Incomplete" : value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
