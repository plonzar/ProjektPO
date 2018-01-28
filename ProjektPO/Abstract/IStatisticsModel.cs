using System;
using System.Collections.Generic;
using ProjektPO.HelperClasses;

namespace ProjektPO.Abstract
{
    public interface IStatisticsModel
    {
        List<Point> GetLinearIncome(DateTime dateFrom, DateTime dateTo, int categoryId);
        List<Point> GetLinearOutcome(DateTime dateFrom, DateTime dateTo, int categoryId);
        List<Point> GetLinearProfit(DateTime dateFrom, DateTime dateTo, int categoryId);
        List<DiagramItem> GetIncomeForDiagram(DateTime dateFrom, DateTime dateTo, int categoryId);
        List<DiagramItem> GetOutcomeForDiagram(DateTime dateFrom, DateTime dateTo, int categoryId);

    }
}
