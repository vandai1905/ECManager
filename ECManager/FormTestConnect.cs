using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ECManager
{
    public partial class FormTestConnect : Form
    {
        private connect cnt;

        public FormTestConnect()
        {
            InitializeComponent();
            cnt = new connect();
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            string error;
            bool success = cnt.TestConnection(out error);

            if (success)
            {
                lblResult.Text = "✅ Kết nối thành công!";
                lblResult.ForeColor = Color.Green;
            }
            else
            {
                lblResult.Text = "❌ Kết nối thất bại!\n" + error;
                lblResult.ForeColor = Color.Red;
            }
        }

    }
}