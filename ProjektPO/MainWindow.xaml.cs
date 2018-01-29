using ProjektPO.Model;
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
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string username_ = username.Text;
            string password_ = password.Password;
            if (String.IsNullOrEmpty(username_) || String.IsNullOrEmpty(password_))
            {
                MessageBox.Show("No username or password", "Error", MessageBoxButton.OK);
            }
            else
            {
            }
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            string username_ = username.Text;
            string password_ = password.Password;
            if (String.IsNullOrEmpty(username_) || String.IsNullOrEmpty(password_))
            {
                MessageBox.Show("No username or password", "Error", MessageBoxButton.OK);
            }
            else
            {
            }
        }
    }
}
