using Business.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Admin
{
    public partial class FrmBackUp : Form
    {
        public FrmBackUp()
        {
            InitializeComponent();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {    
            DialogResult dialogResult= folderBrowserDialog1.ShowDialog();

            if (dialogResult==DialogResult.OK)
            {
                string filePath = folderBrowserDialog1.SelectedPath;
                TxtPath.Text = filePath;
            }
        }

        private void BtnBackUp_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(TxtPath.Text))
            {
                MessageBox.Show("Dosya Yolu Seçiniz");
                return;
            }
            if (string.IsNullOrEmpty(TxtName.Text))
            {
                MessageBox.Show("Dosya İsmi Belirtiniz");
                return;
            }

            string fileName = TxtName.Text.Trim();
            fileName= Path.GetFileNameWithoutExtension(fileName);
            fileName =@"\" + fileName + ".bak";

            AdminManager.GetInstance().BackUp(TxtPath.Text.Trim(), fileName);
            System.Diagnostics.Process.Start(TxtPath.Text.Trim());
        }
    }
}
