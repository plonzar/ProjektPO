using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model
{
    public class OperationEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public CategoryItemEntity OperationCategory { get; set; }
        public OperationType Type { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }
    }

    public enum OperationType { Income, Outcome }
}
