﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model.Abstract
{
    public interface IStatisticsModel
    {
        Dictionary<DateTime, decimal> GetLinearIncome();
        Dictionary<DateTime, decimal> GetLinearOutcome();
        Dictionary<DateTime, decimal> GetLinearProfit();
        Dictionary<Category, float> GetPercentageIncome();
        Dictionary<Category, float> GetPercentageOutcome();
        Dictionary<Category, float> GetPercentageProfit();
    }
}
