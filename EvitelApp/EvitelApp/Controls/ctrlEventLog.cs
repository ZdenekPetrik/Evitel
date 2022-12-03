using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvitelLib.Repository;
using EvitelLib.Entity;
using EvitelLib.Common;

namespace EvitelApp.Controls
{
    public partial class ctrlEventLog : UserControl
    {

        public ctrlEventLogFilter eventLogFilter1;
        private List<MainEventLog> EventLog = null;
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
            eEventCode? e1 = (eventLogFilter1.filterEventGroup == -1 ? null : (eEventCode?)eventLogFilter1.filterEventGroup);
            eEventSubCode? e2 = (eventLogFilter1.filterEventType == -1 ? null : (eEventSubCode?)eventLogFilter1.filterEventType);
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
            for (int i = 0; i < Cl.Count(); i++)
                Cl[i] = new DataGridViewTextBoxColumn();
            Cl[0].Name = "Datum";
            Cl[0].DataPropertyName = "dtCreate";
            Cl[1].Name = "Event";
            Cl[1].DataPropertyName = "EventType";
            Cl[2].Name = "Sub event";
            Cl[2].DataPropertyName = "EventSubType";
            Cl[3].Name = "Program";
            Cl[3].DataPropertyName = "Program";
            Cl[4].Name = "User";
            Cl[4].DataPropertyName = "LoginUserId";
            Cl[5].Name = "Text";
            Cl[5].DataPropertyName = "Text";
            Cl[6].Name = "Value";
            Cl[6].DataPropertyName = "Value";
            foreach (DataGridViewTextBoxColumn dgvColumn in Cl)
                dgw.Columns.Add(dgvColumn);

          
            dgw.DataSource = EventLog;
//            dgw.SetColumnOrderExt(this.Parent.Name);
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
            ReReadData();
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

        
        private void dgw_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1) // column of the enum
                {
                    e.Value = CStateHelper.GetEventDescriptionValue ((eEventCode)e.Value);
                }
                if (e.ColumnIndex == 2) // column of the enum
                {
                    e.Value = CStateHelper.GetEventSubDescriptionValue((eEventSubCode)e.Value);
                }
                if (e.ColumnIndex == 4) 
                {
                    
                    e.Value = e.Value != null ? CUserHelper.GetUserFullName((int)e.Value) : "";
                }
            }
            catch (Exception ex)
            {
                e.Value = ex.Message;
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
