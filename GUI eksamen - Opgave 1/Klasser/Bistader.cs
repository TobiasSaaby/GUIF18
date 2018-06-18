using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_eksamen___Opgave_1
{
    class Bistader : ObservableCollection<MideTal>, INotifyPropertyChanged
    {
        private string name;
        private List<MideTal> stadeTal;

        public Bistader(string navn)
        {
            name = navn;
            stadeTal = new List<MideTal>();
        }

        public string Name { get { return name; } set { name = value; NotifyPropertyChanged(); } }
        public List<MideTal> StadeTal { get { return stadeTal; } set { stadeTal = value; NotifyPropertyChanged(); } }



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
