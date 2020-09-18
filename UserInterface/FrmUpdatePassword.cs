using Business.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class FrmUpdatePassword : Form
    {
        PersonnelManager personnelManager;
        public string personNo;
        public FrmUpdatePassword()
        {
            InitializeComponent();
            personnelManager = PersonnelManager.GetInstance();
        }

        private void ChcShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ChcShowPassword.Checked)
            {
                TxtPassword1.UseSystemPasswordChar = false;
                TxtPassword2.UseSystemPasswordChar = false;
            }
            else
            {
                TxtPassword1.UseSystemPasswordChar = true;
                TxtPassword2.UseSystemPasswordChar = true;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string controlText = personnelManager.IsPasswordComplete(TxtPassword1.Text, TxtPassword2.Text);
            if (controlText != "")
            {
                MessageBox.Show(controlText);
                return;
            }

            controlText = personnelManager.UpdatePassword(personNo, TxtPassword1.Text.Trim());
            if (controlText == "1")
            {
                MessageBox.Show("Şifre Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else if (controlText == "-1")
            {
                MessageBox.Show("Bir Hata Oldu. Yetkiliyle Görüşünüz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
