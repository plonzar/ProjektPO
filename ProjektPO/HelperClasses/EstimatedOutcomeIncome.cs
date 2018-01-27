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

    public enum Months
    {
        [Display(Name = "Styczeń")]
        January = 1,
        [Display(Name = "Luty")]
        February = 2,
        [Display(Name = "Marzec")]
        March = 3,
        [Display(Name = "Kwiecień")]
        April = 4,
        [Display(Name = "Maj")]
        May = 5,
        [Display(Name = "Czerwiec")]
        June = 6,
        [Display(Name = "Lipiec")]
        July = 7,
        [Display(Name = "Sierpień")]
        August = 8,
        [Display(Name = "Wrzesień")]
        September = 9,
        [Display(Name = "Październik")]
        October = 10,
        [Display(Name = "Listopad")]
        November = 11,
        [Display(Name = "Grudzień")]
        December = 12
    }


}
