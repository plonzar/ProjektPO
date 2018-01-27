using ProjektPO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Entity
{
    public class OperationEntity: Entity
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int CategoryItemEntityId { get; set; }
        public CategoryItemEntity Category { get; set; }
        public OperationType Type { get; set; }
        public string Note { get; set; }
    }
}
