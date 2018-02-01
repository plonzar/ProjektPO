using ProjektPO.Models;
using ProjektPO.ViewModels;
using ProjektPO.Entity;
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
    /// Logika interakcji dla klasy AddOperation.xaml
    /// </summary>
    public partial class AddOperation : Window
    {
        public AddOperation()
        {
            InitializeComponent();
            day.ItemsSource = Enumerable.Range(1, 31);
            month.ItemsSource = Enumerable.Range(1, 12);
            year.ItemsSource = Enumerable.Range(0, 100).Select(x => x + 2000);
            type.ItemsSource = new List<String>{"Income", "Outcome"};
            var _context = new ApplicationDB();
            List<string> CategoryNames = new List<string>();
            var categories_ = _context.Categories.ToList();
            foreach (var category in categories_)
            {
                CategoryNames.Add(category.Name);
            }
            categoriesCB.ItemsSource = CategoryNames;
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {

        }

        private void CategoriesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var _context = new ApplicationDB();
            var categoryModel = new CategoryModel();
            var category = categoryModel.ReadCategory(categoriesCB.SelectedValue.ToString(), (int)App.Current.Properties["loggedUserID"]);
            var items = _context.CategoryItems;
            List<String> itemNames = new List<string>();
            foreach (var item in items)
            {
                if (item.CategoryEntityId == category.Id && item.UserEntityId == (int)App.Current.Properties["loggedUserID"])
                {
                    itemNames.Add(item.Name);
                }
            }
            itemsCB.ItemsSource = itemNames;
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
            this.Close();
        }

        private void AddOperation_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
        }
    }
}
