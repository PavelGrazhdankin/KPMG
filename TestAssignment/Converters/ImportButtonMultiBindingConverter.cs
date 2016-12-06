using System;
using System.Globalization;
using System.Windows.Data;

namespace TestAssignment.Converters
{
    public class ImportButtonMultiBindingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var first = false;
            var res1 = bool.TryParse(values[0].ToString(), out first);

            var second = true;
            var res2 = bool.TryParse(values[1].ToString(), out second);

            var res = first && !second;
            return res;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}