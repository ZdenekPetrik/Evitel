using EvitelApp2.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvitelApp2.Helper;
using NPOI.SS.Formula.Functions;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using Microsoft.VisualBasic;
using Microsoft.Data.SqlClient;
using NPOI.OpenXmlFormats.Spreadsheet;

namespace EvitelApp2.Forms
{
  public partial class frmStatisticsCall : Form
  {
    List<EGrouping> grouping;
    CRepositoryDB DB;
    public DataTable aktStatistikaTable;

    public frmStatisticsCall()
    {
      InitializeComponent();
    }

    private void frmStatisticsCall_Load(object sender, EventArgs e)
    {
      DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
      cmbInterval.Items.Add(new ComboItem("Včera", "1"));
      cmbInterval.Items.Add(new ComboItem("Předevčířem", "2"));
      cmbInterval.Items.Add(new ComboItem("Tento týden", "3"));
      cmbInterval.Items.Add(new ComboItem("Minulý týden", "4"));
      cmbInterval.Items.Add(new ComboItem("Tento a minulý týden", "5"));
      cmbInterval.Items.Add(new ComboItem("Tento měsíc", "6"));
      cmbInterval.Items.Add(new ComboItem("Minulý měsíc", "7"));
      cmbInterval.Items.Add(new ComboItem("Tento a minulý měsíc", "8"));
      cmbInterval.Items.Add(new ComboItem("Toto čtvrtletí", "9"));
      cmbInterval.Items.Add(new ComboItem("Minulé čtvrtletí", "10"));
      cmbInterval.Items.Add(new ComboItem("Toto a minulé čtvrtletí", "11"));
      cmbInterval.Items.Add(new ComboItem("Toto pololetí", "12"));
      cmbInterval.Items.Add(new ComboItem("Minulé pololetí", "13"));
      cmbInterval.Items.Add(new ComboItem("Toto a minulé pololetí", "14"));
      cmbInterval.Items.Add(new ComboItem("Tento rok", "15"));
      cmbInterval.Items.Add(new ComboItem("Minulý rok", "16"));
      cmbInterval.Items.Add(new ComboItem("Tento a minulý rok", "17"));
      cmbInterval.SelectedIndex = 0;
      cmbInterval.DropDownWidth = 300;
      grouping = DB.GetGrouping().OrderBy(x => x.GroupingId).ToList();
      foreach (var g1 in grouping)
        cmbGrouping.Items.Add(new ComboItem(g1.Text, g1.GroupingId.ToString()));
      cmbInterval.SelectedIndex = (int)Properties.CallSettings.Default.Interval;
      cmbGrouping.SelectedIndex = (int)Properties.CallSettings.Default.Grouping;
      // s datumem je problém. Při prvním čtení neexistuje a i kdybych ho tam dal jako implicitní, tak může být jiný formát (US, CZ). Takže radši s kontrolou.
      dtFrom.Value = (Properties.CallSettings.Default.DateFrom < dtFrom.MinDate) ? DateTime.Now : Properties.CallSettings.Default.DateFrom;
      dtTo.Value = (Properties.CallSettings.Default.DateTo < dtTo.MinDate) ? DateTime.Now : Properties.CallSettings.Default.DateTo;
    }


    private void cmbInterval_SelectedIndexChanged(object sender, EventArgs e)
    {
      var today = DateTime.Now.Date;
      switch (((ComboItem)cmbInterval.SelectedItem).iValue)
      {
        case 1: dtFrom.Value = today.AddDays(-1); dtTo.Value = today.AddDays(-1); return;
        case 2: dtFrom.Value = today.AddDays(-2); dtTo.Value = today.AddDays(-2); return;
        case 3: dtFrom.Value = today.FirstDayOfWeek(); dtTo.Value = dtFrom.Value.AddDays(6); return;
        case 4: dtFrom.Value = today.AddDays(-7).FirstDayOfWeek(); dtTo.Value = dtFrom.Value.AddDays(6); return;
        case 5: dtFrom.Value = today.AddDays(-7).FirstDayOfWeek(); dtTo.Value = dtFrom.Value.AddDays(13); return;
        case 6: dtFrom.Value = new DateTime(today.Year, today.Month, 1); dtTo.Value = dtFrom.Value.AddMonths(1).AddSeconds(-1); return;
        case 7: dtFrom.Value = new DateTime(today.Year, today.Month, 1).AddMonths(-1); dtTo.Value = dtFrom.Value.AddMonths(1).AddSeconds(-1); return;
        case 8: dtFrom.Value = new DateTime(today.Year, today.Month, 1).AddMonths(-1); dtTo.Value = dtFrom.Value.AddMonths(2).AddSeconds(-1); return;
        case 9: dtFrom.Value = today.FirstDayQuarter(); dtTo.Value = dtFrom.Value.AddMonths(3).AddSeconds(-1); return;
        case 10: dtFrom.Value = today.AddMonths(-3).FirstDayQuarter(); dtTo.Value = dtFrom.Value.AddMonths(3).AddSeconds(-1); return;
        case 11: dtFrom.Value = today.AddMonths(-3).FirstDayQuarter(); dtTo.Value = dtFrom.Value.AddMonths(6).AddSeconds(-1); return;
        case 12: dtFrom.Value = today.FirstDayHalfYear(); dtTo.Value = dtFrom.Value.AddMonths(3).AddSeconds(-1); return;
        case 13: dtFrom.Value = today.AddMonths(-3).FirstDayHalfYear(); dtTo.Value = dtFrom.Value.AddMonths(3).AddSeconds(-1); return;
        case 14: dtFrom.Value = today.AddMonths(-3).FirstDayHalfYear(); dtTo.Value = dtFrom.Value.AddMonths(6).AddSeconds(-1); return;
        case 15: dtFrom.Value = new DateTime(today.Year, 1, 1); dtTo.Value = dtFrom.Value.AddYears(1).AddSeconds(-1); return;
        case 16: dtFrom.Value = new DateTime(today.Year, 1, 1).AddYears(-1); dtTo.Value = dtFrom.Value.AddYears(1).AddSeconds(-1); return;
        case 17: dtFrom.Value = new DateTime(today.Year, 1, 1).AddYears(-1); dtTo.Value = dtFrom.Value.AddYears(2).AddSeconds(-1); return;
      }

    }


    private void btnWrite_Click(object sender, EventArgs e)
    {
      string Select1 = " SELECT <interval>, ";
      string SelectTypHovoru = " Count(CASE WHEN CallType = 1 THEN 1 ELSE NULL END) AS 'LPvK', Count(CASE WHEN CallType = 2 THEN 1 ELSE NULL END) AS 'SKI', ";
      string SelectUsers = " LU.LastName as Uživatel,  ";
      string SelectCelkem = " COUNT(C.CallId) AS 'Celkem' ";
      string From = " FROM [dbo].[Calls] C " + (chkVcetneDniBezHovoru.Checked ? "RIGHT" : "LEFT") + " JOIN dimDateTime D ON CAST(C.dtStartCall AS DATE) = D.Date ";
      string UsersJoin = "LEFT JOIN LoginUsers LU on C.LoginUserId =  LU.LoginUserId ";
      string Where = " WHERE D.Date >= @dtFrom  AND D.Date <= @dtTo ";
      string GroupBy = " Group By <interval> ";
      string UsersGroupBy = ", LU.LastName";
      string OrderBy = " Order By <interval> ";
      string UsersOrderBy = " , LU.LastName ";

      string Select = Select1 + (chkPodleTypuHovoru.Checked ? SelectTypHovoru : "") + (chkUsers.Checked ? SelectUsers : "") + SelectCelkem + From + (chkUsers.Checked ? UsersJoin : "") + Where + GroupBy + (chkUsers.Checked ? UsersGroupBy : "") + OrderBy + (chkUsers.Checked ? UsersOrderBy : "");
      int groupingId = ((ComboItem)cmbGrouping.SelectedItem).iValue;
      var groupRow = grouping.Find(x => x.GroupingId == groupingId);
      Select = Select.Replace("<interval>", groupRow.Value);

      aktStatistikaTable = new DataTable();
      using (var da = new SqlDataAdapter(Select, DB.ConnectionString))
      {
        da.SelectCommand.Parameters.AddWithValue("@dtFrom", dtFrom.Value.Date);
        da.SelectCommand.Parameters.AddWithValue("@dtTo", dtTo.Value.AddDays(1).Date);
        da.Fill(aktStatistikaTable);
        aktStatistikaTable.TableName = "StatistikaX";
        Properties.CallSettings.Default.DateFrom = dtFrom.Value.Date;
        Properties.CallSettings.Default.DateTo = dtTo.Value.Date;
        Properties.CallSettings.Default.Interval = cmbInterval.SelectedIndex;
        Properties.CallSettings.Default.Grouping = cmbGrouping.SelectedIndex;
        Properties.CallSettings.Default.Save();
        this.DialogResult = DialogResult.OK;
      }
    }

  }
}