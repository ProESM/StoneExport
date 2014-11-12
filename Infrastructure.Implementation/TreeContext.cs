using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class TreeContext : DbContext
    {
        public TreeContext()
            : base("DB_MAIN")
        {
            Database.SetInitializer(new StoneExportDbInitializer());
        }

        public DbSet<TreeDao> TreeDaos { get; set; }        
    }
}
