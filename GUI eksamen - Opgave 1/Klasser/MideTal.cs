using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GUI_eksamen___Opgave_1
{
    public class MideTal : INotifyPropertyChanged
    {
        private Bistad tilhorer;
        private DateTime dato;
        private int antal;
        private string kommentar;


        public MideTal()
        {
            dato = DateTime.Now;
        }

        public MideTal(DateTime Dato, int Antal, string Kommentar)
        {
            dato = Dato;
            antal = Antal;
            kommentar = Kommentar;
        }

        public Bistad Tilhorer { get { return tilhorer; } set { tilhorer = value; NotifyPropertyChanged(); } }
        public DateTime Dato { get { return dato; } set { dato = value; NotifyPropertyChanged(); } }
        public int Antal { get { return antal; } set { antal = value; NotifyPropertyChanged(); } }
        public string Kommentar { get { return kommentar; } set { kommentar = value; NotifyPropertyChanged(); } }

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
