using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelLib2.Model
{
  public class Evitel2DB: Evitel2Context
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBEvitel2"].ConnectionString;
        optionsBuilder.UseSqlServer(connectionString);
      }
    }
  }
}
