using ProjektPO.Models;
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
using System.Windows.Shapes;

namespace ProjektPO
{
    /// <summary>
    /// Logika interakcji dla klasy ShowChartsDate.xaml
    /// </summary>
    public partial class ShowChartsDate : Window
    {
        public ShowChartsDate()
        {
            InitializeComponent();
            List<string> CategoryNames = new List<string>();
            var userModel = new UserModel();
            var categories_ = userModel.UserCategories((int)App.Current.Properties["loggedUserID"]);
            foreach (var category in categories_)
            {
                CategoryNames.Add(category.Name);
            }
            categoryCB.ItemsSource = CategoryNames;
            day1CB.ItemsSource = Enumerable.Range(1, 31);
            month1CB.ItemsSource = Enumerable.Range(1, 12);
            year1CB.ItemsSource = Enumerable.Range(0, 100).Select(x => x + 2000);
            day2CB.ItemsSource = Enumerable.Range(1, 31);
            month2CB.ItemsSource = Enumerable.Range(1, 12);
            year2CB.ItemsSource = Enumerable.Range(0, 100).Select(x => x + 2000);
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            if (categoryCB.SelectedValue != null)
            {
                var day1 = day1CB.SelectedValue.ToString();
                var month1 = month1CB.SelectedValue.ToString();
                var year1 = year1CB.SelectedValue.ToString();
                var day2 = day2CB.SelectedValue.ToString();
                var month2 = month2CB.SelectedValue.ToString();
                var year2 = year2CB.SelectedValue.ToString();
                var datetime1 = Convert.ToDateTime(day1 + "/" + month1 + "/" + year1);
                var datetime2 = Convert.ToDateTime(day2 + "/" + month2 + "/" + year2);
                var userId = (int)App.Current.Properties["loggedUserID"];
                var categoryModel = new CategoryModel();
                var category = categoryModel.ReadCategory(categoryCB.SelectedValue.ToString(), userId);
                var categoryId = category.Id;
                // kod do wykresow
                this.Close();
                ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
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

        private void ShowChartsDate_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
        }
    }
}
