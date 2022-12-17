using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static WindowsFormsApp1.Form1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        BindingList<User> users;
        bool newRowNeeded =  false;
        int numberOfRows = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            users = new BindingList<User> { new User() { UserName = "Fred", userid = 1 }, new User() { UserName = "Tom", userid = 2 } };

            IList<MyValue> values = new List<MyValue> { new MyValue { id = 1, name = "Fred" }, new MyValue { id = 2, name = "Tom" }, new MyValue { id = 3, name = "Jan" } };

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = users;
            DataGridViewComboBoxColumn col3 = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn col2 = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col2.DataSource = values;
            col2.DisplayMember = "name";
            col2.DataPropertyName = "userid";
            col2.ValueMember = "id";
            col1.Name = "id";
            col1.DataPropertyName = "userid";
            col3.Name = "id2";
            col3.DataPropertyName = "userid";
            dataGridView1.VirtualMode = true;


            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
           // dataGridView1.Columns.Add(col3);

        }
        public class MyValue
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class User
        {
            public string UserName { get; set; }
            public int userid { get; set; }
        }

        private void dataGridView1_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = 3;
            newRowNeeded = true;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= users.Count())
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = 1;

            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (newRowNeeded)
            {
                MessageBox.Show("Zapisuji");
                newRowNeeded = false;
                numberOfRows++;
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }
    }
}
