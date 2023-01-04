namespace EvitelApp2.Controls
{
  partial class ucParticipations
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucParticipations));
      this.dgw = new System.Windows.Forms.DataGridView();
      this.btnAddParticipant = new System.Windows.Forms.Button();
      this.btnEditParticipant = new System.Windows.Forms.Button();
      this.btnDeleteParticipant = new System.Windows.Forms.Button();
      this.btnUpParticipant = new System.Windows.Forms.Button();
      this.btnDownParticipant = new System.Windows.Forms.Button();
      this.gb_Participation = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
      this.gb_Participation.SuspendLayout();
      this.SuspendLayout();
      // 
      // dgw
      // 
      this.dgw.AllowUserToAddRows = false;
      this.dgw.AllowUserToDeleteRows = false;
      this.dgw.AllowUserToOrderColumns = true;
      this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgw.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.dgw.Location = new System.Drawing.Point(104, 22);
      this.dgw.Name = "dgw";
      this.dgw.RowTemplate.Height = 25;
      this.dgw.Size = new System.Drawing.Size(1043, 274);
      this.dgw.TabIndex = 26;
      this.dgw.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellContentClick);
      // 
      // btnAddParticipant
      // 
      this.btnAddParticipant.Image = ((System.Drawing.Image)(resources.GetObject("btnAddParticipant.Image")));
      this.btnAddParticipant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnAddParticipant.Location = new System.Drawing.Point(6, 22);
      this.btnAddParticipant.Name = "btnAddParticipant";
      this.btnAddParticipant.Size = new System.Drawing.Size(92, 48);
      this.btnAddParticipant.TabIndex = 27;
      this.btnAddParticipant.Text = "Add";
      this.btnAddParticipant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnAddParticipant.UseVisualStyleBackColor = true;
      this.btnAddParticipant.Click += new System.EventHandler(this.btnAddParticipant_Click);
      // 
      // btnEditParticipant
      // 
      this.btnEditParticipant.Image = ((System.Drawing.Image)(resources.GetObject("btnEditParticipant.Image")));
      this.btnEditParticipant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnEditParticipant.Location = new System.Drawing.Point(6, 76);
      this.btnEditParticipant.Name = "btnEditParticipant";
      this.btnEditParticipant.Size = new System.Drawing.Size(92, 48);
      this.btnEditParticipant.TabIndex = 28;
      this.btnEditParticipant.Text = "Edit";
      this.btnEditParticipant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnEditParticipant.UseVisualStyleBackColor = true;
      this.btnEditParticipant.Click += new System.EventHandler(this.btnEditParticipant_Click);
      // 
      // btnDeleteParticipant
      // 
      this.btnDeleteParticipant.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteParticipant.Image")));
      this.btnDeleteParticipant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnDeleteParticipant.Location = new System.Drawing.Point(6, 130);
      this.btnDeleteParticipant.Name = "btnDeleteParticipant";
      this.btnDeleteParticipant.Size = new System.Drawing.Size(92, 48);
      this.btnDeleteParticipant.TabIndex = 29;
      this.btnDeleteParticipant.Text = "Delete";
      this.btnDeleteParticipant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnDeleteParticipant.UseVisualStyleBackColor = true;
      this.btnDeleteParticipant.Click += new System.EventHandler(this.btnDeleteParticipant_Click);
      // 
      // btnUpParticipant
      // 
      this.btnUpParticipant.Image = ((System.Drawing.Image)(resources.GetObject("btnUpParticipant.Image")));
      this.btnUpParticipant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnUpParticipant.Location = new System.Drawing.Point(6, 194);
      this.btnUpParticipant.Name = "btnUpParticipant";
      this.btnUpParticipant.Size = new System.Drawing.Size(92, 48);
      this.btnUpParticipant.TabIndex = 30;
      this.btnUpParticipant.Text = "Up";
      this.btnUpParticipant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnUpParticipant.UseVisualStyleBackColor = true;
      this.btnUpParticipant.Click += new System.EventHandler(this.btnUpParticipant_Click);
      // 
      // btnDownParticipant
      // 
      this.btnDownParticipant.Image = ((System.Drawing.Image)(resources.GetObject("btnDownParticipant.Image")));
      this.btnDownParticipant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnDownParticipant.Location = new System.Drawing.Point(6, 248);
      this.btnDownParticipant.Name = "btnDownParticipant";
      this.btnDownParticipant.Size = new System.Drawing.Size(92, 48);
      this.btnDownParticipant.TabIndex = 31;
      this.btnDownParticipant.Text = "Down";
      this.btnDownParticipant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnDownParticipant.UseVisualStyleBackColor = true;
      this.btnDownParticipant.Click += new System.EventHandler(this.btnDownParticipant_Click);
      // 
      // gb_Participation
      // 
      this.gb_Participation.Controls.Add(this.btnAddParticipant);
      this.gb_Participation.Controls.Add(this.dgw);
      this.gb_Participation.Controls.Add(this.btnUpParticipant);
      this.gb_Participation.Controls.Add(this.btnDownParticipant);
      this.gb_Participation.Controls.Add(this.btnEditParticipant);
      this.gb_Participation.Controls.Add(this.btnDeleteParticipant);
      this.gb_Participation.Location = new System.Drawing.Point(3, 3);
      this.gb_Participation.Name = "gb_Participation";
      this.gb_Participation.Size = new System.Drawing.Size(1150, 296);
      this.gb_Participation.TabIndex = 32;
      this.gb_Participation.TabStop = false;
      this.gb_Participation.Text = "Účastnící události a intervence - oběti/poškození, pozůstalé a blízké osoby, pach" +
"atel, ostatní osoby.";
      this.gb_Participation.Enter += new System.EventHandler(this.gb_Participation_Enter);
      // 
      // ucParticipations
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.gb_Participation);
      this.Name = "ucParticipations";
      this.Size = new System.Drawing.Size(1153, 299);
      this.Load += new System.EventHandler(this.ucParticipations_Load);
      this.Resize += new System.EventHandler(this.ucParticipations_Resize);
      ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
      this.gb_Participation.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dgw;
    private System.Windows.Forms.Button btnAddParticipant;
    private System.Windows.Forms.Button btnEditParticipant;
    private System.Windows.Forms.Button btnDeleteParticipant;
    private System.Windows.Forms.Button btnUpParticipant;
    private System.Windows.Forms.Button btnDownParticipant;
    private System.Windows.Forms.GroupBox gb_Participation;
  }
}
