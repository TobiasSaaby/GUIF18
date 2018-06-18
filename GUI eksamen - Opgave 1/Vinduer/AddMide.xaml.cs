using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI_eksamen___Opgave_1
{
    /// <summary>
    /// Interaction logic for AddMide.xaml
    /// </summary>
    public partial class AddMide : Window
    {
        public AddMide()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
