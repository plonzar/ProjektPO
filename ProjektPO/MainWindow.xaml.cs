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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektPO
{
    /// <summary>fc
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.Current.Properties["MainWindow"] = this;
            DataContext = this;
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            string username_ = username.Text;
            string password_ = password.Password;
            if (String.IsNullOrEmpty(username_) || String.IsNullOrEmpty(password_))
            {
                MessageBox.Show("No username or password", "Error", MessageBoxButton.OK);
            }
            else
            {
                var userViewModel = new UserViewModel
                {
                    Name = username_,
                    Password = password_
                };
                var user = new UserModel();
                if (user.Login(userViewModel))
                {
                    SecondaryWindow window = new SecondaryWindow();
                    App.Current.Properties["SecondaryWindow"] = window;
                    ((MainWindow)App.Current.Properties["MainWindow"]).Hide();
                    window.Show();
                }
                else
                {
                    MessageBox.Show("Wrong username and/or password.", "Login failed", MessageBoxButton.OK);
                }
            }
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            string username_ = username.Text;
            string password_ = password.Password;
            if (String.IsNullOrEmpty(username_) || String.IsNullOrEmpty(password_))
            {
                MessageBox.Show("No username or password", "Error", MessageBoxButton.OK);
            }
            else
            {
                var userViewModel = new UserViewModel
                {
                    Name = username_,
                    Password = password_
                };
                var user = new UserModel();
                if (user.Register(userViewModel))
                {
                    MessageBox.Show("Your account has been successfully registered.", "Registration", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("This username is already taken.", "Registration", MessageBoxButton.OK);
                }
            }
        }
    }
}
