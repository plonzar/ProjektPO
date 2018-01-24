using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public CategoryItem OperationCategory { get; set; }
        public OperationType Type { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }
    }

    public enum OperationType { Income, Outcome }
}
