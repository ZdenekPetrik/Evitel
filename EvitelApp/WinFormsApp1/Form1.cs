using EvitelLib2.Model;
using EvitelLib2.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<WIntervent>? interventi = null;
        private CRepositoryDB DB;
        private int Rows { get { return interventi!.Count(); } }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             *  DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("column1"));
                dt.Columns.Add(new DataColumn("column2"));

                DataRow dr = dt.NewRow();
                dr[0] = "column1 Value";
                dr[1] = "column2 Value";

                dt.Rows.Add(dr);
                */
            
            DB = new CRepositoryDB(-1);
            interventi = DB.GetWIntervents();
            dgw.DataSource = interventi;


 

 
            DataTable dt = ToDataTable(interventi);
            dgw.DataSource = dt;
        }


        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        DataGridViewCellEventArgs? lastAktCell;
        DataGridViewCellEventArgs? lastEditCell;
        private void dgw_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (lastAktCell != null && lastAktCell.RowIndex != e.RowIndex)
                lblPocet.Text = string.Format("{0}/{1}", e.RowIndex, Rows);
            else
                lblPocet.Text = "0 / 0";
            if (lastEditCell != null && lastEditCell.RowIndex != e.RowIndex) {
                if (lastEditCell.RowIndex < Rows)
                    MessageBox.Show("Edit ROW " + lastEditCell.RowIndex.ToString());
                else
                    MessageBox.Show("NEW ROW " + lastEditCell.RowIndex.ToString());
                lastEditCell = null;
            }

            lastAktCell = e;
        }

        private void dgw_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            lastEditCell = e;
        }

        private void dgw_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dgw_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

