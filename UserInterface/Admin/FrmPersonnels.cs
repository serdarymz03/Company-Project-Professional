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
    public partial class FrmPersonnels : Form
    {
        PersonnelManager personnelManager;
        DepartmentManager departmentManager;
        AuthManager authManager;
        List<Personnel> personnels;
        Personnel personnel;
        int outNumber = 0;

        public FrmPersonnels()
        {
            InitializeComponent();
            personnelManager = PersonnelManager.GetInstance();
            departmentManager = DepartmentManager.GetInstance();
            authManager = AuthManager.GetInstance();
        }

        private void FrmPersonnels_Load(object sender, EventArgs e)
        {
            ComboboxLoad();
            PersonnelList();
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

        public void PersonnelList()
        {
            personnels = personnelManager.GetList();
            DtgPersonnels.DataSource = personnels;  // DataGrid İçin Liste Döndürme Yöntemi
            //DtgPersonnels.DataSource = personnelManager.GetTable();  // DataGrid İçin Tablo Döndürme Yöntemi
            personnel = null;
            Clear();
        }

        private void DtgPersonnels_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgPersonnels.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle Listeden Personel Seçiniz");
                return;
            }

            personnel = new Personnel(
                DtgPersonnels.CurrentRow.Cells["Id"].Value.ConInt(),
                DtgPersonnels.CurrentRow.Cells["DepartmentId"].Value.ConInt(),
                DtgPersonnels.CurrentRow.Cells["AuthId"].Value.ConInt(),
                DtgPersonnels.CurrentRow.Cells["PersonNo"].Value.ToString(),
                DtgPersonnels.CurrentRow.Cells["Name"].Value.ToString(),
                DtgPersonnels.CurrentRow.Cells["DepartmentName"].Value.ToString(),
                DtgPersonnels.CurrentRow.Cells["AuthName"].Value.ToString()
                );

            TxtPersonNo.Text = personnel.PersonNo;
            TxtName.Text = personnel.Name;
            CmbDepartment.SelectedValue = personnel.DepartmentId;
            CmbAuth.SelectedValue = personnel.AuthId;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (personnel == null)
            {
                MessageBox.Show("Öncelikle Personel Seçiniz");
                return;
            }
            DialogResult dr = MessageBox.Show(personnel.Name + " Personeli İçin Güncelleme Yapmak İstediğinize Emin Misiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                personnel.Name = TxtName.Text;
                personnel.DepartmentId = CmbDepartment.SelectedValue.ConInt();
                personnel.AuthId = CmbAuth.SelectedValue.ConInt();

                MessageBox.Show(personnelManager.Update(personnel));
                PersonnelList();
            }
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonnelList();
        }

        void Clear()
        {
            TxtName.Text = ""; TxtPersonNo.Text = ""; CmbDepartment.SelectedValue = 0; CmbAuth.SelectedValue = 0;
        }

        private void TxtPersonNo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void BenDelete_Click(object sender, EventArgs e)
        {
            if (personnel == null)
            {
                MessageBox.Show("Öncelikle Personel Seçiniz");
                return;
            }
            DialogResult dr = MessageBox.Show(personnel.Name + " Personeli İçin Silme İşlemi Yapmak İstediğinize Emin Misiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                personnelManager.Delete(personnel.Id);
                PersonnelList();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmAddPerson frmAddPerson = new FrmAddPerson();
            frmAddPerson.ShowDialog();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (personnels == null)
            {
                return;
            }
            if (personnels.Count == 0)
            {
                return;
            }

            List<Personnel> exampleList;
            string searchText = TxtSearch.Text.Trim();

            if (int.TryParse(searchText, out outNumber))
            {
                exampleList = personnels.Where(i => i.PersonNo.Contains(searchText)).ToList();
            }
            else
            {
                exampleList = personnels.Where(i => i.Name.ToLower().Contains(searchText.ToLower())).ToList();
            }
            DtgPersonnels.DataSource = null;
            DtgPersonnels.DataSource = exampleList;
            personnel = null;
            Clear();
        }
    }
}
