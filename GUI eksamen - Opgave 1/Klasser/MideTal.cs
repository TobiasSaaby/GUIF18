using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GUI_eksamen___Opgave_1
{
    class MideTal : INotifyPropertyChanged
    {
        private DateTime dato;
        private int antal;
        private string kommentar;

        public MideTal(DateTime Dato, int Antal, string Kommentar)
        {
            dato = Dato;
            antal = Antal;
            kommentar = Kommentar;
        }


        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
