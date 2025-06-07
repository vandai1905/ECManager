using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnComponents_Click(object sender, EventArgs e)
        {
            FormComponents frmComponents = new FormComponents();
            frmComponents.ShowDialog();
        }

        private void btnImports_Click(object sender, EventArgs e)
        {
            FormImport frmImport = new FormImport();
            frmImport.ShowDialog();
        }

        private void btnExports_Click(object sender, EventArgs e)
        {
            FormExport frmExport = new FormExport();
            frmExport.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            FormUsers frmUsers = new FormUsers();
            frmUsers.ShowDialog();
        }
    }
}