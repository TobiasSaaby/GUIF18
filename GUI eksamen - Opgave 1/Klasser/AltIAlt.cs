using Microsoft.Win32;
using MvvmFoundation.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_eksamen___Opgave_1
{
    class AltIAlt
    {
        const string AppTitle = "GUI - Eksamensopgave F18";
        string filename = "";
        string filePath = "";
        bool dirty = false;

        public Bistader Bistaderne { get; set; }
        public AlleMider Miderne { get; set; }
        public AltIAlt()
        {
            Bistaderne = new Bistader();
            Miderne = new AlleMider();
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
                    Bistaderne.CurrentBistad = value;
                    Miderne.CurrentBistad = value;
                }
            }
        }

        #region Generelle Commands
       
        ICommand _SaveAsCommand;
        public ICommand SaveAsCommand
        {
            get { return _SaveAsCommand ?? (_SaveAsCommand = new RelayCommand(SaveAsCommand_Execute)); }
        }

        private void SaveAsCommand_Execute()
        {
            var dialog = new SaveFileDialog();

            dialog.Filter = "Bistadsdokument|*.bi|All Files|*.*";
            dialog.DefaultExt = "bi";
            if (filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(filePath);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                filePath = dialog.FileName;
                filename = Path.GetFileName(filePath);
                SaveFile();
                Title = filename + " - " + AppTitle;
            }
        }

        ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get { return _SaveCommand ?? (_SaveCommand = new RelayCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute)); }
        }

        private void SaveFileCommand_Execute()
        {
            SaveFile();
        }

        private void SaveFile()
        {
            try
            {
                // Copy the agents to a List. 
                TupleIsh<List<Bistad>, List<MideTal>> tmpAlt;
                tmpAlt = Tuple.Create(Bistaderne.ToList<Bistad>(),Miderne.ToList <MideTal>()) ;
                
                Repository.SaveFile(filePath, tmpAlt);
                dirty = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool SaveFileCommand_CanExecute()
        {
            return (filename != "");
        }

        ICommand _NewFileCommand;
        public ICommand NewFileCommand
        {
            get { return _NewFileCommand ?? (_NewFileCommand = new RelayCommand(NewFileCommand_Execute)); }
        }

        private void NewFileCommand_Execute()
        {
            if (dirty)
            {
                MessageBoxResult res = MessageBox.Show("Du har data der ikke er gemt! Er du sikker på at du vil lukke uden at gemme?",
                    "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (res == MessageBoxResult.No)
                {
                    return;
                }
            }

            Bistaderne.Clear();
            Miderne.Clear();
            filename = "";
            Title = "Untitled - " + AppTitle;
            dirty = false;
        }


        ICommand _OpenFileCommand;
        public ICommand OpenFileCommand
        {
            get { return _OpenFileCommand ?? (_OpenFileCommand = new RelayCommand<string>(OpenFileCommand_Execute)); }
        }

        private void OpenFileCommand_Execute(string argFilename)
        {
            Tuple<List<Bistad>, List<MideTal>> tmpalles;
            var dialog = new OpenFileDialog();

            if (dirty)
            {
                MessageBoxResult res = MessageBox.Show("Du har data der ikke er gemt! Er du sikker på at du vil lukke uden at gemme?",
                    "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (res == MessageBoxResult.No)
                {
                    return;
                }
            }

            dialog.Filter = "Bistadsdokument|*.bi|All Files|*.*";
            dialog.DefaultExt = "bi";
            if (filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(filePath);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                filePath = dialog.FileName;
                filename = Path.GetFileName(filePath);
                try
                    
                {
                 
                    Repository.ReadFile(filePath, out tmpalles);

                    // We have to insert the agents in the existing collection. 
                    Bistaderne.Clear();
                    Miderne.Clear();
                    foreach (var bistad in tmpalles.Item1)
                        Bistaderne.Add(bistad);
                    foreach (var mide in tmpalles.Item2)
                        Miderne.Add(mide);
                    Title = filename + " - " + AppTitle;
                    dirty = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kan ikke åbne filen!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        ICommand _CloseAppCommand;
        public ICommand CloseAppCommand
        {
            get { return _CloseAppCommand ?? (_CloseAppCommand = new RelayCommand(CloseCommand_Execute)); }
        }

        private void CloseCommand_Execute()
        {
            bool regret = false;

            if (dirty)
            {
                MessageBoxResult res = MessageBox.Show("Du har data der ikke er gemt! Er du sikker på at du vil lukke uden at gemme?",
                    "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (res == MessageBoxResult.No)
                {
                    regret = true;
                }
            }
            if (!regret)
                Application.Current.MainWindow.Close();
        }

       
        #endregion // Commands


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
