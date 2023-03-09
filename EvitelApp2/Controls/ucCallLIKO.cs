using EvitelApp2.Helper;
using EvitelLib2;
using EvitelLib2.Common;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using NPOI.OpenXmlFormats.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EvitelApp2.frmMain;

namespace EvitelApp2.Controls
{
  public partial class ucCallLIKO : UserControl, IctrlWithDGW
  {
    List<string> ErrorList = new List<string>();
    List<string> WarningList = new List<string>();

    CRepositoryDB DB;

    private ErrorProvider placeErrorProvider;
    private ErrorProvider placeWarningProvider;
    private ErrorProvider cmbInterventErrorProvider;
    private ErrorProvider cmbRegionErrorProvider;
    private ErrorProvider cmbSubTypeIncidentErrorProvider;

    public int LikoIntervenceId;
    Call aktCall;
    Likoincident aktLikoIncident;
    Likointervence aktLikoIntervence;

    List<WIntervent> intervents;
    List<EvitelLib2.Model.Region> regions;
    List<ESubTypeIncident> subTypeIncidents;

    public event DetailIntervence ShowDetailUserControl;
    public bool isNewForm = true;              // tvorime novou intervenci
    public bool isEditMode = true;            // zobrazeni existujici intervence (tj. isNew == false). Tak ještě je třeba rozhodnout zdali smíme editovat. Zde si to ale nastavuji sam v ReadDBData()

    // pokud zmeni nejakou hodnotu pri editu tak uvolni button Save
    private bool changedAnyValue { get { return _changedAnyValue; } set { if (isNewForm == false && isEditMode) { _changedAnyValue = true; btnWrite.Enabled = true; } } }

    public DataTable dataTable => throw new NotImplementedException();

    private bool _changedAnyValue = false;
    public string Title
    {
      set { this.lblTitulek.Text = value; }
    }

    public ucCallLIKO()
    {
      InitializeComponent();
    }

    private void ucCallLIKO_Load(object sender, EventArgs e)
    {
      if (DesignMode)
        return;
      DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
      intervents = DB.GetWIntervents(null, "", "");
      cmbIntervent.Items.Add(new ComboItem("<Nevybráno>", ""));
      foreach (var intervent in intervents)
      {
        if (intervent.IsDeleted != true)
          cmbIntervent.Items.Add(new ComboItem(intervent.CmbName, intervent.InterventId.ToString()));
      }
      regions = DB.GetRegions();
      cmbRegion.Items.Add(new ComboItem("<Nevybráno>", ""));
      foreach (EvitelLib2.Model.Region region in regions)
      {
        cmbRegion.Items.Add(new ComboItem(region.ShortName + " - " + region.Name, region.RegionId.ToString()));
      }

      subTypeIncidents = DB.GetSubTypeIncident();
      cmbSubTypeIncident.Items.Add(new ComboItem("<Nevybráno>", ""));
      foreach (EvitelLib2.Model.ESubTypeIncident subTypeIntervence in subTypeIncidents)
      {
        if (subTypeIntervence.DtDeleted == null)
          cmbSubTypeIncident.Items.Add(new ComboItem(subTypeIntervence.Text, subTypeIntervence.SubTypeIncidentId.ToString()));
      }
      placeErrorProvider = InitializeErrorProvider(1, txtPlace);
      placeWarningProvider = InitializeErrorProvider(2, txtPlace);
      cmbInterventErrorProvider = InitializeErrorProvider(1, cmbIntervent);
      cmbRegionErrorProvider = InitializeErrorProvider(1, cmbRegion);
      cmbSubTypeIncidentErrorProvider = InitializeErrorProvider(1, cmbSubTypeIncident);
      ucParticipations1.RowChanged_Event += ucParticipations_NewRow;
      ucParticipations1.DataChanged_Event += ucParticipations_DataChanged;
      this.dtCall.ValueChanged += new System.EventHandler(this.Any_ValueChanged);
      this.tmCall.ValueChanged += new System.EventHandler(this.Any_ValueChanged);
      this.dtIncident.ValueChanged += this.Any_ValueChanged;
      this.tmIncident.ValueChanged += this.Any_ValueChanged;
      this.dtIntervence.ValueChanged += this.Any_ValueChanged;
      this.tmIntervence.ValueChanged += this.Any_ValueChanged;
      this.dtIntervenceEnd.ValueChanged += this.Any_ValueChanged;
      this.tmIntervenceEnd.ValueChanged += this.Any_ValueChanged;
      this.cmbIntervent.SelectedIndexChanged += this.cmbIntervent_ValueChanged;
      this.cmbRegion.SelectedIndexChanged += this.Any_ValueChanged;
      this.cmbSubTypeIncident.SelectedIndexChanged += this.Any_ValueChanged;
      this.txtIntervenceNote.TextChanged += this.Any_ValueChanged;
      this.txtEventNote.TextChanged += this.Any_ValueChanged;
      this.txtPlace.TextChanged += this.Any_ValueChanged;
      this.chkDokonane.CheckedChanged += this.Any_ValueChanged;
      this.chkNasledekSmrti.CheckedChanged += this.Any_ValueChanged;
      this.chkPokusPriprava.CheckedChanged += this.Any_ValueChanged;
      this.chkSecondIntervence.CheckedChanged += this.Any_ValueChanged;
      this.txtPocetObeti.ValueChanged += this.Any_ValueChanged;
      this.txtNrCelkem.ValueChanged += this.Any_ValueChanged;
      this.txtNrObetemPoskozenym.ValueChanged += this.Any_ValueChanged;
      this.txtNrOstatnimOsobam.ValueChanged += this.Any_ValueChanged;
      this.txtNrPozustalymBlizkym.ValueChanged += this.Any_ValueChanged;
      txtSecondIncidentID.Controls[0].Visible = false;
      PrepareScreen();
    }




    // Volá se při LOAD a pak vždy poté co nadřazený proces rozhodne co zobrazit
    public void PrepareScreen()
    {
      if (isNewForm)
      {
        btnBack.Visible = false;
        btnWrite.Enabled = true;
        btnWrite.Text = "Uložit";
        lblSupposeId.Text = "Předpokládané Id události";
        txtLoginUser.Text = Program.myLoggedUser.FirstName + " " + Program.myLoggedUser.LastName;
        ucParticipations1.isNew = true;
        EmptyAll();
      }
      else
      {
        btnBack.Visible = true;
        btnWrite.Text = "Upravit";
        aktLikoIntervence = DB.GetLikoIntervence(LikoIntervenceId);
        aktCall = DB.GetCall(aktLikoIntervence.CallId ?? 0);
        aktLikoIncident = DB.GetLikoIncident(aktLikoIntervence.LikoincidentId ?? 0);
        ucParticipations1.participantsList = DB.GetLikoParticipants(aktLikoIntervence.LikointervenceId, 2);
        isEditMode = (Program.myLoggedUser.HasAccess(eLoginAccess.PowerUser) || (aktCall.DtStartCall?.AddMonths(1) > DateTime.Now && aktCall.LoginUserId == Program.myLoggedUser.LoginUserId));
        ucParticipations1.isEditMode = isEditMode;
        ucParticipations1.isNew = false;
        var anyUser = DB.GetUsers().Where(x => x.LoginUserId == aktCall.LoginUserId).FirstOrDefault();
        txtLoginUser.Text = anyUser.FirstName + " " + anyUser.LastName;
        txtSupposedId.Text = aktLikoIncident.LikoincidentId.ToString();
        lblSupposeId.Text = "Id události";
        LoadAllData();
        btnWrite.Enabled = false;     // je nutné nakonec - mění se při první změně
        btnQuickLPvK.Visible = false;
      }
      chkSecondIntervence_CheckedChanged(null, null);
      ucParticipations1.InitData();
      SpoctiDobuIntervence();
      ReWriteScreen();
    }


    private void ReWriteScreen()
    {
      boxCall.Top = 50;
      boxCall.Left = boxEvent.Left = boxIntervence.Left = 3;
      boxEvent.Top = boxCall.Top + boxCall.Height + 5;
      boxIntervence.Top = boxEvent.Top + boxEvent.Height + 5;
      ucParticipations1.Top = boxIntervence.Top + boxIntervence.Height + 5;

    }


    private void btnWrite_Click(object sender, EventArgs e)
    {
      if (ValidateChildren())
      {
        if (txtNrCelkem.Value > 0)
        {
          if (DialogResult.Yes == MessageBox.Show("Opravdu " + btnWrite.Text + " tuto intervenci ?", "SKI intervence", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            if (isNewForm)
              WriteThisNewCall();
            else
              UpdateThisNewCall();
        }
        else
        {
          MessageBox.Show("Alespoň jeden intervenovaný 'Účastník intervence' musí existovat");
        }
      }
      else
      {
        MessageBox.Show("Validation failed.");
      }
      return;
    }

    private void TxtNrCelkem_Validating(object sender, CancelEventArgs e)
    {
      throw new NotImplementedException();
    }



    private void WriteThisNewCall()
    {
      int IncidentId = 0;
      if (chkSecondIntervence.Checked)
      {
        var aktLikoIncident = DB.GetLikoIncident((int)txtSecondIncidentID.Value);
        if (aktLikoIncident == null)
        {
          MessageBox.Show("Incident ID = " + ((int)txtSecondIncidentID.Value).ToString() + " neexistuje.");
          return;
        }
        else
        {
          IncidentId = aktLikoIncident.LikoincidentId;
        }
      }
      DateTime datetimeStartCall = dtCall.Value.Date.Add(TimeSpan.Parse(tmCall.Value.ToShortTimeString()));
      int CallId = DB.WriteCall(datetimeStartCall, (int)eCallType.eLIKO, null);
      if (CallId > 0)
      {
        if (chkSecondIntervence.Checked != true)
        {
          DateTime datetimeIncident = dtIncident.Value.Date.Add(TimeSpan.Parse(tmIncident.Value.ToShortTimeString()));
          IncidentId = DB.WriteIncident(txtEventNote.Text, ((ComboItem)cmbSubTypeIncident.SelectedItem).iValue, datetimeIncident, ((ComboItem)cmbRegion.SelectedItem).iValue, txtPlace.Text, chkNasledekSmrti.Checked, chkDokonane.Checked, chkPokusPriprava.Checked, (int)txtPocetObeti.Value);
        }
        if (IncidentId > 0)
        {
          DateTime datetimeStartIntervence = dtIntervence.Value.Date.Add(TimeSpan.Parse(tmIntervence.Value.ToShortTimeString()));
          DateTime datetimeEndIntervence = dtIntervenceEnd.Value.Date.Add(TimeSpan.Parse(tmIntervenceEnd.Value.ToShortTimeString()));
          int IntervenceId = DB.WriteIntervence(datetimeStartIntervence, datetimeEndIntervence, CallId, IncidentId, txtIntervenceNote.Text, (int)txtNrCelkem.Value, (int)txtNrObetemPoskozenym.Value, (int)txtNrPozustalymBlizkym.Value, (int)txtNrOstatnimOsobam.Value, ((ComboItem)cmbIntervent.SelectedItem).iValue);
          if (IntervenceId > 0)
          {
            DB.UpdateParticipants(IntervenceId, ucParticipations1.participantsList);
            MessageBox.Show("SKI Událost ID = " + IncidentId.ToString() + " uložena");
            EmptyAll();
            ucParticipations1.EmptyAllRow();
          }
        }
      }
      if (DB.sErr.Length > 0)
      {
        MessageBox.Show("Nelze zapsat událost. " + DB.sErr);
      }
    }


    private void UpdateThisNewCall()
    {
      DateTime datetimeStartCall = dtCall.Value.Date.Add(TimeSpan.Parse(tmCall.Value.ToShortTimeString()));
      if (datetimeStartCall != aktCall.DtStartCall)
      {
        DB.UpdateCall(aktCall.CallId, datetimeStartCall);
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CallTable, aktCall.DtStartCall.ToString() + " -> " + datetimeStartCall.ToString(), aktCall.CallId.ToString(), Program.myLoggedUser.LoginUserId);
        aktCall = DB.GetCall(aktLikoIntervence.CallId ?? 0);
      }
      bool isChangeIntervence = false;
      if (((ComboItem)cmbIntervent.SelectedItem).iValue != aktLikoIntervence.InterventId)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, intervents.Where(x => x.InterventId == aktLikoIntervence.InterventId).Select(x => x.CmbName).First() + " -> " + ((ComboItem)cmbIntervent.SelectedItem).Text, aktLikoIntervence.InterventId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIntervence = true;
      }
      DateTime datetimeStartIntervence = dtIntervence.Value.Date.Add(TimeSpan.Parse(tmIntervence.Value.ToShortTimeString()));
      DateTime datetimeEndIntervence = dtIntervenceEnd.Value.Date.Add(TimeSpan.Parse(tmIntervenceEnd.Value.ToShortTimeString()));

      if (datetimeStartIntervence != aktLikoIntervence.DtStartIntervence)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, "Start Intervence " + aktLikoIntervence.DtStartIntervence.ToString() + " -> " + datetimeStartIntervence.ToString(), aktLikoIntervence.InterventId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIntervence = true;
      }
      if (datetimeEndIntervence != aktLikoIntervence.DtEndIntervence)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, "End Intervence " + aktLikoIntervence.DtEndIntervence.ToString() + " -> " + datetimeEndIntervence.ToString(), aktLikoIntervence.InterventId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIntervence = true;
      }
      if (txtNrPozustalymBlizkym.Value != aktLikoIntervence.PozustalymBlizkym)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, "Pozustalym Blizkym " + txtNrPozustalymBlizkym.Value + " -> " + aktLikoIntervence.PozustalymBlizkym.ToString(), aktLikoIntervence.InterventId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIntervence = true;
      }
      if (txtNrObetemPoskozenym.Value != aktLikoIntervence.ObetemPoskozenym)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, "Obetem Poskozenym " + txtNrObetemPoskozenym.Value + " -> " + aktLikoIntervence.ObetemPoskozenym.ToString(), aktLikoIntervence.InterventId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIntervence = true;
      }
      if (txtNrOstatnimOsobam.Value != aktLikoIntervence.Ostatnim)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, "Obetem Poskozenym " + txtNrOstatnimOsobam.Value + " -> " + aktLikoIntervence.Ostatnim.ToString(), aktLikoIntervence.InterventId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIntervence = true;
      }
      if (txtIntervenceNote.Text != aktLikoIntervence.Note)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, "Poznámka" + txtIntervenceNote.Text + " -> " + aktLikoIntervence.Note, aktLikoIntervence.InterventId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIntervence = true;
      }
      if (isChangeIntervence)
      {
        DB.UpdateIntervence(aktLikoIntervence.LikointervenceId, datetimeStartIntervence, datetimeEndIntervence, (int)txtNrObetemPoskozenym.Value, (int)txtNrPozustalymBlizkym.Value, (int)txtNrOstatnimOsobam.Value, txtIntervenceNote.Text);
        aktLikoIntervence = DB.GetLikoIntervence(aktLikoIntervence.LikointervenceId);
      }
      bool isChangeIncident = false;
      DateTime datetimeIncident = dtIncident.Value.Date.Add(TimeSpan.Parse(tmIncident.Value.ToShortTimeString()));
      if (datetimeIncident != aktLikoIncident.DtIncident)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IncidentTable, "Start Incident " + aktLikoIncident.DtIncident.ToString() + " -> " + datetimeIncident.ToString(), aktLikoIncident.LikoincidentId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIncident = true;
      }
      if (((ComboItem)cmbSubTypeIncident.SelectedItem).iValue != aktLikoIncident.SubTypeIncidentEid)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IncidentTable, subTypeIncidents.Where(x => x.SubTypeIncidentId == aktLikoIncident.SubTypeIncidentEid).Select(x => x.Text).First() + " -> " + ((ComboItem)cmbSubTypeIncident.SelectedItem).Text, aktLikoIncident.LikoincidentId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIncident = true;
      }
      if (((ComboItem)cmbRegion.SelectedItem).iValue != aktLikoIncident.RegionId)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IncidentTable, regions.Where(x => x.RegionId == aktLikoIncident.RegionId).Select(x => x.Name).First() + " -> " + ((ComboItem)cmbRegion.SelectedItem).Text, aktLikoIncident.LikoincidentId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIncident = true;
      }
      if (txtEventNote.Text != aktLikoIncident.Note)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, "Poznámka " + txtEventNote.Text + " -> " + aktLikoIncident.Note, aktLikoIncident.LikoincidentId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIncident = true;
      }
      if (txtPlace.Text != aktLikoIncident.Place)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, "Místo " + txtPlace.Text + " -> " + aktLikoIncident.Note, aktLikoIncident.LikoincidentId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIncident = true;
      }
      if (txtPocetObeti.Value != aktLikoIncident.PocetPoskozenych)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, "Počet počkozených " + txtPocetObeti.Value.ToString() + " -> " + aktLikoIncident.PocetPoskozenych, aktLikoIncident.LikoincidentId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIncident = true;
      }
      if (chkDokonane.Checked != aktLikoIncident.Dokonane)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, "Dokonané " + chkDokonane.Checked.ToString() + " -> " + aktLikoIncident.Dokonane.ToString(), aktLikoIncident.LikoincidentId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIncident = true;
      }
      if (chkNasledekSmrti.Checked != aktLikoIncident.NasledekSmrti)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, "Dokonané " + chkNasledekSmrti.Checked.ToString() + " -> " + aktLikoIncident.NasledekSmrti.ToString(), aktLikoIncident.LikoincidentId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIncident = true;
      }
      if (chkPokusPriprava.Checked != aktLikoIncident.PokusPriprava)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2IntervenceTable, "Dokonané " + chkPokusPriprava.Checked.ToString() + " -> " + aktLikoIncident.PokusPriprava.ToString(), aktLikoIncident.LikoincidentId.ToString(), Program.myLoggedUser.LoginUserId);
        isChangeIncident = true;
      }

      if (isChangeIncident)
      {
        DB.UpdateIncident(aktLikoIncident.LikoincidentId, datetimeIncident, ((ComboItem)cmbSubTypeIncident.SelectedItem).iValue, ((ComboItem)cmbRegion.SelectedItem).iValue, txtEventNote.Text, txtPlace.Text, (int)txtPocetObeti.Value, chkDokonane.Checked, chkNasledekSmrti.Checked, chkPokusPriprava.Checked);
        aktLikoIncident = DB.GetLikoIncident(aktLikoIncident.LikoincidentId);
      }
      DB.UpdateParticipants(aktLikoIntervence.LikointervenceId, ucParticipations1.participantsList);
      ucParticipations1.InitData();

      LoadAllData();
      btnWrite.Enabled = false;
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
        cmbInterventErrorProvider.SetError(this.cmbIntervent, "Intervent musí být vyplněn");
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
        cmbRegionErrorProvider.SetError(this.cmbRegion, "Region musí být vyplněn");
        e.Cancel = true;
      }
      else
      {
        cmbRegionErrorProvider.SetError(this.cmbRegion, "");
        e.Cancel = false;
      }
    }

    private void cmbSubTypeIncident_Validating(object sender, CancelEventArgs e)
    {
      if (cmbSubTypeIncident.SelectedIndex == 0)
      {
        cmbSubTypeIncidentErrorProvider.SetError(this.cmbSubTypeIncident, "Volající musí být vyplněn");
        e.Cancel = true;
      }
      else
      {
        cmbSubTypeIncidentErrorProvider.SetError(this.cmbSubTypeIncident, "");
        e.Cancel = false;
      }
    }


    #endregion



    public void ucParticipations_NewRow()
    {
      txtNrCelkem.Value = ucParticipations1.participantsList.Where(x => x.IsIntervence).Count();
    }
    public void ucParticipations_DataChanged()
    {
      changedAnyValue = true;
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
      cmbSubTypeIncident.SelectedIndex = 0;
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
      txtSupposedId.Text = DB.GetIncidentNextId().ToString();
    }

    private void LoadAllData()
    {
      dtCall.Value = (DateTime)aktCall.DtStartCall;
      tmCall.Value = (DateTime)aktCall.DtStartCall;
      cmbIntervent.SelectItemByValue(aktLikoIntervence.InterventId ?? 0);
      txtLoginUser.Text = aktCall.LoginUser.FirstName + " " + aktCall.LoginUser.LastName;

      dtIncident.Value = (DateTime)aktLikoIncident.DtIncident;
      tmIncident.Value = (DateTime)aktLikoIncident.DtIncident;
      cmbRegion.SelectItemByValue(aktLikoIncident.RegionId ?? 0);
      txtPlace.Text = aktLikoIncident.Place;
      cmbSubTypeIncident.SelectItemByValue(aktLikoIncident.SubTypeIncidentEid ?? 0);
      txtPocetObeti.Value = aktLikoIncident.PocetPoskozenych ?? 0;
      chkNasledekSmrti.Checked = aktLikoIncident.NasledekSmrti ?? false;
      chkDokonane.Checked = aktLikoIncident.Dokonane ?? false;
      chkPokusPriprava.Checked = aktLikoIncident.PokusPriprava ?? false;
      txtEventNote.Text = aktLikoIncident.Note;

      dtIntervence.Value = (DateTime)aktLikoIntervence.DtStartIntervence;
      tmIntervence.Value = (DateTime)aktLikoIntervence.DtStartIntervence;
      dtIntervenceEnd.Value = (DateTime)aktLikoIntervence.DtEndIntervence;
      tmIntervenceEnd.Value = (DateTime)aktLikoIntervence.DtEndIntervence;
      txtNrObetemPoskozenym.Value = aktLikoIntervence.ObetemPoskozenym ?? 0;
      txtNrPozustalymBlizkym.Value = aktLikoIntervence.PozustalymBlizkym ?? 0;
      txtNrOstatnimOsobam.Value = aktLikoIntervence.Ostatnim ?? 0;
      txtIntervenceNote.Text = aktLikoIntervence.Note;
      chkSecondIntervence.Checked = aktLikoIntervence.Poradi > 1;
      ucParticipations_NewRow();
    }


    private void btnBack_Click(object sender, EventArgs e)
    {
      ShowDetailUserControl?.Invoke(-1, 0);
    }



    // Univerzální metoda, abychom věděli že uživatel něco změnil a my mohli uvolnit editační button
    private void Any_ValueChanged(object sender, EventArgs e)
    {
      changedAnyValue = true;
    }
    private void cmbIntervent_ValueChanged(object sender, EventArgs e)
    {
      ucParticipations1.supposeIntervent = ((ComboItem)cmbIntervent.SelectedItem).iValue;
      Any_ValueChanged(sender, e);
    }



    private void btnDruhaIntervence_Click(object sender, EventArgs e)
    {
      if (isNewForm)
      {
        if (txtSecondIncidentID.Text.Length == 0)
        {
          //frmGetIntervence()
        }
        else
        {
          if (txtSecondIncidentID.Value > 0)
          {
            var aktLikoIncident = DB.GetLikoIncident((int)txtSecondIncidentID.Value);
            if (aktLikoIncident != null)
            {
              dtIncident.Value = (DateTime)aktLikoIncident.DtIncident;
              tmIncident.Value = (DateTime)aktLikoIncident.DtIncident;
              cmbRegion.SelectItemByValue(aktLikoIncident.RegionId ?? 0);
              txtPlace.Text = aktLikoIncident.Place;
              cmbSubTypeIncident.SelectItemByValue(aktLikoIncident.SubTypeIncidentEid ?? 0);
              txtPocetObeti.Value = aktLikoIncident.PocetPoskozenych ?? 0;
              chkDokonane.Checked = aktLikoIncident.NasledekSmrti ?? false;
              chkDokonane.Checked = aktLikoIncident.Dokonane ?? false;
              chkPokusPriprava.Checked = aktLikoIncident.PokusPriprava ?? false;
              txtEventNote.Text = aktLikoIncident.Note;
            }
            else
            {
              MessageBox.Show("Incident ID = " + ((int)txtSecondIncidentID.Value).ToString() + " neexistuje.");
            }
          }
        }

      }
    }

    private void chkSecondIntervence_CheckedChanged(object sender, EventArgs e)
    {
      if (isNewForm)
      {
        txtSecondIncidentID.Visible = chkSecondIntervence.Checked;
        btnDruhaIntervence.Visible = chkSecondIntervence.Checked;
        chkSecondIntervence.Enabled = true;
      }
      else
      {
        txtSecondIncidentID.Visible = false;
        btnDruhaIntervence.Visible = false;
        chkSecondIntervence.Enabled = false;
      }

    }

    public void SetColumns()
    {
      ucParticipations1.SetColumns();
    }

    public void InitColumns()
    {
      ucParticipations1.InitColumns();
    }

    public void RemoveOrders()
    {
      throw new NotImplementedException();
    }

    public void RemoveFilters()
    {
      throw new NotImplementedException();
    }

    private void txtEventNote_TextChanged_1(object sender, EventArgs e)
    {

    }

    private void dtIntervence_ValueChanged(object sender, EventArgs e)
    {
      SpoctiDobuIntervence();
    }

    private void tmIntervence_ValueChanged(object sender, EventArgs e)
    {
      SpoctiDobuIntervence();
    }

    private void dtIntervenceEnd_ValueChanged(object sender, EventArgs e)
    {
      SpoctiDobuIntervence();
    }

    private void tmIntervenceEnd_ValueChanged(object sender, EventArgs e)
    {
      SpoctiDobuIntervence();
    }

    private void SpoctiDobuIntervence()
    {
      DateTime datetimeStartIntervence = dtIntervence.Value.Date.Add(TimeSpan.Parse(tmIntervence.Value.ToShortTimeString()));
      DateTime datetimeEndIntervence = dtIntervenceEnd.Value.Date.Add(TimeSpan.Parse(tmIntervenceEnd.Value.ToShortTimeString()));
      TimeSpan s = datetimeEndIntervence - datetimeStartIntervence;
      lblIntervenceSum.Text = ((int)s.TotalHours).ToString("D2") + ":" + s.Minutes.ToString("D2");
    }

    private void ucCallLIKO_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible == false)
        this.CausesValidation = false;
    }

    private void boxIntervence_Enter(object sender, EventArgs e)
    {

    }

    private void btnQuickLPvK_Click(object sender, EventArgs e)
    {
      ShowDetailUserControl?.Invoke(-99, 1);

    }
  }
}
