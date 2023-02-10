using EvitelLib2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EvitelApp2.Helper
{
  public class BackupRestore
  {

    public string databaseName = "Evitel2";

    public void Backup()
    {
      try
      {
        using (SaveFileDialog fd = new SaveFileDialog())
        {
          fd.FileName = databaseName+"Backup_" + DateTime.Now.ToString("yyyMMdd_HHmmss") + ".bak";
          fd.Filter = "Backup files (*.bak)|*.bak";
          fd.Title = "Save database to Backup File";
          fd.OverwritePrompt = true;
          fd.CreatePrompt = true;
          if (fd.ShowDialog() == DialogResult.OK)
          {
            var filename = fd.FileName;
            string command = "BACKUP DATABASE "+databaseName+" TO DISK = '" + fd.FileName + "'";

            using (var ctx = new Evitel2DB())
            {
              //Get student name of string type
              var a = ctx.Database.ExecuteSqlRaw(command);
            }
            MessageBox.Show("Backup databáze "+ databaseName + " do souboru "+fd.FileName+" ukončen úspěšně.", "Save database to Backup File",MessageBoxButtons.OK,MessageBoxIcon.Information);
          }
        }
      }
      catch (Exception Ex)
      {
        MessageBox.Show("Nelze provést zálohování. " + Ex.Message);
      }

    }

    public void Restore()
    {
      try
      {
        var filePath = string.Empty;
        using (OpenFileDialog fd = new OpenFileDialog())
        {
          fd.Filter = "backup files (*.bak)|*.bak|All files (*.*)|*.*";
          fd.Title = "Restore database from Backup File";

          if (fd.ShowDialog() == DialogResult.OK)
          {
            filePath = fd.FileName;
          }
        }
        if (filePath.Length > 0)
        {
          string command = "ALTER DATABASE [" + databaseName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
          using (var ctx = new Evitel2DB())
          {
            //Get student name of string type
            var a = ctx.Database.ExecuteSqlRaw(command);
          }
          command = "USE MASTER; RESTORE DATABASE [" + databaseName + "] FROM DISK = N'" + filePath + "' WITH REPLACE";
          using (var ctx = new Evitel2DB())
          {
            //Get student name of string type
            var a = ctx.Database.ExecuteSqlRaw(command);
          } 
        }
        MessageBox.Show("Obnova databáze " + databaseName + " ze souboru " + filePath + " ukončena úspěšně.", "Restore database from Backup File", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception Ex)
      {
        MessageBox.Show("Nelze provést obnovu databáze. " + Ex.Message);

      }
      finally
      {
        string command = "ALTER DATABASE [" + databaseName + "] SET MULTI_USER";
        using (var ctx = new Evitel2DB())
        {
          //Get student name of string type
          var a = ctx.Database.ExecuteSqlRaw(command);
        }
      }
    }
  }
}

