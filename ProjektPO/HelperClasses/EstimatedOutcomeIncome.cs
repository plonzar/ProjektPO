using ProjektPO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.HelperClasses
{
    public class EstimatedOutcomeIncome
    {
        //Szacunki na przyszły miesiąc względem obecnego

        public decimal EstimatedIncome { get; set; }
        public decimal EstimatedOutcome { get; set; }

        public decimal Balance { get
            {
                return EstimatedIncome - EstimatedOutcome;
            } }

        public DateTime EstimateForDate { get; set; }

        public string EstimateForMonth { get
            {
                return ((Months)Enum.ToObject(typeof(Months), EstimateForDate.Month)).ToString(); 
            } }

    }

   


}
