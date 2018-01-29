using ProjektPO.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Abstract
{
    public interface IEstimatesModel
    {

        EstimatedOutcomeIncome GetEstimatesForNextMonth(int userId);

    }
}
