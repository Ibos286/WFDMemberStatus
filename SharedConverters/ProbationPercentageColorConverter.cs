using System;
using System.Globalization;
using System.Windows.Data;

namespace WFDMemberStatus.SharedConverters
{
    public class ProbationPercentageColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is double && (double)value < 30.00)
            {
                return "Red";
            }
            else return "Green";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
