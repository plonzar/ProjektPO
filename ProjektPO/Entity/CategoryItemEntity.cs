using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Entity
{
    public class CategoryItemEntity: Entity
    {
        public string Name { get; set; }
        public int CategoryEntityId { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
        public bool IncludeInEstimates { get; set; }
    }
}
