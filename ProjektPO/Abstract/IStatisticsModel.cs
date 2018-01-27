using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektPO.HelperClasses;

namespace ProjektPO.Model.Abstract
{
    public interface IStatisticsModel
    {
        List<Point> GetLinearIncome(DateTime dateFrom, DateTime dateTo, int categoryId);
        List<Point> GetLinearOutcome(DateTime dateFrom, DateTime dateTo, int categoryId);
        List<Point> GetLinearProfit(DateTime dateFrom, DateTime dateTo, int categoryId);
        List<DiagramItem> GetIncomeForDiagram(DateTime dateFrom, DateTime dateTo, int categoryId);
        List<DiagramItem> GetOutcomeForDiagram(DateTime dateFrom, DateTime dateTo, int categoryId);
     //   List<DiagramItem> GetPercentageProfit(DateTime dateFrom, DateTime dateTo, int categoryId);
    }
}
