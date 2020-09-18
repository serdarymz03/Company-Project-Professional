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
    public partial class FrmTable : Form
    {
        public List<string> names;
        public FrmTable()
        {
            InitializeComponent();
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            if (names != null)
            {
                if (names.Count > 0)
                {
                    NameList();
                    MessageBox.Show("Departmana Kayıtlı Personeller Olduğu İçin Silme İşlemi Yapılamadı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        void NameList()
        {
            DtgInfo.Rows.Clear();
            foreach (string item in names)
            {
                DtgInfo.Rows.Add();
                int lastRow = DtgInfo.RowCount - 1;
                DtgInfo.Rows[lastRow].Cells["Dtg_Name"].Value = item;
            }
        }
    }
}
