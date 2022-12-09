
namespace EvitelApp2.Controls
{
    partial class ucIntervents
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
            this.ucDataGridView1 = new EvitelApp2.MyUserControl.ucDataGridView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ucDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDataGridView1
            // 
            this.ucDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ucDataGridView1.Location = new System.Drawing.Point(73, 28);
            this.ucDataGridView1.Name = "ucDataGridView1";
            this.ucDataGridView1.RowTemplate.Height = 25;
            this.ucDataGridView1.Size = new System.Drawing.Size(519, 225);
            this.ucDataGridView1.TabIndex = 0;
            // 
            // ucIntervents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucDataGridView1);
            this.Name = "ucIntervents";
            this.Size = new System.Drawing.Size(1027, 443);
            ((System.ComponentModel.ISupportInitialize)(this.ucDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyUserControl.ucDataGridView ucDataGridView1;
    }
}
