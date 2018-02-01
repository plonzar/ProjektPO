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
    /// Logika interakcji dla klasy DeleteCategory.xaml
    /// </summary>
    public partial class DeleteCategory : Window
    {
        public DeleteCategory()
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
            var category = categories.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(category))
            {
                var categoryModel = new CategoryModel();
                var category_ = categoryModel.ReadCategory(category, (int)App.Current.Properties["loggedUserID"]);
                categoryModel.DeleteCategory(category_.Id, (int)App.Current.Properties["loggedUserID"]);
                MessageBox.Show("Selected category was removed.", "Confirmation", MessageBoxButton.OK);
                var _context = new ApplicationDB();
                List<string> CategoryNames = new List<string>();
                var categories_ = _context.Categories.ToList();
                foreach (var cat in categories_)
                {
                    CategoryNames.Add(cat.Name);
                }
                categories.ItemsSource = CategoryNames;
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
