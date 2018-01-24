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

        public Dictionary<Category, float> GetPercentageIncome()
        {
            Dictionary<Category, float> temp = new Dictionary<Category, float>();

            return temp;
        }

        public Dictionary<Category, float> GetPercentageOutcome()
        {
            Dictionary<Category, float> temp = new Dictionary<Category, float>();

            return temp;
        }

        public Dictionary<Category, float> GetPercentageProfit()
        {
            Dictionary<Category, float> temp = new Dictionary<Category, float>();

            return temp;
        }


    }
}
