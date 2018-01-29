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

namespace ProjektPO
{
    /// <summary>
    /// Logika interakcji dla klasy EditPassword.xaml
    /// </summary>
    public partial class EditPassword : Window
    {
        public EditPassword()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your password has been changed.", "Confirmation", MessageBoxButton.OK);
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
            this.Close();
        }

        private void EditPassword_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
        }
    }


}
