using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvitelApp2.Forms1
{
  public partial class frmGraph : Form
  {
    public frmGraph()
    {
      InitializeComponent();
    }

    private void frmGraph_Load(object sender, EventArgs e)
    {
      //double[] dataX = new double[] { 1, 2, 3, 4, 5 };
      double[] dataX = new double[] { 8,9,10,11,12 };
      double[] dataY = new double[] { 1, 4, 9, 16, 25 };
      formsPlot1.Plot.AddScatter(dataX, dataY);
      formsPlot1.Refresh();

    }
  }
}
