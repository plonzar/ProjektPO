using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Entity
{
    public class CategoryEntity : Entity
    {
        public string Name { get; set; }
        public List<CategoryItemEntity> Categories { get; set; }
    }
}
