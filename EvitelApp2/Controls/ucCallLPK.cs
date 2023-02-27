using EvitelLib2;
using EvitelLib2.Common;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using NPOI.SS.Formula.Functions;
using PdfSharpCore.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EvitelApp2.frmMain;

namespace EvitelApp2.Controls
{
  public partial class ucCallLPK : UserControl
  {
    public bool isNewForm;
    public bool isEditMode;
    public int LPKId;               // Pokud je isNewForm=true zde najdeš ID 

    private ErrorProvider cmbContactTypeErrorProvider;
    private ErrorProvider cmbTypeServiceErrorProvider;
    private ErrorProvider cmbFromErrorProvider;
    private ErrorProvider cmbSexErrorProvider;
    private ErrorProvider cmbAgeErrorProvider;
    private ErrorProvider tvContactTopicErrorProvider;
    private ErrorProvider tvCurrentClientStatusErrorProvider;
    private ErrorProvider tvEndOfSpeechErrorProvider;


    private CRepositoryDB DB;
    private List<ESex> sex;
    private List<EContactType> contactType;
    private List<ETypeService> typeService;
    private List<EClientFrom> clientFrom;
    private List<EAge> age;
    private List<ESubClientCurrentStatus> subClientCurrentStatus;
    private List<EClientCurrentStatus> clientCurrentStatus;
    private List<ESubContactTopic> subContactTopic;
    private List<EContactTopic> contactTopic;
    private List<ESubEndOfSpeech> subEndOfSpeech;
    private List<EEndOfSpeech> endOfSpeech;
    private List<int> endOfSpeech_Selected;
    private List<int> clientCurrentStatus_Selected;
    private List<int> contactTopic_Selected;

    public event DetailIntervence ShowDetailUserControl;
    private bool isTimer;


    Call aktCall;
    Lpk lpkRow;
    // pokud zmeni nejakou hodnotu pri editu tak uvolni button Save
    private bool changedAnyValue { get { return _changedAnyValue; } set { if (isNewForm == false && isEditMode) { _changedAnyValue = true; btnWrite.Enabled = true; } } }
    private bool _changedAnyValue = false;
    public string Title
    {
      set { this.lblTitulek.Text = value; }
    }

    private bool isHovor
    {
      get
      {
        return ((ComboItem)cmbTypeService.SelectedItem).iValue == 1 && ((ComboItem)cmbContactType.SelectedItem).iValue == 1; // Telefon + Hovor
      }
    }


    public ucCallLPK()
    {
      InitializeComponent();
    }


    private void ucCallLPK_Load(object sender, EventArgs e)
    {
      if (DesignMode)
        return;
      DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
      sex = DB.GetSex();
      contactType = DB.GetContactType();
      typeService = DB.GetTypeService();
      clientFrom = DB.GetClientFrom();
      age = DB.GetContactAge();
      subClientCurrentStatus = DB.GetSubClientCurrentStatus();
      clientCurrentStatus = DB.GetClientCurrentStatus().OrderBy(x => x.ClientCurrentStatusId).ToList();
      subContactTopic = DB.GetSubContactTopic();
      contactTopic = DB.GetContactTopic().OrderBy(x => x.ContactTopicId).ToList();
      endOfSpeech = DB.GetEndOfSpeech();
      subEndOfSpeech = DB.GetSubEndOfSpeech().OrderBy(x => x.EndOfSpeechId).ToList();

      cmbContactTypeErrorProvider = InitializeErrorProvider(1, cmbContactType);
      cmbTypeServiceErrorProvider = InitializeErrorProvider(1, cmbTypeService);
      cmbFromErrorProvider = InitializeErrorProvider(1, cmbFrom);
      cmbSexErrorProvider = InitializeErrorProvider(1, cmbSex);
      cmbAgeErrorProvider = InitializeErrorProvider(1, cmbAge);
      tvContactTopicErrorProvider = InitializeErrorProvider(1, tvContactTopic);
      tvCurrentClientStatusErrorProvider = InitializeErrorProvider(1, tvClientCurrentStatus);
      tvEndOfSpeechErrorProvider = InitializeErrorProvider(1, tvEndOfSpeech);


      txtVolajici.AutoCompleteSource = AutoCompleteSource.CustomSource;
      txtVolajici.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      txtVolajici.AutoCompleteCustomSource = new AutoCompleteStringCollection();

      this.dtCall.ValueChanged += this.Any_ValueChanged;
      this.tmCall.ValueChanged += this.Any_ValueChanged;
      this.tmCallTo.ValueChanged += this.Any_ValueChanged;
      this.txtVolajici.TextChanged += this.Any_ValueChanged;
      this.txtNote.TextChanged += this.Any_ValueChanged;
      this.cmbContactType.SelectedIndexChanged += this.Any_ValueChanged;
      this.cmbTypeService.SelectedIndexChanged += this.Any_ValueChanged;
      this.cmbFrom.SelectedIndexChanged += this.Any_ValueChanged;
      this.cmbSex.SelectedIndexChanged += this.Any_ValueChanged;
      this.cmbAge.SelectedIndexChanged += this.Any_ValueChanged;
      tvContactTopic.AfterCheck += this.Any_ValueChanged;
      tvClientCurrentStatus.AfterCheck += this.Any_ValueChanged;
      tvEndOfSpeech.AfterCheck += this.Any_ValueChanged;
    }


    public void PrepareScreen()
    {
      if (isNewForm)
      {
        btnBack.Visible = false;
        btnWrite.Enabled = true;
        btnWrite.Text = "Uložit";
        lblContactTopic.Text = "";
        lblCurrentClientStatus.Text = "";
        lblEndOfSpeech.Text = "";
        txtLoginUser.Text = Program.myLoggedUser.FirstName + " " + Program.myLoggedUser.LastName;
        txtNote.Text = "";
        txtVolajici.Text = "";
        tmCall.Value = DateTime.Now;
        tmCallTo.Value = DateTime.Now;
        lblEditInfo.Visible = false;
      }
      else
      {
        btnBack.Visible = true;
        lpkRow = DB.GetLPK(LPKId).First();
        aktCall = DB.GetCall(lpkRow.CallId);
        isEditMode = (Program.myLoggedUser.HasAccess(eLoginAccess.PowerUser) || (aktCall.DtEndCall?.AddMonths(1) > DateTime.Now && aktCall.LoginUserId == Program.myLoggedUser.LoginUserId));
        var anyUser = DB.GetUsers().Where(x => x.LoginUserId == aktCall.LoginUserId).FirstOrDefault();
        txtLoginUser.Text = anyUser.FirstName + " " + anyUser.LastName;
        btnWrite.Enabled = false;     // je nutné nakonec - mění se při první změně
        txtVolajici.Text = lpkRow.Nick;
        txtNote.Text = lpkRow.Note;
        dtCall.Value = (DateTime)aktCall.DtStartCall;
        tmCall.Value = (DateTime)aktCall.DtStartCall;
        tmCallTo.Value = (DateTime)aktCall.DtEndCall;
        lblEditInfo.Text = "Id:" + lpkRow.Lpkid.ToString() + "; " + (isEditMode ? "EDIT" : "NO-EDIT");
        lblEditInfo.Visible = true;
        btnQuickLPvK.Visible = false;
        ReWriteScreen();
      }

      cmbSex.Items.Clear();
      cmbSex.Items.Add(new ComboItem("<Nevybráno>", ""));
      if (isNewForm)
      {
        foreach (var row in sex)
        {
          if (row.DtDeleted == null)
            cmbSex.Items.Add(new ComboItem(row.Text, row.SexId.ToString()));
        }
      }
      else
      {
        foreach (var row in sex)
        {
          if (row.DtDeleted == null || lpkRow.SexEid == row.SexId)
            cmbSex.Items.Add(new ComboItem(row.Text, row.SexId.ToString()));
          if (lpkRow.SexEid == row.SexId)
            cmbSex.SelectedIndex = cmbSex.Items.Count - 1;
        }
      }
      if (cmbSex.SelectedItem == null)      // Protoze je potreba i osetrit moznost NULL (není vybrán žádný sex - třeba u Omylu, nebo prozvonění)
        cmbSex.SelectedIndex = 0;

      cmbContactType.Items.Clear();
      if (isNewForm)
      {
        cmbContactType.Items.Add(new ComboItem("<Nevybráno>", ""));
        foreach (var row in contactType)
        {
          if (row.DtDeleted == null)
            cmbContactType.Items.Add(new ComboItem(row.Text, row.ContactTypeId.ToString()));
        }
        cmbContactType.SelectedIndex = 0;
      }
      else
      {
        foreach (var row in contactType)
        {
          if (row.DtDeleted == null || lpkRow.ContactTypeEid == row.ContactTypeId)
            cmbContactType.Items.Add(new ComboItem(row.Text, row.ContactTypeId.ToString()));
          if (lpkRow.ContactTypeEid == row.ContactTypeId)
            cmbContactType.SelectedIndex = cmbContactType.Items.Count - 1;
        }
      }

      cmbTypeService.Items.Clear();
      if (isNewForm)
      {
        cmbTypeService.Items.Add(new ComboItem("<Nevybráno>", ""));
        foreach (var row in typeService)
        {
          if (row.DtDeleted == null)
            cmbTypeService.Items.Add(new ComboItem(row.Text, row.TypeServiceId.ToString()));
        }
        cmbTypeService.SelectedIndex = 0;

      }
      else
      {
        foreach (var row in typeService)
        {
          if (row.DtDeleted == null || lpkRow.TypeServiceEid == row.TypeServiceId)
            cmbTypeService.Items.Add(new ComboItem(row.Text, row.TypeServiceId.ToString()));
          if (lpkRow.TypeServiceEid == row.TypeServiceId)
            cmbTypeService.SelectedIndex = cmbTypeService.Items.Count - 1;
        }
      }

      cmbFrom.Items.Clear();
      cmbFrom.Items.Add(new ComboItem("<Nevybráno>", ""));
      if (isNewForm)
      {
        foreach (var row in clientFrom)
        {
          if (row.DtDeleted == null)
            cmbFrom.Items.Add(new ComboItem(row.Text, row.ClientFromId.ToString()));
        }
      }
      else
      {
        foreach (var row in clientFrom)
        {
          if (row.DtDeleted == null || lpkRow.ClientFromEid == row.ClientFromId)
            cmbFrom.Items.Add(new ComboItem(row.Text, row.ClientFromId.ToString()));
          if (lpkRow.ClientFromEid == row.ClientFromId)
            cmbFrom.SelectedIndex = cmbFrom.Items.Count - 1;
        }
      }
      if (cmbFrom.SelectedItem == null)      // Protoze je potreba i osetrit moznost NULL (není vybrán žádný sex - třeba u Omylu, nebo prozvonění)
        cmbFrom.SelectedIndex = 0;

      cmbAge.Items.Clear();
      cmbAge.Items.Add(new ComboItem("<Nevybráno>", ""));
      if (isNewForm)
      {
        foreach (var row in age)
        {
          if (row.DtDeleted == null)
            cmbAge.Items.Add(new ComboItem(row.Text, row.AgeId.ToString()));
        }
        cmbAge.SelectedIndex = 0;
      }
      else
      {
        foreach (var row in age)
        {
          if (row.DtDeleted == null || lpkRow.AgeEid == row.AgeId)
            cmbAge.Items.Add(new ComboItem(row.Text, row.AgeId.ToString()));
          if (lpkRow.AgeEid == row.AgeId)
            cmbAge.SelectedIndex = cmbAge.Items.Count - 1;

        }
      }
      if (cmbAge.SelectedItem == null)      // Protoze je potreba i osetrit moznost NULL (není vybrán žádný sex - třeba u Omylu, nebo prozvonění)
        cmbAge.SelectedIndex = 0;


      this.tvClientCurrentStatus.Nodes.Clear();
      foreach (var cssItem in clientCurrentStatus)
      {
        TreeNode mainNode = new TreeNode();
        mainNode.Name = cssItem.ClientCurrentStatusId.ToString();
        mainNode.Text = cssItem.Text;
        foreach (var subCssItem in subClientCurrentStatus.Where(x => x.ClientCurrentStatusId == cssItem.ClientCurrentStatusId).OrderBy(x => x.SubClientCurrentStatusId))
        {
          TreeNode Node2 = new TreeNode();
          Node2.Name = subCssItem.SubClientCurrentStatusId.ToString();
          Node2.Text = subCssItem.Text;
          mainNode.Nodes.Add(Node2);
        }
        this.tvClientCurrentStatus.Nodes.Add(mainNode);

      }
      this.tvClientCurrentStatus.CheckBoxes = true;
      this.tvClientCurrentStatus.DrawMode = TreeViewDrawMode.OwnerDrawAll;

      this.tvContactTopic.Nodes.Clear();
      foreach (var cssItem in contactTopic.Where(x => x.DtDeleted == null || !isNewForm).ToList())
      {
        TreeNode mainNode = new TreeNode();
        mainNode.Name = cssItem.ContactTopicId.ToString();
        mainNode.Text = cssItem.Text;
        foreach (var subCssItem in subContactTopic.Where(x => x.ContactTopicId == cssItem.ContactTopicId && (x.DtDeleted == null || !isNewForm)).OrderBy(x => x.SubContactTopicId))
        {
          TreeNode Node2 = new TreeNode();
          Node2.Name = subCssItem.SubContactTopicId.ToString();
          Node2.Text = subCssItem.Text;
          mainNode.Nodes.Add(Node2);
        }
        this.tvContactTopic.Nodes.Add(mainNode);
      }
      this.tvContactTopic.CheckBoxes = true;
      this.tvContactTopic.DrawMode = TreeViewDrawMode.OwnerDrawAll;


      this.tvEndOfSpeech.Nodes.Clear();
      foreach (var Item in endOfSpeech.Where(x => x.DtDeleted == null || !isNewForm).ToList())
      {
        TreeNode mainNode = new TreeNode();
        mainNode.Name = Item.EndOfSpeechId.ToString();
        mainNode.Text = Item.Text;
        foreach (var subItem in subEndOfSpeech.Where(x => x.EndOfSpeechId == Item.EndOfSpeechId && (x.DtDeleted == null || !isNewForm)).OrderBy(x => x.SubEndOfSpeechId))
        {
          TreeNode Node2 = new TreeNode();
          Node2.Name = subItem.SubEndOfSpeechId.ToString();
          Node2.Text = subItem.Text;
          mainNode.Nodes.Add(Node2);
        }
        this.tvEndOfSpeech.Nodes.Add(mainNode);
      }
      this.tvEndOfSpeech.CheckBoxes = true;
      this.tvEndOfSpeech.DrawMode = TreeViewDrawMode.OwnerDrawAll;

      if (isNewForm == false)
      {
        endOfSpeech_Selected = DB.GetLPKEndOfSpeech(LPKId);
        clientCurrentStatus_Selected = DB.GetLPKClientCurrentStatus(LPKId);
        contactTopic_Selected = DB.GetLPKContactTopic(LPKId);
        SetActiveNodeId(tvEndOfSpeech, endOfSpeech_Selected);
        SetActiveNodeId(tvClientCurrentStatus, clientCurrentStatus_Selected);
        SetActiveNodeId(tvContactTopic, contactTopic_Selected);
        btnWrite.Text = "Upravit";
        btnWrite.Enabled = false;
      }
      else
      {
        StartTimer(); 
      }

      txtVolajici.AutoCompleteCustomSource.AddRange(DB.GetNick().Select(x => x.Text).ToArray());
      ReWriteScreen();

    }
    private void ReWriteScreen()
    {
      boxCall.Top = 40; btnWrite.Top = 70;
      boxCall.Left = boxClient.Left = boxResult.Left = 3;
      boxClient.Top = boxCall.Top + boxCall.Height + 5;
      boxResult.Top = boxClient.Top + boxClient.Height + 5;

    }

    private void tvCurrentClientStatus_DrawNode(object sender, DrawTreeNodeEventArgs e)
    {
      ShowNode(sender, e);
    }

    private void tvContactTopic_DrawNode(object sender, DrawTreeNodeEventArgs e)
    {
      ShowNode(sender, e);
    }

    private void tvEndOfSpeech_DrawNode(object sender, DrawTreeNodeEventArgs e)
    {
      ShowNode(sender, e);
    }

    private void ShowNode(object sender, DrawTreeNodeEventArgs e)
    {
      TreeView aktView = ((TreeView)sender);
      if (e.Node.Parent == null)
      {
        int d = (int)(0.2 * e.Bounds.Height);
        Rectangle rect = new Rectangle(d + aktView.Margin.Left, d + e.Bounds.Top, e.Bounds.Height - d * 2, e.Bounds.Height - d * 2);
        e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rect);
        e.Graphics.DrawRectangle(Pens.Silver, rect);
        StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
        e.Graphics.DrawString(e.Node.IsExpanded ? "-" : "+", aktView.Font, new SolidBrush(Color.Blue), rect, sf);
        //Draw the dotted line connecting the expanding/collapsing button and the node Text
        using (Pen dotted = new Pen(Color.Black) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
        {
          e.Graphics.DrawLine(dotted, new Point(rect.Right + 1, rect.Top + rect.Height / 2), new Point(rect.Right + 4, rect.Top + rect.Height / 2));
        }
        //Draw text
        sf.Alignment = StringAlignment.Near;
        Rectangle textRect = new Rectangle(e.Bounds.Left + rect.Right + 4, e.Bounds.Top, e.Bounds.Width - rect.Right - 4, e.Bounds.Height);
        if (e.Node.IsSelected)
        {
          SizeF textSize = e.Graphics.MeasureString(e.Node.Text, aktView.Font);
          e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(textRect.Left, textRect.Top, textSize.Width, textRect.Height));
        }
        e.Graphics.DrawString(e.Node.Text, aktView.Font, new SolidBrush(aktView.ForeColor), textRect, sf);
      }
      else e.DrawDefault = true;


    }


    private void tvContactTopic_AfterCheck(object sender, TreeViewEventArgs e)
    {
      List<int> activeNodeId = GetActiveNodeId((TreeView)sender);
      lblContactTopic.Text = string.Join(" ,", subContactTopic.Where(p => activeNodeId.Contains(p.SubContactTopicId)).Select(p => p.Text.ToString()));
    }

    private void tvCurrentClientStatus_AfterCheck(object sender, TreeViewEventArgs e)
    {
      List<int> activeNodeId = GetActiveNodeId((TreeView)sender);
      lblCurrentClientStatus.Text = string.Join(", ", subClientCurrentStatus.Where(p => activeNodeId.Contains(p.SubClientCurrentStatusId)).Select(p => p.Text.ToString()));
    }
    private void tvEndOfSpeech_AfterCheck(object sender, TreeViewEventArgs e)
    {
      List<int> activeNodeId = GetActiveNodeId((TreeView)sender);
      lblEndOfSpeech.Text = string.Join(", ", subEndOfSpeech.Where(p => activeNodeId.Contains(p.SubEndOfSpeechId)).Select(p => p.Text.ToString()));
    }

    private List<int> GetActiveNodeId(TreeView AnyLV)
    {
      List<int> EditedListID = new List<int>();
      foreach (TreeNode nL1 in AnyLV.Nodes)
      {
        foreach (TreeNode nL2 in nL1.Nodes)
        {
          if (nL2.Checked)
          {
            EditedListID.Add(int.Parse(nL2.Name));
          }
        }
      }
      return EditedListID;
    }
    private void SetActiveNodeId(TreeView AnyTV, List<int> EditedListID)
    {
      List<string> sEditedListID = EditedListID.Select(x => x.ToString()).ToList();
      foreach (TreeNode nL1 in AnyTV.Nodes)
      {
        foreach (TreeNode nL2 in nL1.Nodes)
        {
          nL2.Checked = sEditedListID.Contains(nL2.Name);
          if (nL2.Checked)
            nL1.Expand();
        }
      }
    }


    private void SpoctiDobu()
    {
      TimeSpan x = tmCallTo.Value - tmCall.Value;
      lblCallTimeSum.Text = ((int)x.TotalHours).ToString("D2") + ":" + x.Minutes.ToString("D2") + ":" + x.Seconds.ToString("D2");
    }

    private void tmCall_ValueChanged(object sender, EventArgs e)
    {
      SpoctiDobu();
    }

    private void tmCallTo_ValueChanged(object sender, EventArgs e)
    {
      SpoctiDobu();
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

    private void cmbContactType_Validating(object sender, CancelEventArgs e)
    {
      if (cmbContactType.SelectedIndex == 0 && isNewForm)
      {
        cmbContactTypeErrorProvider.SetError(this.cmbContactType, "Typ kontaktu musí být vyplněn");
        e.Cancel = true;
      }
      else
      {
        cmbContactTypeErrorProvider.SetError(this.cmbContactType, "");
        e.Cancel = false;
      }

    }

    private void cmbTypeService_Validating(object sender, CancelEventArgs e)
    {
      if (cmbTypeService.SelectedIndex == 0 && isNewForm)
      {
        cmbTypeServiceErrorProvider.SetError(this.cmbTypeService, "Typ služby musí být vyplněn");
        e.Cancel = true;
      }
      else
      {
        cmbTypeServiceErrorProvider.SetError(this.cmbTypeService, "");
        e.Cancel = false;
      }
    }

    private void cmbFrom_Validating(object sender, CancelEventArgs e)
    {
      if (cmbFrom.SelectedIndex == 0 && isHovor)
      {
        cmbFromErrorProvider.SetError(this.cmbFrom, "Odkud je klient musí být vyplněn");
        e.Cancel = true;
      }
      else
      {
        cmbFromErrorProvider.SetError(this.cmbFrom, "");
        e.Cancel = false;
      }

    }

    private void cmbSex_Validating(object sender, CancelEventArgs e)
    {
      if (cmbSex.SelectedIndex == 0 &&  isHovor)
      {
        cmbSexErrorProvider.SetError(this.cmbSex, "Pohlaví musí být vyplněn");
        e.Cancel = true;
      }
      else
      {
        cmbSexErrorProvider.SetError(this.cmbSex, "");
        e.Cancel = false;
      }
    }

    private void cmbAge_Validating(object sender, CancelEventArgs e)
    {
      if (cmbAge.SelectedIndex == 0 && isHovor)
      {
        cmbAgeErrorProvider.SetError(this.cmbAge, "Věk musí být vyplněn");
        e.Cancel = true;
      }
      else
      {
        cmbAgeErrorProvider.SetError(this.cmbAge, "");
        e.Cancel = false;
      }

    }

    private void tvContactTopic_Validating(object sender, CancelEventArgs e)
    {
      List<int> activeNodeId = GetActiveNodeId(tvContactTopic);
      if (activeNodeId.Count() == 0 && isHovor)
      {
        tvContactTopicErrorProvider.SetError(this.tvContactTopic, "Téma kontaktu - alespoň jedna možnost musí být zaškrtnuta");
        e.Cancel = true;
      }
      else
      {
        tvContactTopicErrorProvider.SetError(this.tvContactTopic, "");
        e.Cancel = false;
      }

    }

    private void tvCurrentClientStatus_Validating(object sender, CancelEventArgs e)
    {
      List<int> activeNodeId = GetActiveNodeId(tvClientCurrentStatus);
      if (activeNodeId.Count() == 0 && isHovor)
      {
        tvCurrentClientStatusErrorProvider.SetError(this.tvClientCurrentStatus, "Aktuální stav klienta - alespoň jedna možnost musí být zaškrtnuta");
        e.Cancel = true;
      }
      else
      {
        tvCurrentClientStatusErrorProvider.SetError(this.tvClientCurrentStatus, "");
        e.Cancel = false;
      }

    }

    private void tvEndOfSpeech_Validating(object sender, CancelEventArgs e)
    {
      List<int> activeNodeId = GetActiveNodeId(tvEndOfSpeech);
      if (activeNodeId.Count() == 0 && isHovor)
      {
        tvEndOfSpeechErrorProvider.SetError(this.tvEndOfSpeech, "Závěr hovoru - alespoň jedna možnost musí být zaškrtnuta");
        e.Cancel = true;
      }
      else
      {
        tvEndOfSpeechErrorProvider.SetError(this.tvEndOfSpeech, "");
        e.Cancel = false;
      }

    }

    #endregion

    private void btnWrite_Click(object sender, EventArgs e)
    {
      if (ValidateChildren())
      {
        StopTimer();
        if (DialogResult.Yes == MessageBox.Show("Opravdu zapsat tento hovor?", "LPK Nové volání", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
          if (isNewForm)
          {
            WriteThisNewCall();
          }
          else
            UpdateThisNewCall();
      }
      else
      {
        MessageBox.Show("Validation failed.", "LPK - Nové volání", MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
      return;
    }

    private void UpdateThisNewCall()
    {
      DateTime datetimeStartCall = dtCall.Value.Date.Add(TimeSpan.Parse(tmCall.Value.ToShortTimeString()));
      DateTime datetimeEndCall = dtCall.Value.Date.Add(TimeSpan.Parse(tmCallTo.Value.ToShortTimeString()));
      if (datetimeStartCall != aktCall.DtStartCall || datetimeEndCall != aktCall.DtEndCall)
      {
        DB.UpdateCall(aktCall.CallId, datetimeStartCall, datetimeEndCall);
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CallTable, aktCall.DtStartCall.ToString() + " -> " + datetimeStartCall.ToString() + "  " + aktCall.DtEndCall.ToString() + " -> " + datetimeEndCall.ToString(), aktCall.CallId.ToString(), Program.myLoggedUser.LoginUserId);
        aktCall = DB.GetCall(aktCall.CallId);
      }
      if (((ComboItem)cmbSex.SelectedItem).iValue != lpkRow.SexEid)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2LPvKTable, "Pohlaví", ((ComboItem)cmbSex.SelectedItem).Text + " -> " + sex.Where(x => x.SexId == lpkRow.SexEid).Select(x => x.Text), Program.myLoggedUser.LoginUserId);
        lpkRow.SexEid = ((ComboItem)cmbSex.SelectedItem).iValue == 0 ? null : ((ComboItem)cmbSex.SelectedItem).iValue;

      }
      if (((ComboItem)cmbAge.SelectedItem).iValue != lpkRow.AgeEid )
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2LPvKTable, "Věk", ((ComboItem)cmbAge.SelectedItem).Text + " -> " + age.Where(x => x.AgeId == lpkRow.AgeEid).Select(x => x.Text), Program.myLoggedUser.LoginUserId);
        lpkRow.AgeEid = ((ComboItem)cmbAge.SelectedItem).iValue == 0 ? null : ((ComboItem)cmbAge.SelectedItem).iValue;
      }
      if (((ComboItem)cmbFrom.SelectedItem).iValue != lpkRow.ClientFromEid)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2LPvKTable, "Odkud je klient", ((ComboItem)cmbFrom.SelectedItem).Text + " -> " + clientFrom.Where(x => x.ClientFromId == lpkRow.ClientFromEid).Select(x => x.Text), Program.myLoggedUser.LoginUserId);
        lpkRow.ClientFromEid = ((ComboItem)cmbFrom.SelectedItem).iValue == 0 ? null : ((ComboItem)cmbFrom.SelectedItem).iValue;
      }
      if (((ComboItem)cmbContactType.SelectedItem).iValue != lpkRow.ContactTypeEid)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2LPvKTable, "Typ klienta", ((ComboItem)cmbContactType.SelectedItem).Text + " -> " + contactType.Where(x => x.ContactTypeId == lpkRow.ContactTypeEid).Select(x => x.Text), Program.myLoggedUser.LoginUserId);
        lpkRow.ContactTypeEid = ((ComboItem)cmbContactType.SelectedItem).iValue;
      }
      if (((ComboItem)cmbTypeService.SelectedItem).iValue != lpkRow.TypeServiceEid)
      {
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2LPvKTable, "Typ služby", ((ComboItem)cmbTypeService.SelectedItem).Text + " -> " + typeService.Where(x => x.TypeServiceId == lpkRow.TypeServiceEid).Select(x => x.Text), Program.myLoggedUser.LoginUserId);
        lpkRow.TypeServiceEid = ((ComboItem)cmbTypeService.SelectedItem).iValue;
      }

      List<int> contactTopic_New = GetActiveNodeId(tvContactTopic);
      if (!contactTopic_Selected.SequenceEqual(contactTopic_New))
      {
        DB.SetLPKContactTopic(lpkRow.Lpkid, contactTopic_New);
        contactTopic_Selected = DB.GetLPKContactTopic(LPKId);
      }
      List<int> clientCurrentStatus_New = GetActiveNodeId(tvClientCurrentStatus);
      if (!clientCurrentStatus_Selected.SequenceEqual(clientCurrentStatus_New))
      {
        DB.SetLPKClientCurrentStatus(lpkRow.Lpkid, clientCurrentStatus_New);
        clientCurrentStatus_Selected = DB.GetLPKClientCurrentStatus(LPKId);
      }
      List<int> endOfSpeech_New = GetActiveNodeId(tvEndOfSpeech);
      if (!endOfSpeech_Selected.SequenceEqual(endOfSpeech_New))
      {
        DB.SetLPKEndOfSpeech(lpkRow.Lpkid, endOfSpeech_New);
        endOfSpeech_Selected = DB.GetLPKEndOfSpeech(LPKId);
      }
      lpkRow.Note = txtNote.Text;
      lpkRow.Nick = txtVolajici.Text;
      DB.UpdateLPK(lpkRow);
      btnWrite.Enabled = false;
    }

    private void WriteThisNewCall()
    {
      DateTime datetimeStartCall = dtCall.Value.Date.Add(TimeSpan.Parse(tmCall.Value.ToLongTimeString()));
      DateTime datetimeEndCall = dtCall.Value.Date.Add(TimeSpan.Parse(tmCallTo.Value.ToLongTimeString()));
      int CallId = DB.WriteCall(datetimeStartCall, (int)eCallType.ePLK, datetimeEndCall);
      if (CallId > 0)
      {
        Lpk row = new Lpk();
        row.CallId = CallId;
        row.AgeEid = ((ComboItem)cmbAge.SelectedItem).iValue == 0 ? null: ((ComboItem)cmbAge.SelectedItem).iValue;
        row.SexEid = ((ComboItem)cmbSex.SelectedItem).iValue == 0? null : ((ComboItem)cmbSex.SelectedItem).iValue;
        row.ClientFromEid = ((ComboItem)cmbFrom.SelectedItem).iValue == 0 ? null : ((ComboItem)cmbFrom.SelectedItem).iValue; 
        row.ContactTypeEid = ((ComboItem)cmbContactType.SelectedItem).iValue; 
        row.TypeServiceEid = ((ComboItem)cmbTypeService.SelectedItem).iValue;
        row.Note = txtNote.Text;
        row.Nick = txtVolajici.Text;
        row.CallId = CallId;
        int aktLPKId = DB.WriteRowLPK(row);
        List<int> contactTopicIdList = GetActiveNodeId(tvContactTopic);
        DB.SetLPKContactTopic(aktLPKId, contactTopicIdList);
        List<int> currentClientStatusIdList = GetActiveNodeId(tvClientCurrentStatus);
        DB.SetLPKClientCurrentStatus(aktLPKId, currentClientStatusIdList);
        List<int> endOfSpeechIdList = GetActiveNodeId(tvEndOfSpeech);
        DB.SetLPKEndOfSpeech(aktLPKId, endOfSpeechIdList);
        if (txtVolajici.Text.Length > 0)
        {
          if (!txtVolajici.AutoCompleteCustomSource.Contains(txtVolajici.Text))
          {
            DB.AddNick(txtVolajici.Text);
          }
        }
        PrepareScreen();
        StopTimer();      // Zu se mi to nechce resit - 
      }
    }

    private void ucCallLPK_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible == false)
      {
        this.CausesValidation = false;
        StopTimer();
      }
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
      ShowDetailUserControl?.Invoke(-1, 0);
    }
    private void Any_ValueChanged(object sender, EventArgs e)
    {
      changedAnyValue = true;
    }

    private void ucCallLPK_Resize(object sender, EventArgs e)
    {
      boxResult.Height = Math.Max(this.Height - (boxResult.Top + 20), 300);
      lblContactTopic1.Top = lblContactTopic.Top = boxResult.Height - 60;
      lblCurrentClientStatus1.Top = lblCurrentClientStatus.Top = boxResult.Height - 40;
      lblEndOfSpeech1.Top = lblEndOfSpeech.Top = boxResult.Height - 20;
      this.tvEndOfSpeech.Height = this.tvContactTopic.Height = this.tvClientCurrentStatus.Height = (boxResult.Height - 100);
      this.txtNote.Height = this.tvEndOfSpeech.Height + 100;

    }

    private void btnQuickLPvK_Click(object sender, EventArgs e)
    {
      ShowDetailUserControl?.Invoke(-99, 2);
    }

    private void pictureClock_Click(object sender, EventArgs e)
    {
      if (!isNewForm)
        return;
      if (timer1.Enabled)
      {
        StopTimer();
      }
      else
      {
        StartTimer();
      }
    }


    private void StopTimer()
    {
      timer1.Enabled = false;
      pictureClock.Image = Image.FromFile("Resources/ClockGray.png");
    }
    private void StartTimer()
    {
      tmCallTo.Value = DateTime.Now;
      timer1.Enabled = true;
      pictureClock.Image = Image.FromFile("Resources/ClockWhite.png");
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
      tmCallTo.Value = tmCallTo.Value.AddSeconds(1);
      SpoctiDobu();
    }


  }
}
