using ProjektPO.HelperClasses;
using ProjektPO.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model
{
    public class StatisticsModel: IStatisticsModel
    {
        private ApplicationDB _context;

        public StatisticsModel()
        {
            _context = new ApplicationDB();
        }

        public List<Point> GetLinearIncome(DateTime dateFrom, DateTime dateTo, int categoryId)
        {
            List<OperationEntity> op = _context.Operations
                                               .AsNoTracking()
                                               .Where(x => x.Date > dateFrom.Date
                                               && x.Date < dateTo.Date
                                               && x.Category.CategoryId == categoryId
                                               && x.Type == OperationType.Income)
                                               .ToList();

            var grouped = op.GroupBy(x => x.Date);
            List<Point> result = new List<Point>();
            foreach (var item in grouped)
            {
                result.Add(new Point { X = item.Key, Y = item.Sum(x => x.Amount) });
            }

            return result;
        }
        public List<Point> GetLinearOutcome(DateTime dateFrom, DateTime dateTo, int categoryId)
        {
            List<OperationEntity> op = _context.Operations
                                               .AsNoTracking()
                                               .Where(x => x.Date >= dateFrom
                                               && x.Date <= dateTo
                                               && x.Category.CategoryId == categoryId 
                                               && x.Type == OperationType.Outcome)
                                               .ToList();

            var grouped = op.GroupBy(x => x.Date);
            List<Point> result = new List<Point>();
            foreach (var item in grouped)
            {
                result.Add(new Point { X = item.Key, Y = item.Sum(x => x.Amount) });
            }

            return result;
        }
        public List<Point> GetLinearProfit(DateTime dateFrom, DateTime dateTo, int categoryId)
        {
            List<OperationEntity> income = _context.Operations
                                   .AsNoTracking()
                                   .Where(x => x.Date >= dateFrom.Date
                                   && x.Date <= dateTo.Date
                                   && x.Category.CategoryId == categoryId
                                   && x.Type == OperationType.Income)
                                   .ToList();

            List<OperationEntity> outcome = _context.Operations
                                   .AsNoTracking()
                                   .Where(x => x.Date >= dateFrom.Date
                                   && x.Date <= dateTo.Date
                                   && x.Category.CategoryId == categoryId
                                   && x.Type == OperationType.Outcome)
                                   .ToList();



            var grouped = income.GroupBy(x => x.Date);
            List<Point> result = new List<Point>();
            foreach (var item in grouped)
            {
                result.Add(new Point {
                    X = item.Key,
                    Y = (item.Sum(x => x.Amount) - outcome.Where(x => x.Date == item.Key).Sum(x => x.Amount))
                });
            }

            return result;
        }
        public List<DiagramItem> GetIncomeForDiagram(DateTime dateFrom, DateTime dateTo, int categoryId)
        {
            List<OperationEntity> op = _context.Operations
                                            .AsNoTracking()
                                            .Where(x => x.Date > dateFrom.Date
                                            && x.Date < dateTo.Date
                                            && x.Category.CategoryId == categoryId
                                            && x.Type == OperationType.Income)
                                            .ToList();

            var grouped = op.GroupBy(x => x.Date);
            //var grouped = op.GroupBy(x => x.CategoryItemEntityId);
            List<DiagramItem> result = new List<DiagramItem>();
            foreach (var item in grouped)
            {
                result.Add(new DiagramItem{
                  Label = item.FirstOrDefault().Category.Name,
                  Value = item.Sum(x => x.Amount)
                });
            }

            return result;
        }
        public List<DiagramItem> GetOutcomeForDiagram(DateTime dateFrom, DateTime dateTo, int categoryId)
        {
            List<OperationEntity> op = _context.Operations
                                          .AsNoTracking()
                                          .Where(x => x.Date > dateFrom.Date
                                          && x.Date < dateTo.Date
                                          && x.Category.CategoryId == categoryId
                                          && x.Type == OperationType.Outcome)
                                          .ToList();

            var grouped = op.GroupBy(x => x.Date);
            //var grouped = op.GroupBy(x => x.CategoryItemEntityId);
            List<DiagramItem> result = new List<DiagramItem>();
            foreach (var item in grouped)
            {
                result.Add(new DiagramItem
                {
                    Label = item.FirstOrDefault().Category.Name,
                    Value = item.Sum(x => x.Amount)
                });
            }

            return result;

        }

        //public List<DiagramItem> GetPercentageProfit(DateTime dateFrom, DateTime dateTo, int categoryId)
        //{
        //    List<OperationEntity> income = _context.Operations
        //                                  .AsNoTracking()
        //                                  .Where(x => x.Date > dateFrom.Date
        //                                  && x.Date < dateTo.Date
        //                                  && x.Category.CategoryId == categoryId
        //                                  && x.Type == OperationType.Income)
        //                                  .ToList();

        //    List<OperationEntity> income = _context.Operations
        //                                  .AsNoTracking()
        //                                  .Where(x => x.Date > dateFrom.Date
        //                                  && x.Date < dateTo.Date
        //                                  && x.Category.CategoryId == categoryId
        //                                  && x.Type == OperationType.Income)
        //                                  .ToList();

        //    var grouped = op.GroupBy(x => x.Date);
        //    //var grouped = op.GroupBy(x => x.CategoryItemEntityId);
        //    List<DiagramItem> result = new List<DiagramItem>();
        //    foreach (var item in grouped)
        //    {
        //        result.Add(new DiagramItem
        //        {
        //            Label = item.FirstOrDefault().Category.Name,
        //            Value = item.Sum(x => x.Amount)
        //        });
        //    }

        //    return result;
        //}


    }
}
