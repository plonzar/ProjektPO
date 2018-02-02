using ProjektPO.Entity;
using ProjektPO.Model;
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
    /// Logika interakcji dla klasy EditCategory.xaml
    /// </summary>
    public partial class EditCategory : Window
    {
        //public List<string> CategoryNames { get; set; }
        public EditCategory()
        {
            InitializeComponent();
            var userModel = new UserModel();
            List<string> CategoryNames = new List<string>();
            var categories_ = userModel.UserCategories((int)App.Current.Properties["loggedUserID"]);
            foreach (var category in categories_)
            {
                CategoryNames.Add(category.Name);
            }
            categories.ItemsSource = CategoryNames;
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            var item = newName.Text;
            if (!String.IsNullOrEmpty(item) && categories.SelectedValue != null)
            {
                CategoryViewModel categoryViewModel = new CategoryViewModel()
                {
                    Name = categories.SelectedValue.ToString()
                };
                CategoryModel categoryModel = new CategoryModel();
                if (categoryModel.EditCategory(categoryViewModel, item, (int)App.Current.Properties["loggedUserID"]))
                {
                    var userModel = new UserModel();
                    List<string> CategoryNames = new List<string>();
                    var categories_ = userModel.UserCategories((int)App.Current.Properties["loggedUserID"]);
                    foreach (var category in categories_)
                    {
                        CategoryNames.Add(category.Name);
                    }
                    categories.ItemsSource = CategoryNames;
                    MessageBox.Show("Category name has been edited.", "Confirmation", MessageBoxButton.OK);
                }
                else
{
                    MessageBox.Show("This name is already taken.", "Error", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Not all required values were chosen.", "Error", MessageBoxButton.OK);
            }
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
            this.Close();
        }

        private void EditCategory_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
        }

    }

}
