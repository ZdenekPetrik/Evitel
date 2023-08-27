namespace EvitelApp2.Controls
{
  partial class ctrlCall
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      dgw = new Zuby.ADGV.AdvancedDataGridView();
      ((System.ComponentModel.ISupportInitialize)dgw).BeginInit();
      SuspendLayout();
      // 
      // dgw
      // 
      dgw.AllowUserToAddRows = false;
      dgw.AllowUserToDeleteRows = false;
      dgw.AllowUserToOrderColumns = true;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      dgw.DefaultCellStyle = dataGridViewCellStyle2;
      dgw.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      dgw.FilterAndSortEnabled = true;
      dgw.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
      dgw.Location = new System.Drawing.Point(3, 3);
      dgw.Name = "dgw";
      dgw.RightToLeft = System.Windows.Forms.RightToLeft.No;
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
      dgw.RowTemplate.Height = 25;
      dgw.Size = new System.Drawing.Size(240, 150);
      dgw.SortStringChangedInvokeBeforeDatasourceUpdate = true;
      dgw.TabIndex = 3;
      dgw.CellMouseEnter += dgw_CellMouseEnter;
      dgw.RowEnter += dgw_RowEnter;
      dgw.DoubleClick += dgw_DoubleClick;
      // 
      // ctrlCall
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      Controls.Add(dgw);
      Name = "ctrlCall";
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
