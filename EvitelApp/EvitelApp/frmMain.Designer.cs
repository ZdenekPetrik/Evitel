
namespace EvitelApp
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuHelp = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odhlásitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oAplikaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phonesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuHelp.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuHelp
            // 
            this.menuHelp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.eventLogMenuItem,
            this.phonesMenuItem});
            this.menuHelp.Location = new System.Drawing.Point(0, 0);
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(976, 24);
            this.menuHelp.TabIndex = 0;
            this.menuHelp.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.AccessibleRole = System.Windows.Forms.AccessibleRole.Separator;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(93, 22);
            this.toolStripMenuItem2.Text = "---";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangePasswordToolStripMenuItem,
            this.odhlásitToolStripMenuItem,
            this.oAplikaciToolStripMenuItem,
            this.testToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // ChangePasswordToolStripMenuItem
            // 
            this.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem";
            this.ChangePasswordToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.ChangePasswordToolStripMenuItem.Text = "Změna hesla";
            this.ChangePasswordToolStripMenuItem.Click += new System.EventHandler(this.změnaHeslaToolStripMenuItem_Click);
            // 
            // odhlásitToolStripMenuItem
            // 
            this.odhlásitToolStripMenuItem.Name = "odhlásitToolStripMenuItem";
            this.odhlásitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.odhlásitToolStripMenuItem.Text = "Odhlásit";
            // 
            // oAplikaciToolStripMenuItem
            // 
            this.oAplikaciToolStripMenuItem.Name = "oAplikaciToolStripMenuItem";
            this.oAplikaciToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.oAplikaciToolStripMenuItem.Text = "O aplikaci";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // eventLogMenuItem
            // 
            this.eventLogMenuItem.Name = "eventLogMenuItem";
            this.eventLogMenuItem.Size = new System.Drawing.Size(68, 20);
            this.eventLogMenuItem.Text = "EventLog";
            this.eventLogMenuItem.Click += new System.EventHandler(this.eventLogMenuItem_Click);
            // 
            // phonesMenuItem
            // 
            this.phonesMenuItem.Name = "phonesMenuItem";
            this.phonesMenuItem.Size = new System.Drawing.Size(58, 20);
            this.phonesMenuItem.Text = "Phones";
            this.phonesMenuItem.Click += new System.EventHandler(this.phonesMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTime,
            this.toolStripUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 481);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(976, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Resize += new System.EventHandler(this.statusStrip1_Resize);
            // 
            // toolStripTime
            // 
            this.toolStripTime.Name = "toolStripTime";
            this.toolStripTime.Size = new System.Drawing.Size(78, 17);
            this.toolStripTime.Text = "toolStripTime";
            // 
            // toolStripUser
            // 
            this.toolStripUser.Name = "toolStripUser";
            this.toolStripUser.Size = new System.Drawing.Size(75, 17);
            this.toolStripUser.Text = "toolStripUser";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.ForeColor = System.Drawing.SystemColors.Info;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer1.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer1.Size = new System.Drawing.Size(976, 457);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 503);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuHelp);
            this.MainMenuStrip = this.menuHelp;
            this.Name = "frmMain";
            this.Text = "Evitel";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuHelp.ResumeLayout(false);
            this.menuHelp.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuHelp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oAplikaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odhlásitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripUser;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem eventLogMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phonesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
    }
}

