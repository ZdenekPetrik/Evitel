using EvitelLib2.Model;
using EvitelLib2.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2.Controls
{
    public partial class ucCallLIKO : UserControl
    {
        public ucCallLIKO()
        {
            InitializeComponent();
        }

        private void ucCallLIKO_Load(object sender, EventArgs e)
        {
            txtLoginUser.Text = Program.myLoggedUser.FirstName + " " + Program.myLoggedUser.LastName;

            CRepositoryDB db = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
  

            var intervents = db.GetWIntervents();
            cmbIntervent.Items.Add(new ComboItem("<Nevybráno>", ""));
            foreach (var intervent in intervents)
            {
                cmbIntervent.Items.Add(new ComboItem(intervent.CmbName, intervent.InterventId.ToString()));
            }
            cmbIntervent.SelectedIndex = 0;

            List<EvitelLib2.Model.Region> regions = db.GetRegions();
            cmbRegion.Items.Add(new ComboItem("<Nevybráno>", ""));
            foreach (EvitelLib2.Model.Region region in regions)
            {
                cmbRegion.Items.Add(new ComboItem(region.ShortName + " - " + region.Name, region.RegionId.ToString()));
            }
            cmbRegion.SelectedIndex = 0;

            List<EvitelLib2.Model.ESubTypeIntervence> subTypeIntervervences = db.GetSubTypeIntervence();
            cmbSubTypeIntervence.Items.Add(new ComboItem("<Nevybráno>", ""));
            foreach (EvitelLib2.Model.ESubTypeIntervence subTypeIntervence in subTypeIntervervences)
            {
                cmbSubTypeIntervence.Items.Add(new ComboItem(subTypeIntervence.Text , subTypeIntervence.SubTypeIntervenceId.ToString()));
            }
            cmbSubTypeIntervence.SelectedIndex = 0;

        }

        private void btnWrite_Click(object sender, EventArgs e)
        {

        }
    }
}
