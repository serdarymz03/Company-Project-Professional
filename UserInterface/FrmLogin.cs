using Business.Concrete;
using DataAccess.Concrete;
using Entity;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using UserInterface.Admin;
using UserInterface.Worker;

namespace UserInterface
{
    public partial class FrmLogin : Form
    {
        PersonnelManager personnelManager;
        public FrmLogin()
        {
            InitializeComponent();
            personnelManager = PersonnelManager.GetInstance();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //Nesne Oluşturarak Config Dosyasındaki Değeri Okuma:
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //string version = config.AppSettings.Settings["version"].Value;
            //string version2 = config.AppSettings.Settings["version2"].Value;

            //string version= ConfigurationManager.AppSettings["version"];
            //string version2= ConfigurationManager.AppSettings["version2"];

            //Config Dosyasındaki Değişikliği Kaydetme
            //config.Save(ConfigurationSaveMode.Modified, true);

        }
        private void FrmLogin_Shown(object sender, EventArgs e)
        {           
            TxtPassword.Text = "123456";

            //Form Üstündeki Button İçin Kod İle Click Tetikleme
            //BtnLogin.PerformClick(); 
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (MskSicil.Text.Trim() == "" || TxtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen Sicil Numaranızla Birlikte Şifrenizi Giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            object[] infos = personnelManager.Login(MskSicil.Text, TxtPassword.Text);

            if (infos == null)
            {
                MessageBox.Show("Hatalı Sicil No Veya Şifre Girdiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UserRealName.RealName = infos[2].ToString();
            MessageBox.Show("Sayın " + infos[2] + " Hoşgeldiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (infos[5].ConInt() == 1)
            {
                DialogResult dr = MessageBox.Show("Admin Pencerenizi Açmak İster Misiniz ? ", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    FrmAdminDashboard frmAdminDashboard = new FrmAdminDashboard();
                    frmAdminDashboard.infos = infos;
                    frmAdminDashboard.Show();
                }
                else
                {
                    ShowWorkerDahsboard(infos);
                }
                this.Hide();
            }
            else
            {
                ShowWorkerDahsboard(infos);
                this.Hide();
            }
        }

        void ShowWorkerDahsboard(object[] infos)
        {
            FrmWorkerDashboard frmWorkerDashboard = new FrmWorkerDashboard();
            frmWorkerDashboard.infos = infos;
            frmWorkerDashboard.Show();
        }

        private void LnkUpdatePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MskSicil.Text.Trim() == "")
            {
                MessageBox.Show("Sicil Numaranızı Giriniz");
                return;
            }

            FrmUpdatePassword frmUpdatePassword = new FrmUpdatePassword();
            frmUpdatePassword.personNo = MskSicil.Text;
            frmUpdatePassword.ShowDialog();
        }
    }
}
