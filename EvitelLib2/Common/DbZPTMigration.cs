

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Reflection;

namespace EvitelLib2.Common
{
    public abstract class DbZPTMigration: Migration
    {
        /// <summary>
        /// Adds an operation to execute a SQL file from embeded resources.
        /// </summary>
        /// <param name="resourceName">The name of the resource.</param>
        protected string GetSqlResource(string resourceName)
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
                    sql = sql.Replace("'", "''");
                    sql = "EXECUTE('" + Environment.NewLine + sql + Environment.NewLine + "')";
                    return sql;
                }
            }
        }
    }
}
