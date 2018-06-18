using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Diagnostics;

namespace GUI_eksamen___Opgave_1
{
    class IdColourConvertion : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Debug.Assert(targetType == typeof(Brush));
            string id = value as string;
            if (id == null)
                id = "";
            // 007 requires special treatment...
            return (id == "Bikube" ? Brushes.Blue : Brushes.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
