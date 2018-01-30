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
    /// Logika interakcji dla klasy EditUsername.xaml
    /// </summary>
    public partial class EditUsername : Window
    {
        public EditUsername()
        {
            InitializeComponent();
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            string newUsername_ = newUsername.Text;

            if (!String.IsNullOrEmpty(newUsername_))
            {
                var user = new UserViewModel();
                if (user.EditUsername(newUsername_))
                {
                    MessageBox.Show("Your username has been changed.", "Confirmation", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("This username is already taken.", "Error", MessageBoxButton.OK);
                }
            }

            else
            {
                MessageBox.Show("No username given.", "Error", MessageBoxButton.OK);
            }
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
            this.Close();
        }

        private void EditUsername_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
        }

    }


}
