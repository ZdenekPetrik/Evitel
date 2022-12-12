using EvitelLib2.Model;
using EvitelLib2.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

namespace EvitelApp2.Controls
{
    public partial class ucIntervents : UserControl
    {
        public bool isEditModeAllowed {  set {btnEditMode.Visible = value;} }
        public bool isData { get { return interventi != null; } }       // info zda uz data byla nactena

        private List<WIntervent>? interventi = null;
        private CRepositoryDB DB;
        private int Rows { get { return interventi!.Count(); } }


        private class interventiShow
        {
            public int InterventId { get; set; }
            public string Hodnost { get; set; }
            public string Titul { get; set; }
            public string Jméno { get; set; }
            public string Přijmení { get; set; }
            public int IsDeleted { get; set; }
        };


        public ucIntervents()
        {
            InitializeComponent();
        }

        private void ucIntervents_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
            }
        }

        public void ReadDataFirstTime()
        {
            interventi = DB.GetWIntervents();
            DataTable dt = ToDataTable();
            dgw.DataSource = dt;
            dgw.Columns[0].Visible = false;
            MyResize();
            dgw.SetColumnOrderExt(this.Name, DB);
            dgw.mySort.ColumnName = dgw.Columns[2].Name;
            isEditModeAllowed = false;
            btnEditMode.Visible = false;
            ChangeEditMode(false);

            List<EvitelLib2.Model.Region> regions = DB.GetRegions();
            cmbRegion.Items.Add(new ComboItem("< ALL >", "-1"));
            foreach (var Any in regions)
            {
                cmbRegion.Items.Add(new ComboItem(Any.Name, Any.RegionId.ToString()));
            }
            cmbRegion.SelectedIndex = 0;
        }

        public void RefreshMyData()
        {
            interventi = DB.GetWIntervents();
            dgw.SetColumnOrderExt(this.Name, DB);
            dgw.mySort.ColumnName = dgw.Columns[2].Name;
            DataTable dt = ToDataTable();
            dgw.DataSource = dt;
        }


        public void MyResize()
        {
            dgw.Top = dgw.Left = 0;
            dgw.Width = this.ClientSize.Width - (5) ;
            dgw.Height = this.ClientSize.Height - (groupBoxVyhledavani.Height+5);
            groupBoxVyhledavani.Top = this.ClientSize.Height - (groupBoxVyhledavani.Height + 2);
            groupBoxVyhledavani.Left = 0;
            btnEditMode.Left = groupBoxVyhledavani.Width + 5;
            btnEditMode.Top = this.ClientSize.Height - (btnEditMode.Height + 2);
        }
        public void MyResize(Size ClientSize)
        {
            this.Top = this.Left = 0;
            this.Width = ClientSize.Width;
            this.Height = ClientSize.Height;
            MyResize();
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

        public DataTable ToDataTable()
        {
            DataTable dataTable = new DataTable("InterventiShow");
            dataTable.Columns.Add("InterventId");
            dataTable.Columns.Add("IsDeleted");
            dataTable.Columns.Add("Kraj");
            dataTable.Columns.Add("Hodnost");
            dataTable.Columns.Add("Titul");
            dataTable.Columns.Add("Jméno");
            dataTable.Columns.Add("Přijmení");
            dataTable.Columns.Add("Telefon");
            dataTable.Columns.Add("Mobil");
            dataTable.Columns.Add("Soukromý");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Vytvořeno");
            foreach (var item in interventi)
            {
                dataTable.Rows.Add(new Object[] { (int)item.InterventId, item.IsDeleted, item.RegionName, item.Rank, item.Title, item.Name, item.SurName, item.Phone, item.MobilPhone, item.PrivatePhone, item.Email, item.DtCreate });
            }
            return dataTable;
        }

        private void ucIntervents_Resize(object sender, EventArgs e)
        {
            MyResize();
        }

        private void dgw_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!dgw.Rows[e.RowIndex].IsNewRow && dgw.Rows[e.RowIndex].Cells[1].Value.ToString() == "1")
            {
                dgw.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
            }
        }

        private void btnEditMode_Click(object sender, EventArgs e)
        {
            ChangeEditMode(!dgw.AllowUserToAddRows);

        }
        private void ChangeEditMode(bool isOn)
        {
            dgw.AllowUserToAddRows = isOn;
            dgw.AllowUserToDeleteRows = isOn;
            dgw.EditMode = isOn ? DataGridViewEditMode.EditOnKeystrokeOrF2: DataGridViewEditMode.EditProgrammatically;
            btnEditMode.Text = isOn ? "View Mode" : "Edit Mode";
            if (isOn)
            {
                btnEditMode.Visible = true;
            }
        }
        DataGridViewCellEventArgs? lastAktCell;
        DataGridViewCellEventArgs? lastEditCell;
        private void dgw_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (lastAktCell != null && (lastAktCell.RowIndex != e.RowIndex || e.RowIndex == 0))
                ShowRow(e.RowIndex + 1);
            else
                ShowRow(0);
            if (lastEditCell != null && lastEditCell.RowIndex != e.RowIndex)
            {
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


        private void ShowRow(int index)
        {
            lblPocet.Text = string.Format("{0}/{1}", index, Rows);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {

        }



        private void dgw_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string id  = e.Row.Cells[0].Value.ToString();
            var toDelete = interventi.First(x => x.InterventId.ToString() == id);

            if (DialogResult.Yes == MessageBox.Show("Opravdu " + (toDelete.IsDeleted == 0 ?  "smazat " : "obnovit ") + toDelete.Name + " " + toDelete.SurName + " " + toDelete.RegionName + "?","DeleteRow", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                DB.InterventDeleteUnDelete(toDelete.InterventId,toDelete.IsDeleted == 0);
            RefreshMyData();
          }
    }
}
