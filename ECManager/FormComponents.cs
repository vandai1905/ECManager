using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ECManager
{
    public partial class FormComponents : Form
    {
        public FormComponents()
        {
            InitializeComponent();
        }

        private void FormComponents_Load(object sender, EventArgs e)
        {
            LoadComponents();
        }

        private void LoadComponents()
        {
            using (MySqlConnection conn = new MySqlConnection(connect.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT c.component_id, c.name AS 'Tên linh kiện', 
                                        cat.name AS 'Loại', m.name AS 'Nhà SX', 
                                        c.quantity AS 'Số lượng', c.unit AS 'Đơn vị', 
                                        c.price AS 'Giá', c.location AS 'Vị trí', c.note AS 'Ghi chú'
                                     FROM components c
                                     LEFT JOIN categories cat ON c.category_id = cat.category_id
                                     LEFT JOIN manufacturers m ON c.manufacturer_id = m.manufacturer_id";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvComponents.DataSource = dt;
                    dgvComponents.Columns["component_id"].Visible = false; // ẩn ID
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải linh kiện: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormComponentDetail frm = new FormComponentDetail();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadComponents();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvComponents.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvComponents.CurrentRow.Cells["component_id"].Value);
                FormComponentDetail frm = new FormComponentDetail(id);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadComponents();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvComponents.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvComponents.CurrentRow.Cells["component_id"].Value);
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa linh kiện này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connect.GetConnectionString()))
                    {
                        try
                        {
                            conn.Open();
                            string sql = "DELETE FROM components WHERE component_id = @id";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                            LoadComponents();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                        }
                    }
                }
            }
        }
    }
}
