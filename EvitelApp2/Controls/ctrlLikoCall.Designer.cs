namespace EvitelApp2.Controls
{
  partial class ctrlLikoCall
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      dgw = new Zuby.ADGV.AdvancedDataGridView();
      ((System.ComponentModel.ISupportInitialize)dgw).BeginInit();
      SuspendLayout();
      // 
      // dgw
      // 
      dgw.AllowUserToAddRows = false;
      dgw.AllowUserToDeleteRows = false;
      dgw.AllowUserToOrderColumns = true;
      dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgw.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      dgw.FilterAndSortEnabled = true;
      dgw.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
      dgw.Location = new System.Drawing.Point(3, 3);
      dgw.Name = "dgw";
      dgw.RightToLeft = System.Windows.Forms.RightToLeft.No;
      dgw.RowTemplate.Height = 25;
      dgw.Size = new System.Drawing.Size(240, 150);
      dgw.SortStringChangedInvokeBeforeDatasourceUpdate = true;
      dgw.TabIndex = 3;
      dgw.FilterStringChanged += dgw_FilterStringChanged;
      dgw.CellContentClick += dgw_CellContentClick;
      dgw.CellMouseEnter += dgw_CellMouseEnter;
      dgw.RowEnter += dgw_RowEnter;
      dgw.DoubleClick += dgw_DoubleClick;
      // 
      // ctrlLikoCall
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      Controls.Add(dgw);
      Name = "ctrlLikoCall";
      Size = new System.Drawing.Size(259, 168);
      Load += ctrlLikoCall_Load;
      Resize += ctrlLikoCall_Resize;
      ((System.ComponentModel.ISupportInitialize)dgw).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Zuby.ADGV.AdvancedDataGridView dgw;
  }
}
