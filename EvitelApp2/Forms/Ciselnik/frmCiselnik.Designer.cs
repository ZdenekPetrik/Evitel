namespace EvitelApp2.Forms1.Ciselnik
{
  partial class frmCiselnik
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.lblId = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.btnCokoliv = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.txtText2 = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txtText3 = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(64, 55);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(22, 20);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(64, 104);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(36, 20);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Text";
            // 
            // btnCokoliv
            // 
            this.btnCokoliv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCokoliv.Location = new System.Drawing.Point(217, 195);
            this.btnCokoliv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCokoliv.Name = "btnCokoliv";
            this.btnCokoliv.Size = new System.Drawing.Size(120, 31);
            this.btnCokoliv.TabIndex = 2;
            this.btnCokoliv.Text = "button1";
            this.btnCokoliv.UseVisualStyleBackColor = true;
            this.btnCokoliv.Click += new System.EventHandler(this.btnCokoliv_Click);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtID.Location = new System.Drawing.Point(217, 53);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(114, 29);
            this.txtID.TabIndex = 3;
            // 
            // txtText
            // 
            this.txtText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtText.Location = new System.Drawing.Point(217, 100);
            this.txtText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(330, 29);
            this.txtText.TabIndex = 4;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // txtText2
            // 
            this.txtText2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtText2.Location = new System.Drawing.Point(217, 146);
            this.txtText2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtText2.Name = "txtText2";
            this.txtText2.Size = new System.Drawing.Size(330, 29);
            this.txtText2.TabIndex = 6;
            this.txtText2.Visible = false;
            this.txtText2.TextChanged += new System.EventHandler(this.txtText2_TextChanged);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(64, 150);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(50, 20);
            this.lbl2.TabIndex = 5;
            this.lbl2.Text = "label2";
            this.lbl2.Visible = false;
            // 
            // txtText3
            // 
            this.txtText3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtText3.Location = new System.Drawing.Point(217, 192);
            this.txtText3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtText3.Name = "txtText3";
            this.txtText3.Size = new System.Drawing.Size(330, 29);
            this.txtText3.TabIndex = 8;
            this.txtText3.Visible = false;
            this.txtText3.TextChanged += new System.EventHandler(this.txtText3_TextChanged);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(64, 196);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(50, 20);
            this.lbl3.TabIndex = 7;
            this.lbl3.Text = "label3";
            this.lbl3.Visible = false;
            // 
            // frmCiselnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 261);
            this.Controls.Add(this.txtText3);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtText2);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnCokoliv);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblId);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCiselnik";
            this.Load += new System.EventHandler(this.frmUniversal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblId;
    private System.Windows.Forms.Label lblText;
    private System.Windows.Forms.Button btnCokoliv;
    private System.Windows.Forms.TextBox txtID;
    private System.Windows.Forms.TextBox txtText;
    private System.Windows.Forms.TextBox txtText2;
    private System.Windows.Forms.Label lbl2;
    private System.Windows.Forms.TextBox txtText3;
    private System.Windows.Forms.Label lbl3;
  }
}