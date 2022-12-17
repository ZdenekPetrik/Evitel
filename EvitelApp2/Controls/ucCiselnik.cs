using EvitelLib2.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2.Controls
{

    public enum eAllEnums { 
        eSex = 1,
        eSubTypeIntervence,
        eTypeIntervence,
        eTypeParty,
        eRegions,
        eIntervents,
    }


    public partial class ucCiselnik : UserControl
    {

        public eAllEnums aktEnum;
        public bool isData { get { return bindingSource1 != null; } }       // info zda uz data byla nactena
        string SQLCommand = "";
        public string Titulek = "";

        BindingSource bindingSource1;


        public ucCiselnik()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private void ucCiselnik_Load(object sender, EventArgs e)
        {
        }

        public void ReadDataFirstTime()
        {
            bindingSource1 = new BindingSource();
            switch (aktEnum)
            {
                case eAllEnums.eSex: SQLCommand = "Select SexId as id, Text,CAST(IIF(dtDeleted IS NULL,0,1) AS BIT) isDeleted From eSex"; Titulek = "Pohlaví"; break;
                case eAllEnums.eSubTypeIntervence: SQLCommand = "Select SubTypeIntervenceId as id, sti.Text , Kategorie, ti2.Text as TypeIntervence, CAST(IIF(sti.dtDeleted IS NULL,0,1) AS BIT) isDeleted From eSubTypeIntervence sti LEFT JOIN eTypeIntervence ti2 on sti.TypeIntervenceId = ti2.typeIntervenceId "; Titulek = "SubTyp Intervence"; break;
                case eAllEnums.eTypeIntervence: SQLCommand = "Select TypeIntervenceId as id, Text, ShortText, CAST(IIF(dtDeleted IS NULL,0,1) AS BIT) isDeleted From eTypeIntervence"; Titulek = "Typ Intervence"; break;
                case eAllEnums.eRegions: SQLCommand = "Select RegionId as id, Name, ShortName, Name2 From Regions ORDER BY RegionId"; Titulek = "Kraje"; break;
                case eAllEnums.eTypeParty: SQLCommand = "Select TypePartyId as id, Text,  CAST(IIF(dtDeleted IS NULL,0,1) AS BIT) isDeleted  From eTypeParty "; Titulek = "Forma účasti"; break;
                default: break;
            }

            try
            {
                // Set up the DataGridView.
                
                dataGridView1.Dock = DockStyle.Fill;

                // Automatically generate the DataGridView columns.
                dataGridView1.AutoGenerateColumns = true;

                // Set up the data source.
                bindingSource1.DataSource = GetData(SQLCommand);
                dataGridView1.DataSource = bindingSource1;

                // Automatically resize the visible rows.
                dataGridView1.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

                // Set the DataGridView control's border.
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;

                // Put the cells in edit mode when user enters them.
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            }
            catch (SqlException )
            {
                MessageBox.Show("To run this sample replace connection.ConnectionString" +
                    " with a valid connection string to a Northwind" +
                    " database accessible to your system.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private static DataTable GetData(string sqlCommand)
        {
            DataTable table = new DataTable();
            try
            {
                string connectionString = "Integrated Security=SSPI;" +
                    "Persist Security Info=False;" +
                    "Initial Catalog=Evitel2;Data Source=localhost";


                connectionString = "Server=.;Database=Evitel2;Trusted_Connection=True;";

                SqlConnection Connection = new SqlConnection(connectionString);

                var x = SelectRows(connectionString, sqlCommand);


                ExecuteDataTableSqlDA(Connection, CommandType.Text, sqlCommand);

                Connection.Open();

                SqlCommand command = new SqlCommand(sqlCommand, Connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                Connection.Close();

                //           table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.Fill(table);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            return table;

        }


        public static DataTable ExecuteDataTableSqlDA(SqlConnection conn, CommandType cmdType, string cmdText)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmdText, conn);
            da.Fill(dt);
            return dt;
        }

        private static DataSet SelectRows(

            string connectionString, string queryString)
        {
            DataSet dts = new DataSet();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    queryString, connection);
                adapter.Fill(dts);
                return dts;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void MyResize()
        {
            dataGridView1.Top = dataGridView1.Left = 0;
            dataGridView1.Width = this.ClientSize.Width - (5);
            dataGridView1.Height = this.ClientSize.Height -  5;
        }

        private void ucCiselnik_Resize(object sender, EventArgs e)
        {
            MyResize();
        }
    }
}



