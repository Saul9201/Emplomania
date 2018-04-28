using Emplomania.Data.VO.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Emplomania.UI.Converters
{
    public class ListNomenclToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<NomenclatorVO> list = value as IEnumerable<NomenclatorVO>;
            return list == null || list.Count() == 0 ? "Ninguno" : list.First().Name + (list.Count() > 1 ? " y otros" : "");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
