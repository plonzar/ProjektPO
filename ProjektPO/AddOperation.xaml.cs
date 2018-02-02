using ProjektPO.Models;
using ProjektPO.Model;
using ProjektPO.ViewModels;
using ProjektPO.Enums;
using System;
using System.Text.RegularExpressions;
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
        private List<CategoryItemViewModel> currentItems;
        public AddOperation()
        {
            InitializeComponent();
            dayCB.ItemsSource = Enumerable.Range(1, 31);
            monthCB.ItemsSource = Enumerable.Range(1, 12);
            yearCB.ItemsSource = Enumerable.Range(0, 100).Select(x => x + 2000);
            typeCB.ItemsSource = new List<String>{"Income", "Outcome"};
            UserModel userModel = new UserModel();
            List<string> CategoryNames = new List<string>();
            var categories_ = userModel.UserCategories((int)App.Current.Properties["loggedUserID"]);
            foreach (var category in categories_)
            {
                CategoryNames.Add(category.Name);
            }
            categoriesCB.ItemsSource = CategoryNames;
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            if (categoriesCB.SelectedValue != null && itemsCB.SelectedValue != null && dayCB.SelectedValue != null &&
                monthCB.SelectedValue != null && yearCB.SelectedValue != null && typeCB.SelectedValue != null && amount.Text != "")
            {
                var category = categoriesCB.SelectedValue.ToString();
                var categoryModel = new CategoryModel();
                var categoryID = categoryModel.ReadCategory(category, (int)App.Current.Properties["loggedUserID"]).Id;
                var item = itemsCB.SelectedValue.ToString();
                var day = dayCB.SelectedValue.ToString();
                var month = monthCB.SelectedValue.ToString();
                var year = yearCB.SelectedValue.ToString();
                var type = typeCB.SelectedValue.ToString();
                var operationModel = new OperationModel();
                var datetime = Convert.ToDateTime(day + "/" + month + "/" + year);
                var operationCategoryItems = categoryModel.ReadCategoryItems(categoryID);
                int typeInt;
                if (type == "Income")
                {
                    typeInt = 0;
                }
                else
                {
                    typeInt = 1;
                }
                var operationViewModel = new OperationViewModel()
                {
                    Date = datetime,
                    Amount = decimal.Parse(amount.Text),
                    Type = (OperationType)typeInt,
                    UserId = ((int)App.Current.Properties["loggedUserID"]).ToString(),
                    Note = ""
                };
                operationModel.AddOperation(operationViewModel, (int)App.Current.Properties["loggedUserID"], currentItems[itemsCB.SelectedIndex].Id);
                MessageBox.Show("A new operation has been added.", "Confirmation", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Not all required values were chosen", "Error", MessageBoxButton.OK);
            }
        }

        private void CategoriesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var categoryModel = new CategoryModel();
            var category = categoryModel.ReadCategory(categoriesCB.SelectedValue.ToString(), (int)App.Current.Properties["loggedUserID"]);
            var items = categoryModel.ReadCategoryItems(category.Id);
            List<String> itemNames = new List<string>();
            foreach (var item in items)
            {
                {
                    itemNames.Add(item.Name);
                }
            }
            currentItems = items;
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

        private void AmountTextChanged(object sender, TextChangedEventArgs e)
        {
            amount.Text = Regex.Replace(amount.Text, "[^0-9]+", "");
        }
    }
}
