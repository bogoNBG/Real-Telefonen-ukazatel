using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfApp4.Model;

namespace WpfApp4.View
{
    class AdditionalInfoConverter : IMultiValueConverter
    {         

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is List<Link> links)
            {
                string names = string.Empty;
                foreach (Link link in links)
                {
                    names += $"{link.OptionId}: {link.Name}\n";
                }
                return names;
                //return values[1];
            }
            return "uq";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
