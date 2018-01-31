using ProjektPO.Model;
using ProjektPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektPO.Views
{
    /// <summary>
    /// Interaction logic for Charts.xaml
    /// </summary>
    public partial class Charts : UserControl
    {
        DateTime date1 = new DateTime(2010, 8, 18); //tymczasowe zmienne dopoki sie nie pojawia zmienne przekazywane z bazy  pozniej do usuniecia
        DateTime date2 = new DateTime(2018, 8, 18); //tymczasowe zmienne dopoki sie nie pojawia zmienne przekazywane z bazy  pozniej do usuniecia
        int categoryId, userId;                 //jak wyzej

        public Charts()
        {
            InitializeComponent();

            var sModel = new StatisticsModel();

            //liniowy-dochody
            var lista_dochody = sModel.GetLinearIncome(date1, date2, categoryId, userId);
            foreach (var item in lista_dochody)
            {
                liniowy_przychody.AddPoint(item.X, (double)item.Y);
            }
            //liniowy wydatki
            var lista_wydatki = sModel.GetLinearOutcome(date1, date2, categoryId, userId);
            foreach (var item in lista_wydatki)
            {
                liniowy_przychody.AddPoint(item.X, (double)item.Y);
            }
            //liniowy profit
            var lista_profit = sModel.GetLinearProfit(date1, date2, categoryId, userId);
            foreach (var item in lista_profit)
            {
                liniowy_przychody.AddPoint(item.X, (double)item.Y);
            }

            //kolowy dochody
            var lista_przychody_kolowy = sModel.GetIncomeForDiagram(date1, date2, categoryId, userId);
            foreach (var item in lista_przychody_kolowy)
            {
                diagram_przychody.AddPoint(item.Label, (double)item.Value);
            }
            //kolowy wydatki
            var lista_wydatki_kolowy = sModel.GetOutcomeForDiagram(date1, date2, categoryId, userId);
            foreach (var item in lista_wydatki_kolowy)
            {
                diagram_wydatki.AddPoint(item.Label, (double)item.Value);
            }
        }
    }


}