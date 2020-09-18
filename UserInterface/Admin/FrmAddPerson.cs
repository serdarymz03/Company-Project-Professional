using Business.Concrete;
using DataAccess.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Admin
{
    public partial class FrmAddPerson : Form
    {
        PersonnelManager personnelManager;
        DepartmentManager departmentManager;
        AuthManager authManager;
        public FrmAddPerson()
        {
            InitializeComponent();
            personnelManager = PersonnelManager.GetInstance();
            departmentManager = DepartmentManager.GetInstance();
            authManager = AuthManager.GetInstance();
        }

        private void FrmAddPerson_Load(object sender, EventArgs e)
        {
            ComboboxLoad();
        }
        void ComboboxLoad()
        {
            CmbDepartment.DataSource = departmentManager.GetList();
            CmbDepartment.ValueMember = "Id";
            CmbDepartment.DisplayMember = "Name";
            CmbDepartment.SelectedValue = 0;

            CmbAuth.DataSource = authManager.GetList();
            CmbAuth.ValueMember = "Id";
            CmbAuth.DisplayMember = "Name";
            CmbAuth.SelectedValue = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(TxtName.Text + " Personelini Kaydetmek İstiyor Musunuz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Personnel personnel = new Personnel(CmbDepartment.SelectedValue.ConInt(), CmbAuth.SelectedValue.ConInt(), MskSicilNo.Text, TxtName.Text);


                string text = personnelManager.Add(personnel);
                if (text == "1")
                {
                    MessageBox.Show(TxtName.Text + " Personeli Başarıyla Kaydoldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (text == "0")
                {
                    MessageBox.Show(MskSicilNo.Text + " Sicil Numarası Daha Önce Kullanılmış", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (text == "-1")
                {
                    MessageBox.Show("Bir Hata Oldu. Yetkiliyle Görüşünüz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                var form = (FrmPersonnels)Application.OpenForms["FrmPersonnels"];
                form.PersonnelList();
            }
        }
    }
}
