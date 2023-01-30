namespace EvitelApp2.Controls
{
    partial class frmTestEndNPOI
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtFaktorialZ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProtokol = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.txtAutocomplete = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.treeViewContactTopic = new System.Windows.Forms.TreeView();
            this.btnTreeViewRead = new System.Windows.Forms.Button();
            this.btnTreeViewWrite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(591, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(609, 257);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(73, 52);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Faktorial";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtFaktorialZ
            // 
            this.txtFaktorialZ.Location = new System.Drawing.Point(183, 52);
            this.txtFaktorialZ.Name = "txtFaktorialZ";
            this.txtFaktorialZ.Size = new System.Drawing.Size(100, 23);
            this.txtFaktorialZ.TabIndex = 3;
            this.txtFaktorialZ.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // btnProtokol
            // 
            this.btnProtokol.Location = new System.Drawing.Point(426, 351);
            this.btnProtokol.Name = "btnProtokol";
            this.btnProtokol.Size = new System.Drawing.Size(75, 23);
            this.btnProtokol.TabIndex = 5;
            this.btnProtokol.Text = "Protokol událostí";
            this.btnProtokol.UseVisualStyleBackColor = true;
            this.btnProtokol.Click += new System.EventHandler(this.btnProtokol_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(444, 222);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 6;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(444, 251);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // txtAutocomplete
            // 
            this.txtAutocomplete.Location = new System.Drawing.Point(591, 52);
            this.txtAutocomplete.Name = "txtAutocomplete";
            this.txtAutocomplete.Size = new System.Drawing.Size(100, 23);
            this.txtAutocomplete.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(513, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Autocomplete (našeptávač 3 znaky)";
            // 
            // treeViewContactTopic
            // 
            this.treeViewContactTopic.Location = new System.Drawing.Point(70, 122);
            this.treeViewContactTopic.Name = "treeViewContactTopic";
            this.treeViewContactTopic.Size = new System.Drawing.Size(297, 270);
            this.treeViewContactTopic.TabIndex = 10;
            this.treeViewContactTopic.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeViewContactTopic_DrawNode);
            // 
            // btnTreeViewRead
            // 
            this.btnTreeViewRead.Location = new System.Drawing.Point(70, 398);
            this.btnTreeViewRead.Name = "btnTreeViewRead";
            this.btnTreeViewRead.Size = new System.Drawing.Size(92, 23);
            this.btnTreeViewRead.TabIndex = 11;
            this.btnTreeViewRead.Text = "Read From DB";
            this.btnTreeViewRead.UseVisualStyleBackColor = true;
            this.btnTreeViewRead.Click += new System.EventHandler(this.btnTreeViewRead_Click);
            // 
            // btnTreeViewWrite
            // 
            this.btnTreeViewWrite.Location = new System.Drawing.Point(292, 398);
            this.btnTreeViewWrite.Name = "btnTreeViewWrite";
            this.btnTreeViewWrite.Size = new System.Drawing.Size(75, 23);
            this.btnTreeViewWrite.TabIndex = 12;
            this.btnTreeViewWrite.Text = "Write to DB";
            this.btnTreeViewWrite.UseVisualStyleBackColor = true;
            this.btnTreeViewWrite.Click += new System.EventHandler(this.btnTreeViewWrite_Click);
            // 
            // frmTestEndNPOI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTreeViewWrite);
            this.Controls.Add(this.btnTreeViewRead);
            this.Controls.Add(this.treeViewContactTopic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAutocomplete);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnProtokol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFaktorialZ);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmTestEndNPOI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmTestEndNPOI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.TextBox txtFaktorialZ;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnProtokol;
    private System.Windows.Forms.Button btnBackup;
    private System.Windows.Forms.Button btnRestore;
    private System.Windows.Forms.TextBox txtAutocomplete;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TreeView treeViewContactTopic;
    private System.Windows.Forms.Button btnTreeViewRead;
    private System.Windows.Forms.Button btnTreeViewWrite;
  }
}