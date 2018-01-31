using ProjektPO.Entity;
using ProjektPO.Enums;
using ProjektPO.HelperClasses;
using ProjektPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Models
{
    public class EstimatesModel
    {

        private ApplicationDB _context;

        public EstimatesModel()
        {
            _context = new ApplicationDB();
        }

        public EstimatedOutcomeIncome GetEstimatesForNextMonth(int userId)
        {
            EstimatedOutcomeIncome result = new EstimatedOutcomeIncome();

            var incomesToEstimate = _context.Operations.Where(x => x.UserEntityId == userId && x.Type == OperationType.Income && x.CategoryItem.IncludeInEstimates).ToList();
            var outcomesToEstimate = _context.Operations.Where(x => x.UserEntityId == userId && x.Type == OperationType.Outcome && x.CategoryItem.IncludeInEstimates).ToList();

            var orderedIncomes = incomesToEstimate.OrderBy(x => x.Date);
            if(orderedIncomes.Count() == 0)
            {
                result.EstimatedIncome = 0;
            }
            else
            {
                DateTime firstDate = orderedIncomes.First().Date;
                DateTime lastDate = orderedIncomes.FirstOrDefault() != null ? orderedIncomes.FirstOrDefault().Date : DateTime.Today;

                TimeSpan difference = lastDate - firstDate;

                decimal incomePerDay = orderedIncomes.Sum(x => x.Amount);

                int nextMonthDays = (new DateTime(1, DateTime.Today.Month, DateTime.Today.Year).AddMonths(1).Day) - (new DateTime(1, DateTime.Today.Month, DateTime.Today.Year).Day)  ;

                result.EstimatedIncome = incomePerDay * (decimal)nextMonthDays;
            }

            var orderedOutcomes = outcomesToEstimate.OrderBy(x => x.Date);
            if (orderedOutcomes.Count() == 0)
            {
                result.EstimatedOutcome = 0;
            }
            else
            {
                DateTime firstDate = orderedOutcomes.First().Date;
                DateTime lastDate = orderedOutcomes.FirstOrDefault() != null ? orderedOutcomes.FirstOrDefault().Date : DateTime.Today;

                TimeSpan difference = lastDate - firstDate;

                decimal incomePerDay = orderedOutcomes.Sum(x => x.Amount);

                int nextMonthDays = (new DateTime(1, DateTime.Today.Month, DateTime.Today.Year).AddMonths(1).AddDays(-1).Day) - (new DateTime(1, DateTime.Today.Month, DateTime.Today.Year).AddMonths(1).Day);

                result.EstimatedOutcome = incomePerDay * (decimal)nextMonthDays;
            }

            result.EstimateForDate = new DateTime(1, DateTime.Today.Month, DateTime.Today.Year);

            return result;
        }


    }
}
