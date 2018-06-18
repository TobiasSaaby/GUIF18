using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmFoundation.Wpf;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Media;
using System.Windows.Data;
using Microsoft.Win32;

namespace GUI_eksamen___Opgave_1
{
    
    public class Bistader : ObservableCollection<Bistad>, INotifyPropertyChanged
    {
        const string AppTitle = "GUI - Eksamensopgave F18";
        string filename = "";
        string filePath = "";
        string filter;
        bool dirty = false;

        public Bistader()
        {
            if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                // In Design mode
                Add(new Bistad("Nummer 1"));
                Add(new Bistad("Nummer 2"));
                Title = "Untitled - " + AppTitle;
            }
            Title = "Untitled - " + AppTitle;
        }

        #region Bistad Commands

        ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddBistad)); }
        }

        private void AddBistad()
        {
            // Show Modal Dialog
            var dlg = new AddBistad();
            dlg.Title = "Opret Nyt Bistad";
            Bistad nyBistad = new Bistad();
            dlg.DataContext = nyBistad;
            if (dlg.ShowDialog() == true)
            {
                Add(nyBistad);
                currentBistad = nyBistad;
                NotifyPropertyChanged("Count");
                dirty = true;
            }
        }

        ICommand _editCommand;
        public ICommand EditCommand
        {
            get { return _editCommand ?? (_editCommand = new RelayCommand(EditBistad, DeleteBistad_CanExecute)); }
        }

        private void EditBistad()
        {
            // Show Modal Dialog
            var dlg = new AddBistad();
            dlg.Title = "Redigér Bistad";
            // Need a temp agent in case of cancel
            Bistad tmpBistad = new Bistad();
            tmpBistad.Name = CurrentBistad.Name;
            dlg.DataContext = tmpBistad;
            if (dlg.ShowDialog() == true)
            {
                CurrentBistad.Name = tmpBistad.Name;
                dirty = true;
            }
        }

        ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteBistad, DeleteBistad_CanExecute)); }
        }

        private void DeleteBistad()
        {
            MessageBoxResult res = MessageBox.Show("Er du sikker på at du vil slette bistaden: " + CurrentBistad.Name +
                "?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                Remove(CurrentBistad);
                NotifyPropertyChanged("Count");
                dirty = true;
            }
        }

        private bool DeleteBistad_CanExecute()
        {
            if (Count > 0 && CurrentIndex >= 0)
                return true;
            else
                return false;
        }
        #endregion

        #region Generelle Commands
        ICommand _nextCommand;
        public ICommand NextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand = new RelayCommand(
                    () => ++CurrentIndex,
                    () => CurrentIndex < (Count - 1)));
            }
        }

        ICommand _PreviusCommand;
        public ICommand PreviusCommand
        {
            get { return _PreviusCommand ?? (_PreviusCommand = new RelayCommand(PreviusCommandExecute, PreviusCommandCanExecute)); }
        }

        private void PreviusCommandExecute()
        {
            if (CurrentIndex > 0)
                --CurrentIndex;
        }

        private bool PreviusCommandCanExecute()
        {
            if (CurrentIndex > 0)
                return true;
            else
                return false;
        }

        ICommand _ColorCommand;
        public ICommand ColorCommand
        {
            get { return _ColorCommand ?? (_ColorCommand = new RelayCommand<String>(ColorCommand_Execute)); }
        }

        private void ColorCommand_Execute(String colorStr)
        {
            SolidColorBrush newBrush = SystemColors.WindowBrush; // Default color

            try
            {
                if (colorStr != null)
                {
                    if (colorStr != "Default")
                        newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorStr));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unknown color name, default color is used", "Program error!");
            }

            Application.Current.MainWindow.Resources["BackgroundBrush"] = newBrush;
        }
        #endregion // Commands

        #region Properties

        int currentIndex = -1;

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (currentIndex != value)
                {
                    currentIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        Bistad currentBistad = null;

        public Bistad CurrentBistad
        {
            get { return currentBistad; }
            set
            {
                if (currentBistad != value)
                {
                    currentBistad = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public new event PropertyChangedEventHandler PropertyChanged;

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
