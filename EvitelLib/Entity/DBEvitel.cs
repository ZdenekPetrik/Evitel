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
    public class DBEvitel : DbContext
    {
        public DBEvitel()
            : base("name=DBEvitel")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LoginUser> LoginUsers { get; set; }
        public DbSet<LoginAccess> LoginAccesses { get; set; }
        public DbSet<LoginAccessUser> LoginAccessUsers { get; set; }
        public DbSet<MainSetting> MainSettings { get; set; }
        public DbSet<MainEventLog> MainEventLogs { get; set; }
        public DbSet<State> States { get; set; }
    }
 }


