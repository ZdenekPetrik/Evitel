
namespace EvitelApp2
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSystemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MeneToolsChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolEventLog = new System.Windows.Forms.ToolStripMenuItem();
            this.NewCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCallLIKOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCallLDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucCallLIKO1 = new EvitelApp2.Controls.ucCallLIKO();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.viewsToolStripMenuItem,
            this.NewCallToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1421, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSystemExit});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // MenuSystemExit
            // 
            this.MenuSystemExit.Name = "MenuSystemExit";
            this.MenuSystemExit.Size = new System.Drawing.Size(93, 22);
            this.MenuSystemExit.Text = "Exit";
            this.MenuSystemExit.Click += new System.EventHandler(this.MenuSystemExit_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MeneToolsChangePassword});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.toolsToolStripMenuItem.Text = "Nástroje";
            // 
            // MeneToolsChangePassword
            // 
            this.MeneToolsChangePassword.Name = "MeneToolsChangePassword";
            this.MeneToolsChangePassword.Size = new System.Drawing.Size(143, 22);
            this.MeneToolsChangePassword.Text = "Změna Hesla";
            this.MeneToolsChangePassword.Click += new System.EventHandler(this.MeneToolsChangePassword_Click);
            // 
            // viewsToolStripMenuItem
            // 
            this.viewsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolEventLog});
            this.viewsToolStripMenuItem.Name = "viewsToolStripMenuItem";
            this.viewsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.viewsToolStripMenuItem.Text = "Zobrazení";
            // 
            // MenuToolEventLog
            // 
            this.MenuToolEventLog.Name = "MenuToolEventLog";
            this.MenuToolEventLog.Size = new System.Drawing.Size(123, 22);
            this.MenuToolEventLog.Text = "EventLog";
            this.MenuToolEventLog.Click += new System.EventHandler(this.MenuToolEventLog_Click);
            // 
            // NewCallToolStripMenuItem
            // 
            this.NewCallToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCallLIKOToolStripMenuItem,
            this.newCallLDToolStripMenuItem});
            this.NewCallToolStripMenuItem.Name = "NewCallToolStripMenuItem";
            this.NewCallToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.NewCallToolStripMenuItem.Text = "Nový hovor";
            // 
            // newCallLIKOToolStripMenuItem
            // 
            this.newCallLIKOToolStripMenuItem.Name = "newCallLIKOToolStripMenuItem";
            this.newCallLIKOToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.newCallLIKOToolStripMenuItem.Text = "Nový hovor - LIKO";
            this.newCallLIKOToolStripMenuItem.Click += new System.EventHandler(this.newCallLIKOToolStripMenuItem_Click);
            // 
            // newCallLDToolStripMenuItem
            // 
            this.newCallLDToolStripMenuItem.Name = "newCallLDToolStripMenuItem";
            this.newCallLDToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.newCallLDToolStripMenuItem.Text = "Nový hovor - LD";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTime,
            this.toolStripUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1421, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripTime
            // 
            this.toolStripTime.Name = "toolStripTime";
            this.toolStripTime.Size = new System.Drawing.Size(79, 17);
            this.toolStripTime.Text = "ToolStripTime";
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
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer1.Size = new System.Drawing.Size(288, 266);
            this.splitContainer1.SplitterDistance = 174;
            this.splitContainer1.TabIndex = 2;
            // 
            // ucCallLIKO1
            // 
            this.ucCallLIKO1.Location = new System.Drawing.Point(160, 24);
            this.ucCallLIKO1.Name = "ucCallLIKO1";
            this.ucCallLIKO1.Size = new System.Drawing.Size(1174, 508);
            this.ucCallLIKO1.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 557);
            this.Controls.Add(this.ucCallLIKO1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripUser;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSystemExit;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MeneToolsChangePassword;
        private System.Windows.Forms.ToolStripMenuItem viewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuToolEventLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem NewCallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCallLIKOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCallLDToolStripMenuItem;
        private Controls.ucCallLIKO ucCallLIKO1;
    }
}

