using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            List<string> a = new List<string> { "aaaaa", "bbbbbbbb", "CCCCCCCCCC" };
            dgw.DataSource = a;
        }
    }
}
