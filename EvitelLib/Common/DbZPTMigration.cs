using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EvitelLib.Common
{
    public abstract class DbZPTMigration: DbMigration
    {
        /// <summary>
        /// Adds an operation to execute a SQL file from embeded resources.
        /// </summary>
        /// <param name="resourceName">The name of the resource.</param>
        protected void SqlResourceExecute(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new Exception(string.Format("Resource {0} not found.", resourceName));
                }

                using (var reader = new StreamReader(stream))
                {
                    var sql = reader.ReadToEnd();

                    SqlExecute(sql);
                }
            }
        }
        /// <summary>
        /// Executes SQL in EXECUTE
        /// </summary>
        /// <param name="sql">SQL to execute</param>
        protected void SqlExecute(string sql)
        {
            sql = sql.Replace("'", "''");
            sql = "EXECUTE('" + Environment.NewLine + sql + Environment.NewLine + "')";
            Sql(sql);
        }

    }
}
