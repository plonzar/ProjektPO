using ProjektPO.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Entity
{
    public class ApplicationDB : DbContext
    {
        public DbSet<CategoryItemEntity> CategoryItems { get; set; }
        public DbSet<OperationEntity> Operations { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
