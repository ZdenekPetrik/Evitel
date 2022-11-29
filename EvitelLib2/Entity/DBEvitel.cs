using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EvitelLib2.Entity
{
    public class DBEvitel : DbContext
    {
        public DBEvitel()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var y = ConfigurationManager.ConnectionStrings["DBEvitel2"].ConnectionString;
            string x = "Data Source=localhost;Initial Catalog=Evitel2;Integrated Security=SSPI;;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(y);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder
                .Entity<wMainEventLog>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("wMainEventLogs");
                    });
            
        }
        public DbSet<State> States { get; set; }
        public DbSet<LoginUser> LoginUsers { get; set; }
        public DbSet<LoginAccess> LoginAccesses { get; set; }
        public DbSet<LoginAccessUser> LoginAccessUsers { get; set; }
        public DbSet<MainSetting> MainSettings { get; set; }
        public DbSet<MainEventLog> MainEventLogs { get; set; }
        public DbSet<wMainEventLog> wMainEventLogs { get; set; }

    }
}
