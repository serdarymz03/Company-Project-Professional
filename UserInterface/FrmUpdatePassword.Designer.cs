namespace UserInterface
{
    partial class FrmUpdatePassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPassword1 = new System.Windows.Forms.TextBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.TxtPassword2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChcShowPassword = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChcShowPassword);
            this.groupBox1.Controls.Add(this.TxtPassword2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.BtnUpdate);
            this.groupBox1.Controls.Add(this.TxtPassword1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(405, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bilgiler   ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Şifre : ";
            // 
            // TxtPassword1
            // 
            this.TxtPassword1.Location = new System.Drawing.Point(140, 34);
            this.TxtPassword1.Name = "TxtPassword1";
            this.TxtPassword1.Size = new System.Drawing.Size(228, 24);
            this.TxtPassword1.TabIndex = 1;
            this.TxtPassword1.UseSystemPasswordChar = true;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnUpdate.Location = new System.Drawing.Point(125, 172);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(193, 41);
            this.BtnUpdate.TabIndex = 2;
            this.BtnUpdate.Text = "Şifreyi Güncelle";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // TxtPassword2
            // 
            this.TxtPassword2.Location = new System.Drawing.Point(140, 77);
            this.TxtPassword2.Name = "TxtPassword2";
            this.TxtPassword2.Size = new System.Drawing.Size(228, 24);
            this.TxtPassword2.TabIndex = 4;
            this.TxtPassword2.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre (Tekrar): ";
            // 
            // ChcShowPassword
            // 
            this.ChcShowPassword.AutoSize = true;
            this.ChcShowPassword.Location = new System.Drawing.Point(171, 120);
            this.ChcShowPassword.Name = "ChcShowPassword";
            this.ChcShowPassword.Size = new System.Drawing.Size(126, 22);
            this.ChcShowPassword.TabIndex = 5;
            this.ChcShowPassword.Text = "Şifreleri Göster";
            this.ChcShowPassword.UseVisualStyleBackColor = true;
            this.ChcShowPassword.CheckedChanged += new System.EventHandler(this.ChcShowPassword_CheckedChanged);
            // 
            // FrmUpdatePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 270);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmUpdatePassword";
            this.ShowIcon = false;
            this.Text = "Şifre Güncelleme Ekranı";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ChcShowPassword;
        private System.Windows.Forms.TextBox TxtPassword2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.TextBox TxtPassword1;
        private System.Windows.Forms.Label label1;
    }
}