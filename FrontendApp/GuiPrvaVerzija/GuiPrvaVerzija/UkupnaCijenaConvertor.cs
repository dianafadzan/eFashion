using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GuiPrvaVerzija
{
    class UkupnaCijenaConvertor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameters, System.Globalization.CultureInfo culture)
        {
            int kol = Int32.Parse(values[0].ToString());
            double cijena = Double.Parse(values[1].ToString());
            string pom= (kol*cijena).ToString();
            return pom;
            

        }



        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
}
