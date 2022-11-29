using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// http://www.codedigest.com/quick-start/12/what-is-entity-framework-code-first-migration-a-beginners-guide


// 
namespace EvitelLib.Entity
{
    public class DBTest : DbContext
    {
        public DBTest()
            : base("name=Test")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        
    }
 }


