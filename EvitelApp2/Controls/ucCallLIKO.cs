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

    private ErrorProvider placeErrorProvider;
    private ErrorProvider placeWarningProvider;
    private ErrorProvider cmbInterventErrorProvider;
    private ErrorProvider cmbRegionErrorProvider;
    private ErrorProvider cmbSubTypeIntervenceErrorProvider;
    private ErrorProvider txtNrCelkemErrorProvider;


    public ucCallLIKO()
    {
      InitializeComponent();
    }

    private void ucCallLIKO_Load(object sender, EventArgs e)
    {
      if (DesignMode)
        return;
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
      txtNrCelkemErrorProvider = InitializeErrorProvider(2, txtNrCelkem);
      if (isNewForm) { 
        ucParticipations1.ReadDataFirstTime();
        ucParticipations1.RowChanged_Event += ucParticipations_NewRow;
      }
      
    }

    private void btnWrite_Click(object sender, EventArgs e)
    {

      if (ValidateChildren())
      {
        if (DialogResult.Yes == MessageBox.Show("Opravdu zapsat tento hovor?", "LIKO hovor", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
          WriteThisNewCall();
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
      if (CallId > 0)
      {
        DateTime datetimeIncident = dtIncident.Value.Date.Add(TimeSpan.Parse(tmIncident.Value.ToShortTimeString()));
        int IncidentId = DB.WriteIncident(txtEventNote.Text, ((ComboItem)cmbSubTypeIntervence.SelectedItem).iValue, datetimeIncident, ((ComboItem)cmbRegion.SelectedItem).iValue, txtPlace.Text, chkNasledekSmrti.Checked, chkDokonane.Checked, chkPokusPriprava.Checked, (int)txtPocetObeti.Value);
        if (IncidentId > 0)
        {
          DateTime datetimeStartIntervence = dtIntervence.Value.Date.Add(TimeSpan.Parse(dtIntervence.Value.ToShortTimeString()));
          DateTime datetimeEndIntervence = dtIntervenceEnd.Value.Date.Add(TimeSpan.Parse(dtIntervenceEnd.Value.ToShortTimeString()));
          int IntervenceId = DB.WriteIntervence(datetimeStartIntervence, datetimeEndIntervence, CallId, IncidentId, txtIntervenceNote.Text, (int)txtNrCelkem.Value, (int)txtNrObetemPoskozenym.Value, (int)txtNrPozustalymBlizkym.Value, (int)txtNrOstatnimOsobam.Value, ((ComboItem)cmbIntervent.SelectedItem).iValue);
          if (IntervenceId > 0)
          {
            foreach (var aktPartycipant in ucParticipations1.participantsList) {
              aktPartycipant.LikointervenceId = IntervenceId;
              if (DB.AddParticipant(aktPartycipant) < 1)
                break;
            }
            MessageBox.Show("Událost " + IncidentId.ToString() + " uložena");
            EmptyAll();

          }
        }
      }
      if (DB.sErr.Length > 0)
      {
        MessageBox.Show("Nelze zapsat událost. " + DB.sErr);
      }

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

    private void txtNrCelkem_Validating(object sender, CancelEventArgs e)
    {
      if (txtNrCelkem.Value <= 0)
      {
        cmbSubTypeIntervenceErrorProvider.SetError(this.txtNrCelkem, "Alespoň jeden Účastník musí být zadán");
        e.Cancel = true;
      }
      else
      {
        cmbSubTypeIntervenceErrorProvider.SetError(this.txtNrCelkem, "");
        e.Cancel = false;
      }

    }

    #endregion

    private void gbIntervence_Enter(object sender, EventArgs e)
    {

    }

    private void boxEvent_Enter(object sender, EventArgs e)
    {

    }

    private void ucParticipations1_Load(object sender, EventArgs e)
    {

    }

    public void ucParticipations_NewRow()
    {
      txtNrCelkem.Value = ucParticipations1.participantsList.Count(); 
    }

    private void ucCallLIKO_Resize(object sender, EventArgs e)
    {
      ucParticipations1.Width = this.Width;
    }


    private void EmptyAll()
    {
      dtCall.Value = DateTime.Now;
      tmCall.Value = DateTime.Now;
      cmbIntervent.SelectedIndex = 0;
      dtIncident.Value = DateTime.Now;
      tmIncident.Value = DateTime.Now;
      cmbSubTypeIntervence.SelectedIndex = 0;
      txtPocetObeti.Value = 0;
      cmbRegion.SelectedIndex = 0;
      txtPlace.Text = string.Empty;
      chkNasledekSmrti.Checked = chkDokonane.Checked = chkPokusPriprava.Checked = false;
      txtEventNote.Text = string.Empty;
      dtIntervence.Value = DateTime.Now;
      tmIntervence.Value = DateTime.Now;
      dtIntervenceEnd.Value = DateTime.Now;
      tmIntervenceEnd.Value = DateTime.Now;
      txtNrCelkem.Value = 0;
      txtNrObetemPoskozenym.Value = 0;  
      txtNrOstatnimOsobam.Value = 0;  
      txtNrPozustalymBlizkym.Value = 0; 
      txtIntervenceNote.Text = string.Empty;
      ucParticipations1.EmptyAllRow();
    }
  }
}
