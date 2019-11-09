using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;


namespace OficinaMVVM.Converters
{
    public class AtendimentoFinalizadoColor 
    {
        public  object Convert(object value , Type targetType, object  parameter,CultureInfo culture)
        {
            if ((bool)value)
                return Color.Yellow;
                 return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
