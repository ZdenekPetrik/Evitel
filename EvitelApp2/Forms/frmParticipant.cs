using EvitelApp2.Controls;
using EvitelLib2.Model;
using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace EvitelApp2
{
  public partial class frmParticipant : Form
  {
    public Controls.ucParticipations master;
    public Likoparticipant aktRow;

    private ErrorProvider errTypePartyEid;
    private ErrorProvider errSexEid;
    private ErrorProvider errDruhIntervenceEid;
    private ErrorProvider errIntervent;
    private ErrorProvider errNumAge;
    public char TypOkna; // Create,Update,Delete, Show
    public int Poradi;
    public bool isOK = false;


    public frmParticipant()
    {
      InitializeComponent();

    }

    private void frmParticipant_Load(object sender, EventArgs e)
    {
      if (TypOkna == 'C')
      {
        this.Text = "Nový účastník události";
        btnCokoli.Text = "Vytvoř nový";
      }
      else if (TypOkna == 'U')
      {
        this.Text = "Editace " + Poradi.ToString() + ". účastníka události";
        btnCokoli.Text = "Upravit";
      }
      else if (TypOkna == 'D')
      {
        this.Text = "Smazání " + Poradi.ToString() + ". účastníka události";
        DoReadOnly();
        btnCokoli.Text = "Smazat";
      }
      else if (TypOkna == 'S')
      {
        this.Text = "Náhled " + Poradi.ToString() + ".  účastníka události";
        DoReadOnly();
        btnCokoli.Visible = false;
      }
      cmbTypeParty.Items.Add(new ComboItem("<Nevybráno>", "-1"));
      cmbTypeParty.SelectedIndex = 0;
      foreach (var typeParty in master.typeParty)
      {
        if (typeParty.DtDeleted == null)
        {
          cmbTypeParty.Items.Add(new ComboItem(typeParty.Text, typeParty.TypePartyId.ToString()));
          if ((aktRow.TypePartyEid) == typeParty.TypePartyId)
            cmbTypeParty.SelectedIndex = cmbTypeParty.Items.Count - 1;
        }
      }
      cmbSex.Items.Add(new ComboItem("<Nevybráno>", "-1"));
      cmbSex.SelectedIndex = 0;
      foreach (var sex in master.sex)
      {
        if (sex.DtDeleted == null)
        {
          cmbSex.Items.Add(new ComboItem(sex.Text, sex.SexId.ToString()));
          if ((aktRow.SexEid) == sex.SexId)
            cmbSex.SelectedIndex = cmbSex.Items.Count - 1;
        }
      }
      cmbDruhIntervence.Items.Add(new ComboItem("<Nevybráno>", "-1"));
      cmbDruhIntervence.SelectedIndex = 0;
      foreach (var druhIntervence in master.druhIntervence)
      {
        if (druhIntervence.DtDeleted == null)
        {
          cmbDruhIntervence.Items.Add(new ComboItem(druhIntervence.Text, druhIntervence.DruhIntervenceId.ToString()));
          if ((aktRow.DruhIntervenceEid) == druhIntervence.DruhIntervenceId)
            cmbDruhIntervence.SelectedIndex = cmbDruhIntervence.Items.Count - 1;
        }
      }
      cmbIntervent.Items.Add(new ComboItem("<Nevybráno>", "-1"));
      cmbIntervent.SelectedIndex = 0;
      cmbIntervent2.Items.Add(new ComboItem("<Nevybráno>", "-1"));
      cmbIntervent2.SelectedIndex = 0;
      foreach (var intervent in master.winterventi)
      {
        if (intervent.IsDeleted == false)
        {
          cmbIntervent.Items.Add(new ComboItem(intervent.CmbName, intervent.InterventId.ToString()));
          cmbIntervent2.Items.Add(new ComboItem(intervent.CmbName, intervent.InterventId.ToString()));
          if ((aktRow.InterventId ) == intervent.InterventId)
            cmbIntervent.SelectedIndex = cmbIntervent.Items.Count - 1;
          if ((aktRow.InterventId2 ?? 0) == intervent.InterventId)
           cmbIntervent2.SelectedIndex = cmbIntervent2.Items.Count - 1;
        }
      }
      errTypePartyEid = InitializeErrorProvider(1, cmbTypeParty);
      errSexEid = InitializeErrorProvider(1, cmbSex);
      errDruhIntervenceEid = InitializeErrorProvider(1, cmbDruhIntervence);
      errIntervent = InitializeErrorProvider(1, cmbIntervent);
      errNumAge = InitializeErrorProvider(1, numAge);
      ReadThisNewParticipant();
    }

    // Pro případ Delete a Show  
    private void DoReadOnly()
    {
      foreach (var o in this.Controls)
      {
        if (o is TextBox)
          ((TextBox)o).ReadOnly = true;
        if (o is CheckBox)
          ((CheckBox)o).Enabled = false;
        if (o is ComboBox)
          ((ComboBox)o).Enabled = false;
        if (o is NumericUpDown)
          ((NumericUpDown)o).Enabled = false;
      }
    }

    private ErrorProvider InitializeErrorProvider(int type, Control myControl)
    {
      var x = new System.Windows.Forms.ErrorProvider();
      x.SetIconAlignment(myControl, ErrorIconAlignment.MiddleRight);
      x.SetIconPadding(myControl, 2);
      x.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
      x.Icon = (type == 1 ? Resource.error_Icon : Resource.warning_Icon);
      return x;
    }
    private void btnCokoli_Click(object sender, EventArgs e)
    {
      if (TypOkna == 'C' || TypOkna == 'U')
      {
        if (ValidateChildren())
        {
          if (DialogResult.Yes == MessageBox.Show("Opravdu zapsat účastníka?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
          {
            WriteThisNewParticipant();
            isOK = true;
            this.Close();
          }
        }
        else
        {
          MessageBox.Show("Validation failed.");
        }
        return;
      }
      if (TypOkna == 'S' || TypOkna == 'D')
      {
        isOK = true;
        this.Close();
      }
    }

    private void WriteThisNewParticipant()
    {
      aktRow.TypePartyEid = ((ComboItem)cmbTypeParty.SelectedItem).iValue;
      aktRow.SexEid = ((ComboItem)cmbSex.SelectedItem).iValue;
      aktRow.InterventId = ((ComboItem)cmbIntervent.SelectedItem).iValue;
      aktRow.InterventId2 = ((ComboItem)cmbIntervent2.SelectedItem).iValue;
      if (aktRow.InterventId2 == -1)
        aktRow.InterventId2 = null;
      aktRow.DruhIntervenceEid = ((ComboItem)cmbDruhIntervence.SelectedItem).iValue;
      aktRow.Age = (int)numAge.Value;
      aktRow.IsAgreement = chkAgreement.Checked;
      aktRow.IsAgreementBkb = chkAgreementBKB.Checked;
      aktRow.IsChildJuvenile = chkChildJuvenile.Checked;
      aktRow.IsContact = chkContact.Checked;
      aktRow.IsDead = chkIsDead.Checked;
      aktRow.IsFirstIntervence = chkIsFirstIntervence.Checked;
      aktRow.IsHandyCappedMedical = chkHandyCappedMedical.Checked;
      aktRow.IsHandyCappedMentally = chkHandyCappedMentally.Checked;
      aktRow.IsInjury = chkIsInjury.Checked;
      aktRow.IsIntervence = chkIsIntervence.Checked;
      aktRow.IsMemberMinorityGroup = chkIsMemberMinorityGroup.Checked;
      aktRow.IsPolicement = chkPolicement.Checked;
      aktRow.IsPolicementClosePerson = chkPolicemenClosePerson.Checked;
      aktRow.IsSenior = chkSenior.Checked;
      aktRow.Note = txtNote.Text;
      aktRow.Organization = txtOrganizace.Text;
    }

    private void ReadThisNewParticipant()
    {
      for (int i = 0; i < cmbTypeParty.Items.Count; i++)
      {
        if (((ComboItem)cmbTypeParty.Items[i]).iValue == (aktRow.TypePartyEid))
          cmbTypeParty.SelectedIndex = i;
      }
      for (int i = 0; i < cmbSex.Items.Count; i++)
      {
        if (((ComboItem)cmbSex.Items[i]).iValue == (aktRow.SexEid))
          cmbSex.SelectedIndex = i;
      }
      for (int i = 0; i < cmbIntervent.Items.Count; i++)
      {
        if (((ComboItem)cmbIntervent.Items[i]).iValue == (aktRow.InterventId))
          cmbIntervent.SelectedIndex = i;
      }
      cmbIntervent2.SelectedIndex = 0;
      for (int i = 0; i < cmbIntervent2.Items.Count; i++)
      {
        if (((ComboItem)cmbIntervent2.Items[i]).iValue == (aktRow.InterventId2 ?? -1))
          cmbIntervent2.SelectedIndex = i;
      }
      for (int i = 0; i < cmbDruhIntervence.Items.Count; i++)
      {
        if (((ComboItem)cmbDruhIntervence.Items[i]).iValue == (aktRow.DruhIntervenceEid ))
          cmbDruhIntervence.SelectedIndex = i;
      }

      numAge.Value = (decimal)(aktRow.Age) ;
      chkAgreement.Checked = aktRow.IsAgreement ;
      chkAgreementBKB.Checked = aktRow.IsAgreementBkb;
      chkChildJuvenile.Checked = aktRow.IsChildJuvenile;
      chkContact.Checked = aktRow.IsContact;
      chkIsDead.Checked = aktRow.IsDead;
      chkIsFirstIntervence.Checked = aktRow.IsFirstIntervence;
      chkHandyCappedMedical.Checked = aktRow.IsHandyCappedMedical ;
      chkHandyCappedMentally.Checked = aktRow.IsHandyCappedMentally ;
      chkIsInjury.Checked = aktRow.IsInjury ;
      chkIsIntervence.Checked = aktRow.IsIntervence ;
      chkIsMemberMinorityGroup.Checked = aktRow.IsMemberMinorityGroup;
      chkPolicement.Checked = aktRow.IsPolicement ;
      chkPolicemenClosePerson.Checked = aktRow.IsPolicementClosePerson;
      chkSenior.Checked = aktRow.IsSenior ;
      txtNote.Text = aktRow.Note??"";
      txtOrganizace.Text = aktRow.Organization??"";

      /*
      cmbTypeParty.SelectedIndex = 2;
      cmbSex.SelectedIndex = 2;
      cmbIntervent.SelectedIndex = 2;
      cmbDruhIntervence.SelectedIndex = 2;
      numAge.Value = 66;
      chkSenior.Checked = true;
      */
    }

    private void cmbTypeParty_Validating(object sender, CancelEventArgs e)
    {
      if (cmbTypeParty.SelectedIndex == 0)
      {
        errTypePartyEid.SetError(this.cmbTypeParty, "Položka Forma účasti musí být vyplněna");
        e.Cancel = true;
      }
      else
      {
        errTypePartyEid.SetError(this.cmbTypeParty, "");
        e.Cancel = false;
      }
    }

    private void cmbSex_Validating(object sender, CancelEventArgs e)
    {
      if (cmbSex.SelectedIndex == 0)
      {
        errSexEid.SetError(this.cmbSex, "Položka Pohlaví musí být vyplněna");
        e.Cancel = true;
      }
      else
      {
        errSexEid.SetError(this.cmbSex, "");
        e.Cancel = false;
      }
    }

    private void numAge_Validating(object sender, CancelEventArgs e)
    {
      if ((int)this.numAge.Value < 1 || (int)this.numAge.Value > 120)
      {
        errNumAge.SetError(this.numAge, "Položka Věk musí být vyplněna v rozmezí 1-120");
        e.Cancel = true;
      }
      else
      {
        errNumAge.SetError(this.numAge, "");
        e.Cancel = false;
      }

    }

    private void cmbDruhIntervence_Validating(object sender, CancelEventArgs e)
    {
      if (cmbDruhIntervence.SelectedIndex == 0)
      {
        errDruhIntervenceEid.SetError(this.cmbDruhIntervence, "Položka Druh intervence musí být vyplněna");
        e.Cancel = true;
      }
      else
      {
        errDruhIntervenceEid.SetError(this.cmbDruhIntervence, "");
        e.Cancel = false;
      }

    }

    private void cmbIntervent_Validating(object sender, CancelEventArgs e)
    {
      if (cmbIntervent.SelectedIndex == 0)
      {
        errIntervent.SetError(this.cmbIntervent, "Položka Intervent musí být vyplněna");
        e.Cancel = true;
      }
      else
      {
        errIntervent.SetError(this.cmbIntervent, "");
        e.Cancel = false;
      }


    }
  }
}

