﻿using System;
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
    class AlleMider : ObservableCollection<MideTal>, INotifyPropertyChanged
    {
        string filename = "";
        string filePath = "";
        string filter;
        bool dirty = false;

        public AlleMider()
        {
            if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                // In Design mode
                Add(new MideTal(new DateTime(1992, 07, 31), 3000, "Nummer 1"));
                Add(new MideTal(new DateTime(1992, 03, 31), 323, "Nummer 2"));
            }
        }

        //#region Generelle Commands
        //ICommand _nextCommand;
        //public ICommand NextCommand
        //{
        //    get
        //    {
        //        return _nextCommand ?? (_nextCommand = new RelayCommand(
        //            () => ++CurrentIndex,
        //            () => CurrentIndex < (Count - 1)));
        //    }
        //}

        //ICommand _PreviusCommand;
        //public ICommand PreviusCommand
        //{
        //    get { return _PreviusCommand ?? (_PreviusCommand = new RelayCommand(PreviusCommandExecute, PreviusCommandCanExecute)); }
        //}

        //private void PreviusCommandExecute()
        //{
        //    if (CurrentIndex > 0)
        //        --CurrentIndex;
        //}

        //private bool PreviusCommandCanExecute()
        //{
        //    if (CurrentIndex > 0)
        //        return true;
        //    else
        //        return false;
        //}

        //ICommand _SaveAsCommand;
        //public ICommand SaveAsCommand
        //{
        //    get { return _SaveAsCommand ?? (_SaveAsCommand = new RelayCommand(SaveAsCommand_Execute)); }
        //}

        //private void SaveAsCommand_Execute()
        //{
        //    var dialog = new SaveFileDialog();

        //    dialog.Filter = "Bistadsdokument|*.bi|All Files|*.*";
        //    dialog.DefaultExt = "bi";
        //    if (filePath == "")
        //        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    else
        //        dialog.InitialDirectory = Path.GetDirectoryName(filePath);

        //    if (dialog.ShowDialog(App.Current.MainWindow) == true)
        //    {
        //        filePath = dialog.FileName;
        //        filename = Path.GetFileName(filePath);
        //        SaveFile();
        //        Title = filename + " - " + AppTitle;
        //    }
        //}

        //ICommand _SaveCommand;
        //public ICommand SaveCommand
        //{
        //    get { return _SaveCommand ?? (_SaveCommand = new RelayCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute)); }
        //}

        //private void SaveFileCommand_Execute()
        //{
        //    SaveFile();
        //}

        //private void SaveFile()
        //{
        //    List<Bistad> tmpBistader;

        //    try
        //    {
        //        // Copy the agents to a List. 
        //        tmpBistader = this.ToList<Bistad>();
        //        Repository.SaveFile(filePath, tmpBistader);
        //        dirty = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        //private bool SaveFileCommand_CanExecute()
        //{
        //    return (filename != "") && (Count > 0);
        //}

        //ICommand _NewFileCommand;
        //public ICommand NewFileCommand
        //{
        //    get { return _NewFileCommand ?? (_NewFileCommand = new RelayCommand(NewFileCommand_Execute)); }
        //}

        //private void NewFileCommand_Execute()
        //{
        //    if (dirty)
        //    {
        //        MessageBoxResult res = MessageBox.Show("Du har data der ikke er gemt! Er du sikker på at du vil lukke uden at gemme?",
        //            "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        //        if (res == MessageBoxResult.No)
        //        {
        //            return;
        //        }
        //    }

        //    Clear();
        //    filename = "";
        //    Title = "Untitled - " + AppTitle;
        //    dirty = false;
        //}


        //ICommand _OpenFileCommand;
        //public ICommand OpenFileCommand
        //{
        //    get { return _OpenFileCommand ?? (_OpenFileCommand = new RelayCommand<string>(OpenFileCommand_Execute)); }
        //}

        //private void OpenFileCommand_Execute(string argFilename)
        //{
        //    List<Bistad> tmpBistader;
        //    var dialog = new OpenFileDialog();

        //    if (dirty)
        //    {
        //        MessageBoxResult res = MessageBox.Show("Du har data der ikke er gemt! Er du sikker på at du vil lukke uden at gemme?",
        //            "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        //        if (res == MessageBoxResult.No)
        //        {
        //            return;
        //        }
        //    }

        //    dialog.Filter = "Bistadsdokument|*.bi|All Files|*.*";
        //    dialog.DefaultExt = "bi";
        //    if (filePath == "")
        //        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    else
        //        dialog.InitialDirectory = Path.GetDirectoryName(filePath);

        //    if (dialog.ShowDialog(App.Current.MainWindow) == true)
        //    {
        //        filePath = dialog.FileName;
        //        filename = Path.GetFileName(filePath);
        //        try
        //        {
        //            Repository.ReadFile(filePath, out tmpBistader);

        //            // We have to insert the agents in the existing collection. 
        //            Clear();
        //            foreach (var bistad in tmpBistader)
        //                Add(bistad);
        //            Title = filename + " - " + AppTitle;
        //            dirty = false;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Kan ikke åbne filen!", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //}

        //ICommand _CloseAppCommand;
        //public ICommand CloseAppCommand
        //{
        //    get { return _CloseAppCommand ?? (_CloseAppCommand = new RelayCommand(CloseCommand_Execute)); }
        //}

        //private void CloseCommand_Execute()
        //{
        //    bool regret = false;

        //    if (dirty)
        //    {
        //        MessageBoxResult res = MessageBox.Show("Du har data der ikke er gemt! Er du sikker på at du vil lukke uden at gemme?",
        //            "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        //        if (res == MessageBoxResult.No)
        //        {
        //            regret = true;
        //        }
        //    }
        //    if (!regret)
        //        Application.Current.MainWindow.Close();
        //}

        //ICommand _ColorCommand;
        //public ICommand ColorCommand
        //{
        //    get { return _ColorCommand ?? (_ColorCommand = new RelayCommand<String>(ColorCommand_Execute)); }
        //}

        //private void ColorCommand_Execute(String colorStr)
        //{
        //    SolidColorBrush newBrush = SystemColors.WindowBrush; // Default color

        //    try
        //    {
        //        if (colorStr != null)
        //        {
        //            if (colorStr != "Default")
        //                newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorStr));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Unknown color name, default color is used", "Program error!");
        //    }

        //    Application.Current.MainWindow.Resources["BackgroundBrush"] = newBrush;
        //}
        //#endregion // Commands

        #region Mide Commands

        ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddMide)); }
        }

        private void AddMide()
        {
            // Show Modal Dialog
            var dlg = new AddMide();
            dlg.Title = "Opret Nyt Midetal";
            MideTal nyMide = new MideTal();
            nyMide.Tilhorer = CurrentBistad;
            dlg.DataContext = nyMide;
            if (dlg.ShowDialog() == true)
            {
                Add(nyMide);
                CurrentMide = nyMide;
                dirty = true;
            }
        }

        ICommand _editCommand;
        public ICommand EditCommand
        {
            get { return _editCommand ?? (_editCommand = new RelayCommand(EditMide, DeleteMide_CanExecute)); }
        }

        private void EditMide()
        {
            // Show Modal Dialog
            var dlg = new AddMide();
            dlg.Title = "Redigér Miderapport";
            // Need a temp agent in case of cancel
            MideTal tmpMide = new MideTal();
            tmpMide.Tilhorer = CurrentBistad;
            tmpMide.Antal = CurrentMide.Antal;
            tmpMide.Dato = CurrentMide.Dato;
            tmpMide.Kommentar = CurrentMide.Kommentar;
            dlg.DataContext = tmpMide;
            if (dlg.ShowDialog() == true)
            {
                CurrentMide.Kommentar = tmpMide.Kommentar;
                dirty = true;
            }
        }

        ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteMide, DeleteMide_CanExecute)); }
        }

        private void DeleteMide()
        {
            MessageBoxResult res = MessageBox.Show("Er du sikker på at du vil slette miderapporten?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                Remove(CurrentMide);
                NotifyPropertyChanged("Count");
                dirty = true;
            }
        }

        private bool DeleteMide_CanExecute()
        {
            if (Count > 0 && CurrentIndex >= 0)
                return true;
            else
                return false;
        }
        #endregion
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

        MideTal currentMide = null;

        public MideTal CurrentMide
        {
            get { return currentMide; }
            set
            {
                if (currentMide != value)
                {
                    currentMide = value;
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
