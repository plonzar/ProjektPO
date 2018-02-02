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
    /// Logika interakcji dla klasy EditOperation.xaml
    /// </summary>
    public partial class EditOperation : Window
    {
        List<int> currentOperationsIDs;
        public EditOperation()
        {
            InitializeComponent();
            dayCB.ItemsSource = Enumerable.Range(1, 31);
            monthCB.ItemsSource = Enumerable.Range(1, 12);
            yearCB.ItemsSource = Enumerable.Range(0, 100).Select(x => x + 2000);
            typeCB.ItemsSource = new List<String> { "Income", "Outcome" };
            OperationModel operationModel = new OperationModel();
            var operationList = operationModel.GetList((int)App.Current.Properties["loggedUserID"]);
            List<string> operationStrings = new List<string>();
            List<int> operationIds = new List<int>();
            foreach (var operation in operationList)
            {
                operationStrings.Add(operation.Date.ToString().Substring(0, 10) + " " + operation.OperationCategory.Name + " "
                                     + operation.Amount.ToString() + " " + operation.Type.ToString());
                operationIds.Add(operation.Id);
            }
            currentOperationsIDs = operationIds;
            operationsCB.ItemsSource = operationStrings;
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            
            if (operationsCB.SelectedValue != null && dayCB.SelectedValue != null && monthCB.SelectedValue != null &&
                yearCB.SelectedValue != null && typeCB.SelectedValue != null && amount.Text != "")
            {
                var day = dayCB.SelectedValue.ToString();
                var month = monthCB.SelectedValue.ToString();
                var year = yearCB.SelectedValue.ToString();
                var type = typeCB.SelectedValue.ToString();
                var operationModel = new OperationModel();
                var datetime = Convert.ToDateTime(day + "/" + month + "/" + year);
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
                    Id = currentOperationsIDs[operationsCB.SelectedIndex],
                    Date = datetime,
                    Amount = decimal.Parse(amount.Text),
                    Type = (OperationType)typeInt,
                    UserId = ((int)App.Current.Properties["loggedUserID"]).ToString(),
                    Note = ""
                };
                operationModel.Update(operationViewModel);
                MessageBox.Show("Chosen operation has been edited.", "Confirmation", MessageBoxButton.OK);
                var operationList = operationModel.GetList((int)App.Current.Properties["loggedUserID"]);
                List<string> operationStrings = new List<string>();
                List<int> operationIds = new List<int>();
                foreach (var operation in operationList)
                {
                    operationStrings.Add(operation.Date.ToString().Substring(0, 10) + " " + operation.OperationCategory.Name + " "
                                         + operation.Amount.ToString() + " " + operation.Type.ToString());
                    operationIds.Add(operation.Id);
                }
                currentOperationsIDs = operationIds;
                operationsCB.ItemsSource = operationStrings;
            }
            else
            {
                MessageBox.Show("Not all required values were chosen", "Error", MessageBoxButton.OK);
            }
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            this.Owner = null;
            ((SecondaryWindow)App.Current.Properties["SecondaryWindow"]).IsEnabled = true;
            this.Close();
        }

        private void EditOperation_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
