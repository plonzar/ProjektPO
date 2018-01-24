using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model
{
    public class Category
    {   
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public virtual List<CategoryItem> CategoryItems { get; set; }
        
    }
}
