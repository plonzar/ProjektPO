using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Entity
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public int UserEntityId { get; set; }
        public UserEntity UserEntity { get; set; }
    }
}
