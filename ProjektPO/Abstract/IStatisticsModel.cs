using System;
using System.Collections.Generic;
using ProjektPO.HelperClasses;

namespace ProjektPO.Abstract
{
    public interface IStatisticsModel
    {
        List<Point> GetLinearIncome(DateTime dateFrom, DateTime dateTo, int categoryId, int userId);
        List<Point> GetLinearOutcome(DateTime dateFrom, DateTime dateTo, int categoryId, int userId);
        List<Point> GetLinearProfit(DateTime dateFrom, DateTime dateTo, int categoryId, int userId);
        List<DiagramItem> GetIncomeForDiagram(DateTime dateFrom, DateTime dateTo, int categoryId, int userId);
        List<DiagramItem> GetOutcomeForDiagram(DateTime dateFrom, DateTime dateTo, int categoryId, int userId);

    }
}
