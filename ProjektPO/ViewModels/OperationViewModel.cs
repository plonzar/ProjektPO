using ProjektPO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.ViewModels
{
    public class OperationViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public CategoryItemEntity OperationCategory { get; set; }
        public OperationType Type { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }
    }
}
