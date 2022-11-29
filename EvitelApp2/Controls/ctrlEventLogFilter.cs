using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvitelLib2.Repository;
using EvitelLib2.Entity;
using EvitelLib2;

namespace EvitelApp2.Controls
{
    public partial class ctrlEventLogFilter : UserControl
    {
        private CRepositoryDB DB;
        public DateTime filterFrom { get { return dtFrom.Value.Date; } }
        public DateTime filterTo { get { return dtTo.Value.Date.AddDays(1); } }
        public string filterText { get { return txtText.Text; } }
        public string filterValue { get { return txtValue.Text; } }
        public int filterLoginUser { get { return ((ComboItem)cmbUser.SelectedItem).iValue; } }
        public int filterEventCode{ get { return ((ComboItem)cmbEventCode.SelectedItem).iValue; } }
        public int filterEventSubCode { get { return ((ComboItem)cmbEventSubCode.SelectedItem).iValue; } }
        public string filterProgram { get { return ((ComboItem)cmbProgram.SelectedItem).Value; } }

        public delegate void EventHandlerEventLogDetail();
        public event EventHandlerEventLogDetail NewFilter;


        public ctrlEventLogFilter()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (NewFilter != null)
                NewFilter();
        }

        private void ctrlEventLogFilter_Load(object sender, EventArgs e)
        {
            DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
            dtFrom.Value = DateTime.Now.Date.AddDays(-1);
            dtTo.Value = DateTime.Now.Date;
            cmbProgram.Items.Add(new ComboItem("< ALL >", ""));
            cmbProgram.Items.Add(new ComboItem("Evitel", "Evitel"));
            cmbProgram.SelectedIndex = 0;

            List<LoginUser> U = DB.GetUsers();
            U = U.OrderBy(c => c.LoginName).Cast<LoginUser>().ToList();
            cmbUser.Items.Add(new ComboItem("< ALL >", "-1"));
            foreach (var AnyUser in U)
            {
                cmbUser.Items.Add(new ComboItem(AnyUser.LastName, AnyUser.LoginUserId.ToString()));
            }
            cmbUser.SelectedIndex = 0;
            List<State> S = DB.GetAllStates();
            List<State> EventType = S.FindAll(c => c.StateType == 99).OrderBy(c => c.StateValue).Cast<State>().ToList();
            List<State> EventSubType = S.FindAll(c => c.StateType == 98).OrderBy(c => c.StateValue).Cast<State>().ToList();
            cmbEventCode.Items.Add(new ComboItem("< ALL >", "-1"));
            foreach (State Any in EventType)
            {
                cmbEventCode.Items.Add(new ComboItem(Any.DescriptionValue, Any.StateValue.ToString()));
            }
            cmbEventCode.SelectedIndex = 0;

            cmbEventSubCode.Items.Add(new ComboItem("< ALL >", "-1"));
            foreach (State Any in EventSubType)
            {
                cmbEventSubCode.Items.Add(new ComboItem(Any.DescriptionValue, Any.StateValue.ToString()));
            }
            cmbEventSubCode.SelectedIndex = 0;

            cmbInterval.Items.Add(new ComboItem("...", "0"));
            cmbInterval.Items.Add(new ComboItem("Dnes", "1"));
            cmbInterval.Items.Add(new ComboItem("Včera", "2"));
            cmbInterval.Items.Add(new ComboItem("Dnes a včera", "3"));
            cmbInterval.Items.Add(new ComboItem("Tento týden", "4"));
            cmbInterval.Items.Add(new ComboItem("Minulý týden", "5"));
            cmbInterval.Items.Add(new ComboItem("Tento a minulý týden", "6"));
            cmbInterval.Items.Add(new ComboItem("Tento měsíc", "7"));
            cmbInterval.Items.Add(new ComboItem("Minulý měsíc", "8"));
            cmbInterval.Items.Add(new ComboItem("Tento a minulý měsíc", "9"));
            cmbInterval.Items.Add(new ComboItem("Tento rok", "10"));
            cmbInterval.Items.Add(new ComboItem("Minulý rok", "11"));
            cmbInterval.Items.Add(new ComboItem("Tento a minulý rok", "12"));
            cmbInterval.SelectedIndex = 0;

        }

        private void cmbInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            var today = DateTime.Now.Date;
            switch (((ComboItem)cmbInterval.SelectedItem).iValue)
            {
                case 1: dtFrom.Value = today;                dtTo.Value = today; return;
                case 2: dtFrom.Value = today.AddDays(-1);    dtTo.Value = today.AddDays(-1); return;
                case 3: dtFrom.Value = today.AddDays(-1);    dtTo.Value = today; return;
                case 4: dtFrom.Value = today.AddDays(-(int)today.DayOfWeek+1);             dtTo.Value = dtFrom.Value.AddDays(6); return;
                case 5: dtFrom.Value = today.AddDays(-(int)today.DayOfWeek+1).AddDays(-7); dtTo.Value = dtFrom.Value.AddDays(6); return;
                case 6: dtFrom.Value = today.AddDays(-(int)today.DayOfWeek+1).AddDays(-7); dtTo.Value = dtFrom.Value.AddDays(13); return;
                case 7: dtFrom.Value = new DateTime(today.Year, today.Month, 1);                dtTo.Value = dtFrom.Value.AddMonths(1).AddSeconds(-1); return;
                case 8: dtFrom.Value = new DateTime(today.Year, today.Month, 1).AddMonths(-1);  dtTo.Value = dtFrom.Value.AddMonths(1).AddSeconds(-1); return;
                case 9: dtFrom.Value = new DateTime(today.Year, today.Month, 1).AddMonths(-1);  dtTo.Value = dtFrom.Value.AddMonths(2).AddSeconds(-1); return;
                case 10: dtFrom.Value = new DateTime(today.Year, 1, 1);                 dtTo.Value = dtFrom.Value.AddYears(1).AddSeconds(-1); return;
                case 11: dtFrom.Value = new DateTime(today.Year, 1, 1).AddYears(-1);    dtTo.Value = dtFrom.Value.AddYears(1).AddSeconds(-1); return;
                case 12: dtFrom.Value = new DateTime(today.Year, 1, 1).AddYears(-1);    dtTo.Value = dtFrom.Value.AddYears(2).AddSeconds(-1); return;
            }

        }
    }
    public class ComboItem
    {
        public string Text;
        public string Value;
        public int iValue { get { int i = 0; int.TryParse(Value, out i); return i; } }
        public ComboItem() { }
        public ComboItem(string Text, string Value) : this() { this.Text = Text; this.Value = Value; }
        public override string ToString()
        {
            return Text;
        }
    }

}
