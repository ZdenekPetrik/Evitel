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

        List<string> ErrorList = new List<string>();
        List<string> WarningList = new List<string>();
        bool isNewForm = true;
        CRepositoryDB DB;

        private System.Windows.Forms.ErrorProvider placeErrorProvider;
        private System.Windows.Forms.ErrorProvider placeWarningProvider;
        private System.Windows.Forms.ErrorProvider cmbInterventErrorProvider;
        private System.Windows.Forms.ErrorProvider cmbRegionErrorProvider;
        private System.Windows.Forms.ErrorProvider cmbSubTypeIntervenceErrorProvider;


        public ucCallLIKO()
        {
            InitializeComponent();
        }

        private void ucCallLIKO_Load(object sender, EventArgs e)
        {
            txtLoginUser.Text = Program.myLoggedUser.FirstName + " " + Program.myLoggedUser.LastName;

            DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);


            var intervents = DB.GetWIntervents(null, "", "");
            cmbIntervent.Items.Add(new ComboItem("<Nevybráno>", ""));
            foreach (var intervent in intervents)
            {
                if (intervent.IsDeleted != true)
                    cmbIntervent.Items.Add(new ComboItem(intervent.CmbName, intervent.InterventId.ToString()));
            }
            cmbIntervent.SelectedIndex = 0;

            List<EvitelLib2.Model.Region> regions = DB.GetRegions();
            cmbRegion.Items.Add(new ComboItem("<Nevybráno>", ""));
            foreach (EvitelLib2.Model.Region region in regions)
            {
                cmbRegion.Items.Add(new ComboItem(region.ShortName + " - " + region.Name, region.RegionId.ToString()));
            }
            cmbRegion.SelectedIndex = 0;

            List<EvitelLib2.Model.ESubTypeIntervence> subTypeIntervervences = DB.GetSubTypeIntervence();
            cmbSubTypeIntervence.Items.Add(new ComboItem("<Nevybráno>", ""));
            foreach (EvitelLib2.Model.ESubTypeIntervence subTypeIntervence in subTypeIntervervences)
            {
                if (subTypeIntervence.DtDeleted == null)
                    cmbSubTypeIntervence.Items.Add(new ComboItem(subTypeIntervence.Text, subTypeIntervence.SubTypeIntervenceId.ToString()));
            }
            cmbSubTypeIntervence.SelectedIndex = 0;

            placeErrorProvider = InitializeErrorProvider(1, txtPlace);
            placeWarningProvider = InitializeErrorProvider(2, txtPlace);
            cmbInterventErrorProvider = InitializeErrorProvider(1, cmbIntervent);
            cmbRegionErrorProvider = InitializeErrorProvider(1, cmbRegion);
            cmbSubTypeIntervenceErrorProvider = InitializeErrorProvider(1, cmbSubTypeIntervence);
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {

            if (ValidateChildren())
            {
                MessageBox.Show("Validation succeeded!");
            }
            else
            {
                MessageBox.Show("Validation failed.");
            }
            return;
        }


        private void WriteThisNewCall()
        {
            DateTime datetimeStartCall = dtCall.Value.Date.Add(TimeSpan.Parse(tmCall.Value.ToShortTimeString()));
            int CallId = DB.WriteCall(datetimeStartCall);
        }

        #region Validation


        private ErrorProvider InitializeErrorProvider(int type, Control myControl)
        {
            var x = new System.Windows.Forms.ErrorProvider();
            x.SetIconAlignment(myControl, ErrorIconAlignment.MiddleRight);
            x.SetIconPadding(myControl, 2);
            x.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            x.Icon = (type == 1 ? Resource.error_Icon : Resource.warning_Icon);
            return x;
        }


        private void txtPlace_Validating(object sender, CancelEventArgs e)
        {
            if (txtPlace.Text.Length == 0)
            {
                placeErrorProvider.SetError(this.txtPlace, "Místo/Obec není vyplněno");
                placeWarningProvider.SetError(this.txtPlace, String.Empty);
                e.Cancel = true;
            }
            else if (txtPlace.Text.Length > 50)
            {
                placeErrorProvider.SetError(this.txtPlace, "Místo/Obec je příliš dlouhé");
                placeWarningProvider.SetError(this.txtPlace, String.Empty);
                e.Cancel = true;
            }
            else
            {
                placeErrorProvider.SetError(this.txtPlace, String.Empty);
                e.Cancel = false;
                if (txtPlace.Text.Length < 4)
                    placeWarningProvider.SetError(this.txtPlace, "Místo/Obec je příliš krátké");
                else
                    placeWarningProvider.SetError(this.txtPlace, String.Empty);
            }
        }

        private void cmbIntervent_Validating(object sender, CancelEventArgs e)
        {
            if (cmbIntervent.SelectedIndex == 0)
            {
                cmbInterventErrorProvider.SetError(this.cmbIntervent, "Volající musí být vyplněn");
                e.Cancel = true;
            }
            else
            {
                cmbInterventErrorProvider.SetError(this.cmbIntervent, "");
                e.Cancel = false;
            }
        }

        private void cmbRegion_Validating(object sender, CancelEventArgs e)
        {
            if (cmbRegion.SelectedIndex == 0)
            {
                cmbRegionErrorProvider.SetError(this.cmbRegion, "Volající musí být vyplněn");
                e.Cancel = true;
            }
            else
            {
                cmbRegionErrorProvider.SetError(this.cmbRegion, "");
                e.Cancel = false;
            }

        }
        #endregion

        private void cmbSubTypeIntervence_Validating(object sender, CancelEventArgs e)
        {
            if (cmbSubTypeIntervence.SelectedIndex == 0)
            {
                cmbSubTypeIntervenceErrorProvider.SetError(this.cmbSubTypeIntervence, "Volající musí být vyplněn");
                e.Cancel = true;
            }
            else
            {
                cmbSubTypeIntervenceErrorProvider.SetError(this.cmbSubTypeIntervence, "");
                e.Cancel = false;
            }

        }
    }
}
