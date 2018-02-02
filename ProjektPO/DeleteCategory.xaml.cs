using ProjektPO.Entity;
using ProjektPO.Models;
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
    /// Logika interakcji dla klasy DeleteCategory.xaml
    /// </summary>
    public partial class DeleteCategory : Window
    {
        public DeleteCategory()
        {
            InitializeComponent();
            UserModel userModel = new UserModel();
            List<string> categoryNames = new List<string>();
            List<CategoryViewModel> categoryViewModels = userModel.UserCategories((int)App.Current.Properties["loggedUserID"]);
            foreach (var categoryViewModel in categoryViewModels)
            {
                categoryNames.Add(categoryViewModel.Name);
            }
            categories.ItemsSource = categoryNames;
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {          
            if (categories.SelectedValue != null)
            {
                var category = categories.SelectedValue.ToString();
                var categoryModel = new CategoryModel();
                var category_ = categoryModel.ReadCategory(category, (int)App.Current.Properties["loggedUserID"]);
                categoryModel.DeleteCategory(category_.Id, (int)App.Current.Properties["loggedUserID"]);
                MessageBox.Show("Selected category was removed.", "Confirmation", MessageBoxButton.OK);
                List<string> categoryNames = new List<string>();
                UserModel userModel = new UserModel();
                List<CategoryViewModel> categoryViewModels = userModel.UserCategories((int)App.Current.Properties["loggedUserID"]);
                foreach (var categoryViewModel in categoryViewModels)
                {
                    categoryNames.Add(categoryViewModel.Name);
                }
                categories.ItemsSource = categoryNames;
            }
            else
            {
                MessageBox.Show("No category has been selected.", "Error", MessageBoxButton.OK);
            }
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
            this.Close();
        }

        private void DeleteCategory_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
        }
    }
}
