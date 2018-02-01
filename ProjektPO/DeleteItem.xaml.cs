using ProjektPO.Entity;
using ProjektPO.Models;
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
            var _context = new ApplicationDB();
            List<string> CategoryNames = new List<string>();
            var categories_ = _context.Categories.ToList();
            foreach (var category in categories_)
            {
                CategoryNames.Add(category.Name);
            }
            categories.ItemsSource = CategoryNames;
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            string category = categories.SelectedValue.ToString();
            string item = itemToDelete.SelectedValue.ToString();
            var categoryModel = new CategoryModel();
            if (categoryModel.DeleteCategoryItem(item, (int)App.Current.Properties["loggedUserID"]))
            {
                MessageBox.Show("Selected item has been removed.", "Confirmation", MessageBoxButton.OK);
                var _context = new ApplicationDB();
                var category_ = categoryModel.ReadCategory(categories.SelectedValue.ToString(), (int)App.Current.Properties["loggedUserID"]);
                var items = _context.CategoryItems;
                List<String> itemNames = new List<string>();
                foreach (var item_ in items)
                {
                    if (item_.CategoryEntityId == category_.Id && item_.UserEntityId == (int)App.Current.Properties["loggedUserID"])
                    {
                        itemNames.Add(item_.Name);
                    }
                }
                itemToDelete.ItemsSource = itemNames;
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
            var _context = new ApplicationDB();
            var categoryModel = new CategoryModel();
            var category = categoryModel.ReadCategory(categories.SelectedValue.ToString(), (int)App.Current.Properties["loggedUserID"]);
            var items = _context.CategoryItems;
            List<String> itemNames = new List<string>();
            foreach (var item in items)
            {
                if (item.CategoryEntityId == category.Id && item.UserEntityId == (int)App.Current.Properties["loggedUserID"])
                {
                    itemNames.Add(item.Name);
                }
            }
            itemToDelete.ItemsSource = itemNames;
        }
    }


}
