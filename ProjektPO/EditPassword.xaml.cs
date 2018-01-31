using ProjektPO.Model;
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
    /// Logika interakcji dla klasy EditPassword.xaml
    /// </summary>
    public partial class EditPassword : Window
    {
        public EditPassword()
        {
            InitializeComponent();
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            string newPassword_ = newPassword.Password;

            if (!String.IsNullOrEmpty(newPassword_))
            {
                var user = new UserModel();
                user.EditPassword(newPassword_);
                MessageBox.Show("Your password has been changed.", "Confirmation", MessageBoxButton.OK);
            }

            else
            {
                MessageBox.Show("No password given.", "Error", MessageBoxButton.OK);
            }
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
            this.Close();
        }

        private void EditPassword_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
        }
    }


}
