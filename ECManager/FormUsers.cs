using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ECManager
{
    public partial class FormUsers : Form
    {
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private DataTable dtUsers;
        private bool isEditing = false; // phân biệt thêm/sửa
        private int editingUserId = -1;

        public FormUsers()
        {
            InitializeComponent();
            InitDatabase();
            LoadUsers();
            dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
            SetEditingMode(false);
        }

        private void InitDatabase()
        {
            string connStr = connect.GetConnectionString(); // Lấy chuỗi kết nối từ class connect
            connection = new MySqlConnection(connStr);
        }

        private void LoadUsers()
        {
            try
            {
                connection.Open();
                string query = "SELECT user_id, username, role FROM users";
                adapter = new MySqlDataAdapter(query, connection);
                dtUsers = new DataTable();
                adapter.Fill(dtUsers);
                dgvUsers.DataSource = dtUsers;

                // Ẩn cột user_id
                dgvUsers.Columns["user_id"].Visible = false;
                dgvUsers.AutoResizeColumns();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                txtUsername.Text = dgvUsers.CurrentRow.Cells["username"].Value.ToString();
                // Password không nên hiển thị, giữ trống để nhập mới hoặc sửa
                txtPassword.Text = "";
                cboRole.SelectedItem = dgvUsers.CurrentRow.Cells["role"].Value.ToString();
                editingUserId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["user_id"].Value);
                SetEditingMode(false);
            }
        }

        private void SetEditingMode(bool editing)
        {
            isEditing = editing;
            btnSave.Enabled = editing;
            btnAdd.Enabled = !editing;
            btnEdit.Enabled = !editing && dgvUsers.CurrentRow != null;
            btnDelete.Enabled = !editing && dgvUsers.CurrentRow != null;
            txtUsername.ReadOnly = !editing;
            txtPassword.ReadOnly = !editing;
            cboRole.Enabled = editing;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            cboRole.SelectedIndex = 0;
            editingUserId = -1;
            SetEditingMode(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                SetEditingMode(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            var username = dgvUsers.CurrentRow.Cells["username"].Value.ToString();
            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa user '{username}'?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM users WHERE user_id = @userId";
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                    cmd.Parameters.AddWithValue("@userId", editingUserId);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống.");
                return;
            }

            if (editingUserId == -1 && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống khi thêm người dùng mới.");
                return;
            }

            try
            {
                connection.Open();

                if (editingUserId == -1) // Thêm mới
                {
                    string insertQuery = "INSERT INTO users (username, password, role) VALUES (@username, @password, @role)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", HashPassword(txtPassword.Text.Trim())); // Mã hóa mật khẩu (nếu muốn)
                    cmd.Parameters.AddWithValue("@role", cboRole.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                }
                else // Sửa
                {
                    string updateQuery;
                    MySqlCommand cmd;

                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        // Nếu nhập mật khẩu mới thì update cả mật khẩu
                        updateQuery = "UPDATE users SET username=@username, password=@password, role=@role WHERE user_id=@userId";
                        cmd = new MySqlCommand(updateQuery, connection);
                        cmd.Parameters.AddWithValue("@password", HashPassword(txtPassword.Text.Trim()));
                    }
                    else
                    {
                        // Nếu không nhập mật khẩu, giữ nguyên mật khẩu cũ
                        updateQuery = "UPDATE users SET username=@username, role=@role WHERE user_id=@userId";
                        cmd = new MySqlCommand(updateQuery, connection);
                    }

                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@role", cboRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@userId", editingUserId);
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
                LoadUsers();
                SetEditingMode(false);
                MessageBox.Show("Lưu thành công!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message);
            }
        }

        // Hàm hash mật khẩu đơn giản (có thể dùng thư viện khác như BCrypt)
        private string HashPassword(string password)
        {
            // Đây là ví dụ dùng SHA256, bạn nên chọn phương pháp phù hợp hơn cho sản phẩm thực tế
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
