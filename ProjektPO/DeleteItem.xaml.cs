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
    /// Logika interakcji dla klasy DeleteItem.xaml
    /// </summary>
    public partial class DeleteItem : Window
    {
        public DeleteItem()
        {
            InitializeComponent();
            List<string> CategoryNames = new List<string>();
            var userModel = new UserModel();
            var categories_ = userModel.UserCategories((int)App.Current.Properties["loggedUserID"]);
            foreach (var category in categories_)
            {
                CategoryNames.Add(category.Name);
            }
            categories.ItemsSource = CategoryNames;
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            var category = categories.SelectedValue;
            var item = itemToDelete.SelectedValue;
            if (category != null && item != null)
            {
                var categoryString = category.ToString();
                var itemString = item.ToString();
                var categoryModel = new CategoryModel();
                if (categoryModel.DeleteCategoryItem(itemString, categoryModel.ReadCategory(categoryString, (int)App.Current.Properties["loggedUserID"]).Id, (int)App.Current.Properties["loggedUserID"]))
                {
                    MessageBox.Show("Selected item has been removed.", "Confirmation", MessageBoxButton.OK);
                    var itemViewModels = categoryModel.ReadCategoryItems(categoryModel.ReadCategory(categoryString, (int)App.Current.Properties["loggedUserID"]).Id);
                    List<String> itemNames = new List<string>();
                    foreach (var itemViewModel in itemViewModels)
                    {
                        itemNames.Add(itemViewModel.Name);
                    }
                    itemToDelete.ItemsSource = itemNames;
                }
            }
            else
            {
                MessageBox.Show("No required values have been chosen.", "Error", MessageBoxButton.OK);
            }
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
            this.Close();
        }

        private void DeleteItem_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
        }

        private void CategoriesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var categoryModel = new CategoryModel();
            var category = categories.SelectedValue;
            if (category != null)
            {
                string categoryString = categories.SelectedValue.ToString();
                var itemViewModels = categoryModel.ReadCategoryItems(categoryModel.ReadCategory(categoryString, (int)App.Current.Properties["loggedUserID"]).Id);
                List<String> itemNames = new List<string>();
                foreach (var itemViewModel in itemViewModels)
                {
                    itemNames.Add(itemViewModel.Name);
                }
                itemToDelete.ItemsSource = itemNames;
            }
        }
    }
}
