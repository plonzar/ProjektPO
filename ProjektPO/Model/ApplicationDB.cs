using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model
{
    public class ApplicationDB: DbContext
    {
        public DbSet<CategoryItem> CategoryItems { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
