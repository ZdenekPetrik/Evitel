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

namespace EvitelApp2.Forms
{
  public partial class frmStatisticsLPvK : Form
  {
    List<EGrouping> grouping;
    CRepositoryDB DB;
    public DataTable aktStatistikaTable;

    private bool isVisible = false;
    public frmStatisticsLPvK()
    {
      InitializeComponent();
    }

    private void frm_Load(object sender, EventArgs e)
    {
      DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
      cmbInterval.Items.Add(new ComboItem("", "0"));
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
      cmbInterval.DropDownWidth = 300;
      grouping = DB.GetGrouping().OrderBy(x => x.GroupingId).ToList();
      foreach (var g1 in grouping)
        cmbGrouping.Items.Add(new ComboItem(g1.Text, g1.GroupingId.ToString()));
      cmbInterval.SelectedIndex = (int)Properties.LPvkSettings.Default.Interval;
      cmbGrouping.SelectedIndex = (int)Properties.LPvkSettings.Default.Grouping;
      // s datumem je problém. Při prvním čtení neexistuje a i kdybych ho tam dal jako implicitní, tak může být jiný formát (US, CZ). Takže radši s kontrolou.
      dtFrom.Value = (Properties.LPvkSettings.Default.DateFrom < dtFrom.MinDate) ? DateTime.Now : Properties.LPvkSettings.Default.DateFrom;
      dtTo.Value = (Properties.LPvkSettings.Default.DateTo < dtTo.MinDate) ? DateTime.Now : Properties.LPvkSettings.Default.DateTo;
      radioButton1.Checked = true;
    }


    private void cmbInterval_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!isVisible)
        return;
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
      try
      {
        string SelectZapsal = "";
        string SelectNick = "";
        string SelectTypKontaktu = "";
        string SelectTypSluzby = "";
        string SelectTypZdroje = "";
        string SelectSex = "";
        string SelectAge = "";
        string SelectEndOfSpeech = "";
        string SelectCelkem = " COUNT(I.LPKId) AS 'Celkem' ";
        string GroupByAdd = "";
        string from = "";

        if (radioButton1.Checked)
        {
          from = " [dbo].[wLPK] ";
          if (chkZapsal.Checked == true)
          {
            var users = DB.GetUsers().Where(x => x.LoginUserId > 0).OrderBy(x => x.LastName);
            foreach (var user in users)
            {
              SelectZapsal += "Count(CASE WHEN LoginUserId = " + user.LoginUserId + " THEN 1 ELSE NULL END) AS '" + user.LastName + "',";
            }
          }
          if (chkVolajici.Checked == true)
          {
            var aktNicks = DB.GetWLPK().Where(x => !string.IsNullOrEmpty(x.Nick) && x.DtCall > dtFrom.Value && x.DtCall < dtTo.Value.AddDays(1)).Select(x => x.Nick).Distinct();
            foreach (var aktNick in aktNicks)
            {
              SelectNick += "Count(CASE WHEN Nick = '" + aktNick + "' THEN 1 ELSE NULL END) AS '" + aktNick + "',";
            }
          }
          if (chkTypKontaktu.Checked == true)
          {
            var ctList = DB.GetContactType().OrderBy(x => x.Text);
            foreach (var tc1 in ctList)
            {
              SelectTypKontaktu += "Count(CASE WHEN ContactTypeEID = " + tc1.ContactTypeId + " THEN 1 ELSE NULL END) AS '" + tc1.Text + "',";
            }
          }
          if (chkTypSluzby.Checked == true)
          {
            var tsList = DB.GetTypeService().OrderBy(x => x.Text);
            foreach (var ts1 in tsList)
            {
              SelectTypSluzby += "Count(CASE WHEN TypeServiceEID = " + ts1.TypeServiceId + " THEN 1 ELSE NULL END) AS '" + ts1.Text + "',";
            }
          }
          if (chkTypZdroje.Checked == true)
          {
            var cfList = DB.GetClientFrom().OrderBy(x => x.Text);
            foreach (var cf1 in cfList)
            {
              SelectTypZdroje += "Count(CASE WHEN ClientFromEID = " + cf1.ClientFromId + " THEN 1 ELSE NULL END) AS '" + cf1.Text + "',";
            }
          }
          if (chkSex.Checked == true)
          {
            var sexList = DB.GetSex().OrderBy(x => x.Text);
            foreach (var sex1 in sexList)
            {
              SelectSex += "Count(CASE WHEN SexEID = " + sex1.SexId + " THEN 1 ELSE NULL END) AS '" + sex1.Text + "',";
            }
          }

          if (chkAge.Checked == true)
          {
            var ageList = DB.GetContactAge().OrderBy(x => x.AgeId);
            foreach (var age1 in ageList)
            {
              SelectTypZdroje += "Count(CASE WHEN AgeEID = " + age1.AgeId + " THEN 1 ELSE NULL END) AS '" + age1.Text + "',";
            }
          }
        }
        else if (radioButton4.Checked)
        {
          SelectEndOfSpeech = " Text AS 'Ukončení hovoru', subtext AS 'Detail', ";
          from = " (SELECT LPK.LPKId,Calls.dtStartCall As dtCall, EOS.LPKSubEndOfSpeechEID,EOS2.Text ,EOS1.Text  AS 'Subtext' " +
            " FROM LPK LEFT JOIN [dbo].[Calls] ON LPK.CallId = Calls.CallId" +
            " LEFT JOIN [dbo].[LPKSubEndOfSpeech] EOS ON EOS.LPKId = LPK.LPKId" +
            " LEFT JOIN [dbo].[eSubEndOfSpeech] EOS1 ON EOS.LPKSubEndOfSpeechEID = EOS1.SubEndOfSpeechId" +
            " LEFT JOIN [dbo].[eEndOfSpeech] EOS2 ON EOS1.EndOfSpeechId = EOS2.EndOfSpeechId) ";
          GroupByAdd = "  ,[Text],subText ";
        }
        else if (radioButton3.Checked)
        {
          SelectEndOfSpeech = " Text AS 'Aktuální stav', subtext AS 'Detail', ";
          from = " (SELECT LPK.LPKId,Calls.dtStartCall As dtCall, CCS.LPKSubClientCurrentStatusEID, CCS2.Text ,CCS1.Text  AS 'Subtext' " +
            " FROM LPK LEFT JOIN [dbo].[Calls] ON LPK.CallId = Calls.CallId" +
            " LEFT JOIN [dbo].[LPKClientCurrentStatus] CCS ON CCS.LPKId = LPK.LPKId" +
            " LEFT JOIN [dbo].[eSubClientCurrentStatus] CCS1 ON CCS.LPKSubClientCurrentStatusEID = CCS1.SubClientCurrentStatusId" +
            " LEFT JOIN [dbo].[eClientCurrentStatus] CCS2 ON CCS1.ClientCurrentStatusId = CCS2.ClientCurrentStatusId) ";
          GroupByAdd = "  ,[Text],subText ";
        }
        else if (radioButton2.Checked)
        {
          SelectEndOfSpeech = " Text AS 'Typ incidentu', subtext AS 'Detail', ";
          from = " (SELECT LPK.LPKId,Calls.dtStartCall As dtCall, CT.LPKSubContactTopicEID,CT2.Text ,CT1.Text  AS 'Subtext' " +
            " FROM LPK LEFT JOIN [dbo].[Calls] ON LPK.CallId = Calls.CallId" +
            " LEFT JOIN [dbo].[LPKSubContactTopic] CT ON CT.LPKId = LPK.LPKId " +
            " LEFT JOIN [dbo].[eSubContactTopic] CT1 ON CT.LPKSubContactTopicEID = CT1.SubContactTopicId " +
            " LEFT JOIN [dbo].[eContactTopic] CT2 ON CT1.ContactTopicId = CT2.ContactTopicId) ";
          GroupByAdd = "  ,[Text],subText ";
        }

        string Select1 = " SELECT <interval>, ";
        string From = " FROM " + from + " AS I ";
        string Join = (chkVcetneDniBezHovoru.Checked ? "RIGHT" : "LEFT") + " JOIN dimDateTime D ON CAST(I.dtCall AS DATE) = D.Date ";

        string Where = " WHERE D.Date >= @dtFrom  AND D.Date <= @dtTo ";
        string GroupBy = " Group By <interval> " + GroupByAdd;
        string OrderBy = " Order By <interval> ";

        string Select = Select1 + SelectZapsal + SelectNick + SelectTypKontaktu + SelectTypSluzby + SelectTypZdroje + SelectSex + SelectAge + SelectEndOfSpeech + SelectCelkem + From + Join + Where + GroupBy + OrderBy;
        int groupingId = ((ComboItem)cmbGrouping.SelectedItem).iValue;
        var groupRow = grouping.Find(x => x.GroupingId == groupingId);
        Select = Select.Replace("<interval>", groupRow.Value);

        aktStatistikaTable = new DataTable();
        using (var da = new SqlDataAdapter(Select, DB.ConnectionString))
        {
          da.SelectCommand.Parameters.AddWithValue("@dtFrom", dtFrom.Value.Date);
          da.SelectCommand.Parameters.AddWithValue("@dtTo", dtTo.Value.Date);
          da.Fill(aktStatistikaTable);
          aktStatistikaTable.TableName = "StatistikaLPvK";
          this.DialogResult = DialogResult.OK;
          Properties.LPvkSettings.Default.DateFrom = dtFrom.Value.Date;
          Properties.LPvkSettings.Default.DateTo = dtTo.Value.Date;
          Properties.LPvkSettings.Default.Interval = cmbInterval.SelectedIndex;
          Properties.LPvkSettings.Default.Grouping = cmbGrouping.SelectedIndex;
          Properties.LPvkSettings.Default.Save();
          this.DialogResult = DialogResult.OK;

        }
      }
      catch (Exception Ex)
      {
        MessageBox.Show(Ex.Message);
      }
    }

    private void frmStatisticsLPvK_VisibleChanged(object sender, EventArgs e)
    {
      isVisible = this.Visible;
    }

  }
}