using ProjektPO.Model;
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
    /// Logika interakcji dla klasy DeleteOperation.xaml
    /// </summary>
    public partial class DeleteOperation : Window
    {
        List<int> currentOperationsIDs;
        public DeleteOperation()
        {
            InitializeComponent();
            List<string> CategoryNames = new List<string>();
            var userModel = new UserModel();
            var categories_ = userModel.UserCategories((int)App.Current.Properties["loggedUserID"]);
            foreach (var category in categories_)
            {
                CategoryNames.Add(category.Name);
            }
            categoriesCB.ItemsSource = CategoryNames;     
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            if (categoriesCB.SelectedValue != null && operationToDelete.SelectedValue != null)
            {
                OperationModel operationModel = new OperationModel();
                operationModel.Delete(currentOperationsIDs[operationToDelete.SelectedIndex]);
                string categoryName = categoriesCB.SelectedValue.ToString();
                CategoryModel categoryModel = new CategoryModel();
                var category = categoryModel.ReadCategory(categoryName, (int)App.Current.Properties["loggedUserID"]);
                var operationList = operationModel.GetList((int)App.Current.Properties["loggedUserID"]);
                List<string> operationStrings = new List<string>();
                List<int> operationIds = new List<int>();
                foreach (var operation in operationList)
                {
                    if (category.Id == operation.OperationCategory.CategoryEntityId)
                    {
                        operationStrings.Add(operation.Date.ToString().Substring(0, 10) + " " + operation.OperationCategory.Name + " "
                                             + operation.Amount.ToString() + " " + operation.Type.ToString());
                        operationIds.Add(operation.Id);
                    }
                }
                currentOperationsIDs = operationIds;
                operationToDelete.ItemsSource = operationStrings;
                MessageBox.Show("Chosen operation has been deleted.", "Confirmation", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Not all required values have been chosen.", "Error", MessageBoxButton.OK);
            }
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
            this.Close();
        }

        private void CategoriesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string categoryName = categoriesCB.SelectedValue.ToString();
            OperationModel operationModel = new OperationModel();
            CategoryModel categoryModel = new CategoryModel();
            var category = categoryModel.ReadCategory(categoryName, (int)App.Current.Properties["loggedUserID"]);
            var operationList = operationModel.GetList((int)App.Current.Properties["loggedUserID"]);
            List<string> operationStrings = new List<string>();
            List<int> operationIds = new List<int>();
            foreach (var operation in operationList)
            {
                if (category.Id == operation.OperationCategory.CategoryEntityId)
                {
                    operationStrings.Add(operation.Date.ToString().Substring(0, 7) + " " + operation.OperationCategory.Name + " " 
                                         + operation.Amount.ToString() + " " + operation.Type.ToString());
                    operationIds.Add(operation.Id);
                }
            }
            currentOperationsIDs = operationIds;
            operationToDelete.ItemsSource = operationStrings; 
        }

        private void DeleteOperation_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
        }
    }
}
