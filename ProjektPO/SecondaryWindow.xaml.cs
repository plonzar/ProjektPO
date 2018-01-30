using ProjektPO.ViewModels;
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
        public SecondaryWindow()
        {
            InitializeComponent();
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            ((MainWindow)App.Current.Properties["MainWindow"]).Show();
        }

        private void EditUsernameClick(object sender, RoutedEventArgs e)
        {
            EditUsername edit_username = new EditUsername();
            this.IsEnabled = false;
            edit_username.Owner = this;
            edit_username.Show();
        }

        private void EditPasswordClick(object sender, RoutedEventArgs e)
        {
            EditPassword edit_password = new EditPassword();
            this.IsEnabled = false;
            edit_password.Owner = this;
            edit_password.Show();
        }   

        private void DeleteAccountClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo);
            if (answer == MessageBoxResult.Yes)
            {
                var user = new UserViewModel();
                user.DeleteAccount();
                this.Close();
                ((MainWindow)App.Current.Properties["MainWindow"]).Show();
            }
        }

        private void SecondaryWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((MainWindow)App.Current.Properties["MainWindow"]).Show();
        }
    }
}
