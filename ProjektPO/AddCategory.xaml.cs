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
    /// Logika interakcji dla klasy AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            string category = categoryToAdd.Text;
            if (!String.IsNullOrEmpty(category))
            {
                var categoryViewModel = new CategoryViewModel
                {
                    Name = category,
                    UserId = ((int)App.Current.Properties["loggedUserID"]).ToString(),
                    CategoryItems = null
                };
                var categoryModel = new CategoryModel();
                if (categoryModel.AddCategory(categoryViewModel, (int)App.Current.Properties["loggedUserID"]))
                {
                    MessageBox.Show("A new category has been added.", "Confirmation");
                }
                else
                {
                    MessageBox.Show("This category name is already taken.", "Error", MessageBoxButton.OK); 
                }
            }
            else
            {
                MessageBox.Show("No category name given.", "Error", MessageBoxButton.OK);
            }
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
            this.Close();
        }

        private void AddCategory_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
        }

    }


}
