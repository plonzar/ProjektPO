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
    /// Logika interakcji dla klasy SecondaryWindow.xaml
    /// </summary>
    public partial class SecondaryWindow : Window
    {
        bool logging_out = false;
        public SecondaryWindow()
        {
            InitializeComponent();
        }

        private void edit_username_Click(object sender, RoutedEventArgs e)
        {
            EditUsername edit_username = new EditUsername();
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = false;
            edit_username.Show();
        }

        private void edit_password_Click(object sender, RoutedEventArgs e)
        {
            EditPassword edit_password = new EditPassword();
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = false;
            edit_password.Show();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            logging_out = true;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).Close();
            ((MainWindow)App.Current.Properties["MainWindow"]).Show();
        }    

        private void delete_account_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo);
            if (answer == MessageBoxResult.Yes)
            {
                //Delete_Account();
                logging_out = true;
                ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).Close();
                ((MainWindow)App.Current.Properties["MainWindow"]).Show();
            }
        }

        private void SecondaryWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!logging_out)
            {
                e.Cancel = true;
            }
        }
    }
}
