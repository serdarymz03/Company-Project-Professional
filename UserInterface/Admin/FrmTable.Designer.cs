namespace UserInterface.Admin
{
    partial class FrmTable
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgInfo = new System.Windows.Forms.DataGridView();
            this.Dtg_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 293);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DtgInfo
            // 
            this.DtgInfo.AllowUserToAddRows = false;
            this.DtgInfo.AllowUserToDeleteRows = false;
            this.DtgInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dtg_Name});
            this.DtgInfo.Cursor = System.Windows.Forms.Cursors.PanWest;
            this.DtgInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgInfo.Location = new System.Drawing.Point(3, 20);
            this.DtgInfo.MultiSelect = false;
            this.DtgInfo.Name = "DtgInfo";
            this.DtgInfo.ReadOnly = true;
            this.DtgInfo.RowHeadersVisible = false;
            this.DtgInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgInfo.Size = new System.Drawing.Size(777, 270);
            this.DtgInfo.TabIndex = 0;
            // 
            // Dtg_Name
            // 
            this.Dtg_Name.HeaderText = "Personel İsmi";
            this.Dtg_Name.Name = "Dtg_Name";
            this.Dtg_Name.ReadOnly = true;
            // 
            // FrmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 349);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmTable";
            this.ShowIcon = false;
            this.Text = "Bilgi Ekranı";
            this.Load += new System.EventHandler(this.FrmTable_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DtgInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dtg_Name;
    }
}