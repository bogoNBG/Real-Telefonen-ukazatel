using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if (values[0] is List<Link> links && values[1] is ObservableCollection<Option> options)
            {
                string output = string.Empty;
                foreach(Option option in options)
                {
                    output += $"{option.Name}:\n";
                    foreach(Link link in links)
                    {
                        if (option.Id == link.OptionId)
                        {
                            output += $"{link.Name}\n";
                        }
                    }
                }
                //string names = string.Empty;
                //foreach (Link link in links)
                //{
                //    names += $"{link.OptionId}: {link.Name}\n";
                //}
                //return values[1] + names;
                //return values[1];
                return output;
            }
            return "ne e";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
