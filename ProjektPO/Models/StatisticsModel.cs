using ProjektPO.HelperClasses;
using ProjektPO.Entity;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektPO.Abstract;
using ProjektPO.Enums;

namespace ProjektPO.Models
{
    public class StatisticsModel: IStatisticsModel
    {
        private ApplicationDB _context;

        public StatisticsModel()
        {
            _context = new ApplicationDB();
        }

        public List<Point> GetLinearIncome(DateTime dateFrom, DateTime dateTo, int categoryId, int userId)
        {
            List<OperationEntity> op = _context.Operations
                                               .AsNoTracking()
                                               .Where(x => x.UserEntityId == userId 
                                               && x.Date >= dateFrom.Date
                                               && x.Date <= dateTo.Date
                                               && x.CategoryItem.CategoryEntityId == categoryId
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
        public List<Point> GetLinearOutcome(DateTime dateFrom, DateTime dateTo, int categoryId, int userId)
        {
            List<OperationEntity> op = _context.Operations
                                               .AsNoTracking()
                                               .Where(x => x.UserEntityId == userId
                                               && x.Date >= dateFrom
                                               && x.Date <= dateTo
                                               && x.CategoryItem.CategoryEntityId == categoryId 
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
        public List<Point> GetLinearProfit(DateTime dateFrom, DateTime dateTo, int categoryId, int userId)
        {
            List<OperationEntity> income = _context.Operations
                                   .AsNoTracking()
                                   .Where(x => x.UserEntityId == userId
                                   && x.Date >= dateFrom.Date
                                   && x.Date <= dateTo.Date
                                   && x.CategoryItem.CategoryEntityId == categoryId
                                   && x.Type == OperationType.Income)
                                   .ToList();

            List<OperationEntity> outcome = _context.Operations
                                   .AsNoTracking()
                                   .Where(x => x.UserEntityId == userId
                                   && x.Date >= dateFrom.Date
                                   && x.Date <= dateTo.Date
                                   && x.CategoryItem.CategoryEntityId == categoryId
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
        public List<DiagramItem> GetIncomeForDiagram(DateTime dateFrom, DateTime dateTo, int categoryId, int userId)
        {
            List<OperationEntity> op = _context.Operations
                                            .AsNoTracking()
                                            .Include(x => x.CategoryItem)
                                            .Where(x => x.UserEntityId == userId
                                            && x.Date >= dateFrom.Date
                                            && x.Date <= dateTo.Date
                                            && x.CategoryItem.CategoryEntityId == categoryId
                                            && x.Type == OperationType.Income)
                                            .ToList();

            var grouped = op.GroupBy(x => x.Date);
            //var grouped = op.GroupBy(x => x.CategoryItemEntityId);
            List<DiagramItem> result = new List<DiagramItem>();
            foreach (var item in grouped)
            {
                result.Add(new DiagramItem{
                  Label = item.FirstOrDefault().CategoryItem.Name,
                  Value = item.Sum(x => x.Amount)
                });
            }

            return result;
        }
        public List<DiagramItem> GetOutcomeForDiagram(DateTime dateFrom, DateTime dateTo, int categoryId, int userId)
        {
            List<OperationEntity> op = _context.Operations
                                          .AsNoTracking()
                                          .Include(x => x.CategoryItem)
                                          .Where(x => x.UserEntityId == userId
                                          && x.Date >= dateFrom.Date
                                          && x.Date <= dateTo.Date
                                          && x.CategoryItem.CategoryEntityId == categoryId
                                          && x.Type == OperationType.Outcome)
                                          .ToList();

            var grouped = op.GroupBy(x => x.Date);
            //var grouped = op.GroupBy(x => x.CategoryItemEntityId);
            List<DiagramItem> result = new List<DiagramItem>();
            foreach (var item in grouped)
            {
                result.Add(new DiagramItem
                {
                    Label = item.FirstOrDefault().CategoryItem.Name,
                    Value = item.Sum(x => x.Amount)
                });
            }

            return result;

        }

    }
}
