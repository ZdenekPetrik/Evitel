namespace EvitelApp2.Controls
{
    partial class ctrlEventLogFilter
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
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbEventSubCode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbEventCode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbInterval = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(98, 18);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(201, 23);
            this.dtFrom.TabIndex = 0;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(313, 18);
            this.dtTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(207, 23);
            this.dtTo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Od-Do:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(651, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Program:";
            // 
            // cmbProgram
            // 
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(715, 15);
            this.cmbProgram.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(245, 23);
            this.cmbProgram.TabIndex = 4;
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(98, 66);
            this.cmbUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(201, 23);
            this.cmbUser.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Uživatel:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(651, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Text:";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(715, 67);
            this.txtText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(245, 23);
            this.txtText.TabIndex = 10;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1021, 15);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(88, 27);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbEventSubCode
            // 
            this.cmbEventSubCode.FormattingEnabled = true;
            this.cmbEventSubCode.Location = new System.Drawing.Point(410, 112);
            this.cmbEventSubCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbEventSubCode.Name = "cmbEventSubCode";
            this.cmbEventSubCode.Size = new System.Drawing.Size(207, 23);
            this.cmbEventSubCode.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(327, 118);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Event Type:";
            // 
            // cmbEventCode
            // 
            this.cmbEventCode.FormattingEnabled = true;
            this.cmbEventCode.Location = new System.Drawing.Point(98, 113);
            this.cmbEventCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbEventCode.Name = "cmbEventCode";
            this.cmbEventCode.Size = new System.Drawing.Size(201, 23);
            this.cmbEventCode.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 117);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Event Group:";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(715, 114);
            this.txtValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(245, 23);
            this.txtValue.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(651, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Value:";
            // 
            // cmbInterval
            // 
            this.cmbInterval.FormattingEnabled = true;
            this.cmbInterval.Location = new System.Drawing.Point(527, 17);
            this.cmbInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbInterval.Name = "cmbInterval";
            this.cmbInterval.Size = new System.Drawing.Size(89, 23);
            this.cmbInterval.TabIndex = 18;
            this.cmbInterval.SelectedIndexChanged += new System.EventHandler(this.cmbInterval_SelectedIndexChanged);
            // 
            // ctrlEventLogFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbInterval);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbEventSubCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbEventCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ctrlEventLogFilter";
            this.Size = new System.Drawing.Size(1126, 158);
            this.Load += new System.EventHandler(this.ctrlEventLogFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbEventSubCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbEventCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbInterval;
    }
}
