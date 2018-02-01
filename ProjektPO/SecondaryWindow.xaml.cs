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
    /// Logika interakcji dla klasy SecondaryWindow.xaml
    /// </summary>
    public partial class SecondaryWindow : Window
    {
        public SecondaryWindow()
        {
            InitializeComponent();
        }

        private void AddCategoryClick(object sender, RoutedEventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            this.IsEnabled = false;
            addCategory.Owner = this;
            addCategory.Show();
        }

        private void AddItemClick(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem();
            this.IsEnabled = false;
            addItem.Owner = this;
            addItem.Show();
        }

        private void DeleteCategoryClick(object sender, RoutedEventArgs e)
        {
            DeleteCategory deleteCategory = new DeleteCategory();
            this.IsEnabled = false;
            deleteCategory.Owner = this;
            deleteCategory.Show();
        }

        private void DeleteItemClick(object sender, RoutedEventArgs e)
        {
            DeleteItem deleteItem = new DeleteItem();
            this.IsEnabled = false;
            deleteItem.Owner = this;
            deleteItem.Show();
        }

        private void EditCategoryClick(object sender, RoutedEventArgs e)
        {

        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            ((MainWindow)App.Current.Properties["MainWindow"]).Show();
        }

        private void EditUsernameClick(object sender, RoutedEventArgs e)
        {
            EditUsername editUsername = new EditUsername();
            this.IsEnabled = false;
            editUsername.Owner = this;
            editUsername.Show();
        }

        private void EditPasswordClick(object sender, RoutedEventArgs e)
        {
            EditPassword editPassword = new EditPassword();
            this.IsEnabled = false;
            editPassword.Owner = this;
            editPassword.Show();
        }   

        private void DeleteAccountClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo);
            if (answer == MessageBoxResult.Yes)
            {
                var user = new UserModel();
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
