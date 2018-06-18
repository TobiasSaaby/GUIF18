using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Threading;
using System.ComponentModel;

namespace GUI_eksamen___Opgave_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Clock clock = new Clock();

        public MainWindow()
        {
            InitializeComponent();

            spClock.DataContext = clock;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            clock.Update();
        }

        private void sortOrderCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = e.AddedItems[0] as ComboBoxItem;
            string newSortOrder;
            if (cbi != null)
            {
                if (cbi.Tag == null)
                    newSortOrder = "None";
                else
                    newSortOrder = cbi.Tag.ToString();

                SortDescription sortDesc = new SortDescription(newSortOrder, ListSortDirection.Ascending);
                ICollectionView cv = CollectionViewSource.GetDefaultView(DataContext);
                if (cv != null)
                {
                    cv.SortDescriptions.Clear();
                    if (newSortOrder != "None")
                        cv.SortDescriptions.Add(sortDesc);
                }
            }
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Bistad bi = (Bistad)dgridBistad.SelectedItem;
            string filter = bi.Name;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dgridBistader.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    MideTal p = o as MideTal;
                    //if (t.Name == "txtId")
                    //    return (p.Id == Convert.ToInt32(filter));
                    return (p.Tilhorer.Name.StartsWith(filter));
                };

            }
        }

        private void dgridBistader_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) { }
                //Bistader.EditCommand.Execute(new Object());
        }

        private void dgridBistad_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {

            }
            //Bistader.EditCommand.Execute(new Object());
        }
    }
}
