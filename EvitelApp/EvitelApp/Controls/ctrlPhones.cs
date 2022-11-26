using EvitelLib.Entity;
using EvitelLib.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp.Controls
{
    public partial class ctrlPhones : UserControl
    {
        private CRepositoryDB DB;
        private List<MainEventLog> EventLog = null;
        private List<State> AllState = null;


        public ctrlPhones()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ReadData()
        {
 //           EventLog = DB.GetMainEventLog("dtCreate", true, DateTime.Now.Date.AddDays(-1), DateTime.Now.Date.AddDays(1), "", -1, -1, -1, "", "");
 //           AllState = DB.GetAllStates();
            IList<string> a = new List<string> { "aaaaa", "bbbbbbbb", "CCCCCCCCCC" };
            dgw.DataSource = a.Select(x => new { Value = x }).ToList();
            dgw.DefaultCellStyle.ForeColor = Color.Black;

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

        private void ctrlPhones_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
               // DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
                ReadData();
                MyResize();
            }

        }
    }
}
