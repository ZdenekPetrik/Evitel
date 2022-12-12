using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Windows.Forms;
using EvitelLib2;
using EvitelLib2.Repository;
using EvitelLib2.Common;
using EvitelApp2;
using EvitelApp2.Controls;
using EvitelLib2.Model;
using System.Linq;
using System.Collections;
using System.Diagnostics;

namespace EvitelApp2.Controls
{
    public partial class ctrlEventLog : UserControl
    {

        public ctrlEventLogFilter eventLogFilter1;
        private List<WMainEventLog> EventLog = null;
        private CRepositoryDB DB;

        public ctrlEventLog()
        {
            InitializeComponent();
        }

        private void ReadData()
        {
            EventLog = DB.GetMainEventLog("dtCreate", true, DateTime.Now.Date.AddDays(-1), DateTime.Now.Date.AddDays(1), "", null, null, null, "", "");
            LoadData();
        }
        public void ReReadData()
        {
            eEventCode? e1 = (eventLogFilter1.filterEventCode == -1 ? null : (eEventCode?)eventLogFilter1.filterEventCode);
            eEventSubCode? e2 = (eventLogFilter1.filterEventSubCode == -1 ? null : (eEventSubCode?)eventLogFilter1.filterEventSubCode);
            int? loginUserId = (eventLogFilter1.filterLoginUser == -1 ? null : (int?)eventLogFilter1.filterLoginUser);
            EventLog = DB.GetMainEventLog(dgw.Columns[dgw.mySort.ColumnName].DataPropertyName, (dgw.mySort.Order == ListSortDirection.Ascending), eventLogFilter1.filterFrom, eventLogFilter1.filterTo, eventLogFilter1.filterProgram, loginUserId, e1,e2,  eventLogFilter1.filterText, eventLogFilter1.filterValue);
            dgw.DataSource = EventLog;
        }
        public void MyResize()
        {
            dgw.Top = dgw.Left = 0;
            dgw.Width = this.ClientSize.Width - 5;
            dgw.Height = this.ClientSize.Height;
        }
        public void MyResize(Size ClientSize)
        {
            this.Top = this.Left = 0;
            this.Width = ClientSize.Width;
            this.Height = ClientSize.Height;
            MyResize();
        }

        private void LoadData()
        {
            dgw.AutoGenerateColumns = false;
            dgw.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgw.AllowUserToAddRows = false;
            dgw.AllowUserToDeleteRows = false;
            dgw.AllowUserToOrderColumns = true;
            DataGridViewTextBoxColumn[] Cl = new DataGridViewTextBoxColumn[7];
            for (int i = 0; i < Cl.Length; i++)
                Cl[i] = new DataGridViewTextBoxColumn();
            Cl[0].Name = "Datum";
            Cl[0].DataPropertyName = "dtCreate";
            Cl[1].Name = "Event";
            Cl[1].DataPropertyName = "CodeText";
            Cl[2].Name = "Sub event";
            Cl[2].DataPropertyName = "SubCodeText";
            Cl[3].Name = "Program";
            Cl[3].DataPropertyName = "Program";
            Cl[4].Name = "User";
            Cl[4].DataPropertyName = "UserLastName";
            Cl[5].Name = "Text";
            Cl[5].DataPropertyName = "Text";
            Cl[6].Name = "Value";
            Cl[6].DataPropertyName = "Value";
            foreach (DataGridViewTextBoxColumn dgvColumn in Cl)
                dgw.Columns.Add(dgvColumn);         
            dgw.DataSource = EventLog;
            dgw.SetColumnOrderExt(this.Name,DB);
            dgw.mySort.ColumnName = Cl[0].Name;

        }

        private void dgw_ColumnHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dgw.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dgw.Columns[dgw.mySort.ColumnName];
            if (dgw.mySort.ColumnName == newColumn.Name)
            {
                dgw.mySort.Order = (dgw.mySort.Order == ListSortDirection.Descending) ? ListSortDirection.Ascending : ListSortDirection.Descending;
            }
            else
            {
                dgw.mySort.Order = ListSortDirection.Ascending;
                oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
            if (newColumn.DataPropertyName == "dtCreate")
                EventLog = dgw.mySort.Order == ListSortDirection.Ascending ? EventLog.OrderBy(s => s.DtCreate).ToList(): EventLog.OrderByDescending(s => s.DtCreate).ToList();
            else if (newColumn.DataPropertyName == "CodeText")
                EventLog = dgw.mySort.Order == ListSortDirection.Ascending ? EventLog.OrderBy(s => s.CodeText).ToList() : EventLog.OrderByDescending(s => s.CodeText).ToList();
            else if (newColumn.DataPropertyName == "SubCodeText")
                EventLog = dgw.mySort.Order == ListSortDirection.Ascending ? EventLog.OrderBy(s => s.SubCodeText).ToList() : EventLog.OrderByDescending(s => s.SubCodeText).ToList();
            else if (newColumn.DataPropertyName == "Program")
                EventLog = dgw.mySort.Order == ListSortDirection.Ascending ? EventLog.OrderBy(s => s.Program).ToList() : EventLog.OrderByDescending(s => s.Program).ToList();
            else if (newColumn.DataPropertyName == "UserLastName")
                EventLog = dgw.mySort.Order == ListSortDirection.Ascending ? EventLog.OrderBy(s => s.UserLastName).ToList() : EventLog.OrderByDescending(s => s.UserLastName).ToList();
            else if (newColumn.DataPropertyName == "Text")
                EventLog = dgw.mySort.Order == ListSortDirection.Ascending ? EventLog.OrderBy(s => s.Text).ToList() : EventLog.OrderByDescending(s => s.Text).ToList();
            else if (newColumn.DataPropertyName == "Value")
                EventLog = dgw.mySort.Order == ListSortDirection.Ascending ? EventLog.OrderBy(s => s.Value).ToList() : EventLog.OrderByDescending(s => s.Value).ToList();
            dgw.DataSource = EventLog;

//            ReReadData();
            DataGridViewColumn newColumn1 = dgw.Columns[e.ColumnIndex];
            newColumn1.HeaderCell.SortGlyphDirection =
                dgw.mySort.Order == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;
            dgw.mySort.ColumnName = newColumn.Name;
        }

        private void ctrlEventLog_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
                DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
                ReadData();
                MyResize();
            }
        }
        private void ctrlEventLog_Resize(object sender, EventArgs e)
        {
            MyResize();
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgw_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
