using EvitelLib2;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using NPOI.SS.Formula.Functions;
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
  public partial class ucCallLPK : UserControl
  {
    public bool isNewForm;
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
      tvCurrentClientStatusErrorProvider = InitializeErrorProvider(1, tvCurrentClientStatus);
      tvEndOfSpeechErrorProvider = InitializeErrorProvider(1, tvEndOfSpeech);

    }
  
    public void PrepareScreen()
    {
      cmbContactType.Items.Clear();
      if (isNewForm)
      {
        cmbSex.Items.Add(new ComboItem("<Nevybráno>", ""));
        foreach (var row in sex)
        {
          if (row.DtDeleted == null)
            cmbSex.Items.Add(new ComboItem(row.Text, row.SexId.ToString()));
        }
        cmbSex.SelectedIndex = 0;
      }
      else { }

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
      else { }
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
      else { }

      cmbFrom.Items.Clear();
      if (isNewForm)
      {
        cmbFrom.Items.Add(new ComboItem("<Nevybráno>", ""));
        foreach (var row in clientFrom)
        {
          if (row.DtDeleted == null)
            cmbFrom.Items.Add(new ComboItem(row.Text, row.ClientFromId.ToString()));
        }
        cmbFrom.SelectedIndex = 0;
      }
      else { }

      cmbAge.Items.Clear();
      if (isNewForm)
      {
        cmbAge.Items.Add(new ComboItem("<Nevybráno>", ""));
        foreach (var row in age)
        {
          if (row.DtDeleted == null)
            cmbAge.Items.Add(new ComboItem(row.Text, row.AgeId.ToString()));
        }
        cmbAge.SelectedIndex = 0;
      }
      else { }

      this.tvCurrentClientStatus.Nodes.Clear();
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
        this.tvCurrentClientStatus.Nodes.Add(mainNode);

      }
      this.tvCurrentClientStatus.CheckBoxes = true;
      this.tvCurrentClientStatus.DrawMode = TreeViewDrawMode.OwnerDrawAll;

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
      }
      else
      {

      }

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

    private List<int> GetActiveNodeId(TreeView sender)
    {
      List<int> EditedListID = new List<int>();
      foreach (TreeNode n in sender.Nodes)
      {
        foreach (TreeNode n2 in n.Nodes)
        {
          if (n2.Checked)
          {
            EditedListID.Add(int.Parse(n2.Name));
          }
        }
      }
      return EditedListID;
    }



    private void SpoctiDobu()
    {
      DateTime datetimeStart = DateTime.Now.Date.Add(TimeSpan.Parse(tmCall.Value.ToShortTimeString()));
      DateTime datetimeEnd = DateTime.Now.Date.Add(TimeSpan.Parse(tmCallTo.Value.ToShortTimeString()));
      TimeSpan s = datetimeEnd - datetimeStart;
      lblCallTimeSum.Text = ((int)s.TotalHours).ToString("D2") + ":" + s.Minutes.ToString("D2");
    }

    private void tmCall_ValueChanged(object sender, EventArgs e)
    {
      SpoctiDobu();
    }

    private void tmCallTo_ValueChanged(object sender, EventArgs e)
    {
      SpoctiDobu();
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
      if (cmbFrom.SelectedIndex == 0 && isNewForm)
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
      if (cmbSex.SelectedIndex == 0 && isNewForm)
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
      if (cmbAge.SelectedIndex == 0 && isNewForm)
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
      if (activeNodeId.Count() == 0)
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
      List<int> activeNodeId = GetActiveNodeId(tvCurrentClientStatus);
      if (activeNodeId.Count() == 0)
      {
        tvCurrentClientStatusErrorProvider.SetError(this.tvCurrentClientStatus, "Aktuální stav klienta - alespoň jedna možnost musí být zaškrtnuta");
        e.Cancel = true;
      }
      else
      {
        tvCurrentClientStatusErrorProvider.SetError(this.tvCurrentClientStatus, "");
        e.Cancel = false;
      }

    }

    private void tvEndOfSpeech_Validating(object sender, CancelEventArgs e)
    {
      List<int> activeNodeId = GetActiveNodeId(tvEndOfSpeech);
      if (activeNodeId.Count() == 0)
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

    private void btnWrite_Click(object sender, EventArgs e)
    {
      if (ValidateChildren())
      {
        if (DialogResult.Yes == MessageBox.Show("Opravdu zapsat tento hovor?", "LPK hovor", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
          if (isNewForm)
            WriteThisNewCall();
          else
            UpdateThisNewCall();
      }
      else
      {
        MessageBox.Show("Validation failed.");
      }
      return;
    }

    private void UpdateThisNewCall()
    {
      throw new NotImplementedException();
    }

    private void WriteThisNewCall()
    {
      DateTime datetimeStartCall = dtCall.Value.Date.Add(TimeSpan.Parse(tmCall.Value.ToShortTimeString()));
      DateTime datetimeEndCall = dtCall.Value.Date.Add(TimeSpan.Parse(tmCallTo.Value.ToShortTimeString()));
      int CallId = DB.WriteCall(datetimeStartCall, (int)eCallType.ePLK, datetimeEndCall);
      if (CallId > 0)
      {
        Lpk row = new Lpk();
        row.CallId = CallId;
        row.AgeEid = ((ComboItem)cmbAge.SelectedItem).iValue;
        row.SexEid = ((ComboItem)cmbSex.SelectedItem).iValue;
        row.ClientFromEid = ((ComboItem)cmbFrom.SelectedItem).iValue;
        row.ContactTypeEid = ((ComboItem)cmbContactType.SelectedItem).iValue;
        row.TypeServiceEid = ((ComboItem)cmbTypeService.SelectedItem).iValue;
        row.Note = txtNote.Text;
        row.Nick = txtVolajici.Text;
        row.CallId = CallId;
        int aktLPKId = DB.WriteRowLPK(row);
        List<int> contactTopicIdList = GetActiveNodeId(tvContactTopic);
        DB.SetLPKContactTopic(aktLPKId, contactTopicIdList);
        List<int> currentClientStatusIdList = GetActiveNodeId(tvCurrentClientStatus);
        DB.SetLPKClientCurrentStatus(aktLPKId, currentClientStatusIdList);
        List<int> endOfSpeechIdList = GetActiveNodeId(tvEndOfSpeech);
        DB.SetLPKEndOfSpeech(aktLPKId, endOfSpeechIdList);
        PrepareScreen();
      }
    }

  }
}
