namespace EvitelApp2.Controls
{
  partial class ctrlParticipant
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
            this.dgw = new Zuby.ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw
            // 
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.FilterAndSortEnabled = true;
            this.dgw.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgw.Location = new System.Drawing.Point(3, 3);
            this.dgw.Name = "dgw";
            this.dgw.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgw.RowTemplate.Height = 25;
            this.dgw.Size = new System.Drawing.Size(240, 150);
            this.dgw.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgw.TabIndex = 3;
            // 
            // ctrlParticipant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgw);
            this.Name = "ctrlParticipant";
            this.Size = new System.Drawing.Size(259, 168);
            this.Load += new System.EventHandler(this.ctrlParticipation_Load);
            this.Resize += new System.EventHandler(this.ctrlParticipant_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private Zuby.ADGV.AdvancedDataGridView dgw;
  }
}
