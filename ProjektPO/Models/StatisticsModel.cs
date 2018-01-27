using ProjektPO.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektPO.Model.Abstract;

namespace ProjektPO.Model
{
    public class StatisticsModel: IStatisticsModel
    {
        public Dictionary<DateTime, decimal> GetLinearIncome()
        {
            Dictionary<DateTime, decimal> temp = new Dictionary<DateTime, decimal>();

            return temp;
        }

        public Dictionary<DateTime, decimal> GetLinearOutcome()
        {
            Dictionary<DateTime, decimal> temp = new Dictionary<DateTime, decimal>();

            return temp;
        }

        public Dictionary<DateTime, decimal> GetLinearProfit()
        {
            Dictionary<DateTime, decimal> temp = new Dictionary<DateTime, decimal>();

            return temp;
        }

        public Dictionary<CategoryEntity, float> GetPercentageIncome()
        {
            Dictionary<CategoryEntity, float> temp = new Dictionary<CategoryEntity, float>();

            return temp;
        }

        public Dictionary<CategoryEntity, float> GetPercentageOutcome()
        {
            Dictionary<CategoryEntity, float> temp = new Dictionary<CategoryEntity, float>();

            return temp;
        }

        public Dictionary<CategoryEntity, float> GetPercentageProfit()
        {
            Dictionary<CategoryEntity, float> temp = new Dictionary<CategoryEntity, float>();

            return temp;
        }


    }
}
