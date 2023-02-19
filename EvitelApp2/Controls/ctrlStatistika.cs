using EvitelApp2.Helper;
using EvitelApp2.MyUserControl;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static EvitelApp2.Controls.frmTestEndNPOI;
using static EvitelApp2.frmMain;

namespace EvitelApp2.Controls
{
  public partial class ctrlStatistika : UserControl, IctrlWithDGW
  {
    private CRepositoryDB DB;
    private DataTable _dataTable;
    private DataSet _dataSet;
    BindingSource bindingSource1;
    public event RowInformation ShowRowInformation;
    public event DetailIntervence ShowDetailUserControl;
    public DataTable dataTable
    {
      get
      {
        DataView dv = new DataView(_dataTable);
        dv.RowFilter = dgw.FilterString;
        dv.Sort = dgw.SortString;
        return dv.ToTable();
      }
      set { _dataTable = value;
        _dataSet = new DataSet();
        bindingSource1 = new BindingSource();
        bindingSource1.DataSource = _dataSet;
        dgw.SetDoubleBuffered();
        dgw.DataSource = bindingSource1;
        _dataSet.Tables.Add(_dataTable);
        bindingSource1.DataMember = _dataTable.TableName;
      }
    }
    

    public ctrlStatistika()
    {
      InitializeComponent();
    }

    private void ctrlLikoCall_Load(object sender, EventArgs e)
    {
      if (DesignMode == false)
      {
        DB = new CRepositoryDB(Program.myLoggedUser.LoginUserId);
        MyResize();
      }
    }
    public void MyResize()
    {
      dgw.Top = dgw.Left = 0;
      dgw.Width = this.ClientSize.Width - 5;
      dgw.Height = this.ClientSize.Height;
    }

    private void ctrlLikoCall_Resize(object sender, EventArgs e)
    {
      MyResize();
    }

    public void SetColumns()
    {
      throw new NotImplementedException();
    }

    public void InitColumns()
    {
      throw new NotImplementedException();
    }

    public void RemoveOrders()
    {
      throw new NotImplementedException();
    }

    public void RemoveFilters()
    {
      throw new NotImplementedException();
    }
  }
}
