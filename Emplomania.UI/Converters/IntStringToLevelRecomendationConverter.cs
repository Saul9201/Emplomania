using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Emplomania.UI.Converters
{
    public class IntStringToLevelRecomendationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var ParameterString = parameter as string;
            if (ParameterString == null)
                return DependencyProperty.UnsetValue;

            var ParameterInt = int.Parse(ParameterString);
            var lr = int.Parse(value.ToString());
            if (ParameterInt <= lr)
                return "/Emplomania.UI;component/Images/estrella-llena.png";
            else
                return "/Emplomania.UI;component/Images/estrella-vacia.png";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
