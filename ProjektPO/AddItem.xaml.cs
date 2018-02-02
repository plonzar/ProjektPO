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
    /// Logika interakcji dla klasy AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        public AddItem()
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
            string item = itemToAdd.Text;
            if (String.IsNullOrEmpty(item))
            {
                MessageBox.Show("No item name given.", "Error", MessageBoxButton.OK);
            }
            else
            {
                if (categories.SelectedValue != null)
                {
                    var categoryModel = new CategoryModel();
                    var category = categoryModel.ReadCategory(categories.SelectedValue.ToString(), (int)App.Current.Properties["loggedUserID"]);
                    var categoryItemViewModel = new CategoryItemViewModel()
                    {
                        Name = item,
                        CategoryId = category.Id,
                    };
                    if (categoryModel.AddCategoryItem(categoryItemViewModel, category.Id, (int)App.Current.Properties["loggedUserID"]))
                    {
                        MessageBox.Show("A new item has been added", "Confirmation", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("This item already exists in that category.", "Error", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("No category has been selected.", "Error", MessageBoxButton.OK);
                }
            }
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
            this.Close();
        }

        private void AddItem_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
        }

    }


}
