using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ECManager
{
    public partial class FormComponentDetail : Form
    {
        private int? componentId; // null = thêm mới, != null = sửa
        private string connectionString = connect.GetConnectionString();

        public FormComponentDetail(int? componentId = null)
        {
            InitializeComponent();
            this.componentId = componentId;
            LoadCategories();
            LoadManufacturers();

            if (componentId.HasValue)
            {
                LoadComponentData(componentId.Value);
            }
        }

        private void LoadCategories()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("SELECT category_id, name FROM categories", conn);
                var dt = new DataTable();

                try
                {
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());

                    cboCategory.DataSource = dt;
                    cboCategory.DisplayMember = "name";
                    cboCategory.ValueMember = "category_id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message);
                }
            }
        }

        private void LoadManufacturers()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("SELECT manufacturer_id, name FROM manufacturers", conn);
                var dt = new DataTable();

                try
                {
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());

                    cboManufacturer.DataSource = dt;
                    cboManufacturer.DisplayMember = "name";
                    cboManufacturer.ValueMember = "manufacturer_id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải nhà sản xuất: " + ex.Message);
                }
            }
        }
        private void LoadComponentData(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("SELECT * FROM components WHERE component_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader["name"].ToString();
                            cboCategory.SelectedValue = reader["category_id"];
                            cboManufacturer.SelectedValue = reader["manufacturer_id"];
                            txtQuantity.Text = reader["quantity"].ToString();
                            txtUnit.Text = reader["unit"].ToString();
                            txtPrice.Text = reader["price"].ToString();
                            txtLocation.Text = reader["location"].ToString();
                            txtNote.Text = reader["note"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy linh kiện.");
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu linh kiện: " + ex.Message);
                }
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu đơn giản
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên linh kiện.");
                txtName.Focus();
                return;
            }
            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại linh kiện.");
                cboCategory.Focus();
                return;
            }
            if (cboManufacturer.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà sản xuất.");
                cboManufacturer.Focus();
                return;
            }

            int quantity = 0;
            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên không âm.");
                txtQuantity.Focus();
                return;
            }

            decimal price = 0;
            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0)
            {
                MessageBox.Show("Giá tiền phải là số hợp lệ không âm.");
                txtPrice.Focus();
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    MySqlCommand cmd;
                    if (componentId.HasValue)
                    {
                        cmd = new MySqlCommand(@"UPDATE components SET
                name=@name, category_id=@catid, manufacturer_id=@manuid, quantity=@qty,
                unit=@unit, price=@price, location=@loc, note=@note
                WHERE component_id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", componentId.Value);
                    }
                    else
                    {
                        cmd = new MySqlCommand(@"INSERT INTO components
                (name, category_id, manufacturer_id, quantity, unit, price, location, note)
                VALUES (@name, @catid, @manuid, @qty, @unit, @price, @loc, @note)", conn);
                    }

                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@catid", cboCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@manuid", cboManufacturer.SelectedValue);
                    cmd.Parameters.AddWithValue("@qty", quantity);
                    cmd.Parameters.AddWithValue("@unit", txtUnit.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@loc", txtLocation.Text.Trim());
                    cmd.Parameters.AddWithValue("@note", txtNote.Text.Trim());

                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        MessageBox.Show("Lưu thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lưu không thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }
        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            string newCategory = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên loại linh kiện mới:", "Thêm loại linh kiện", "");

            if (!string.IsNullOrWhiteSpace(newCategory))
            {
                try
                {
                    using (var conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        var cmd = new MySqlCommand("INSERT INTO categories (name) VALUES (@name)", conn);
                        cmd.Parameters.AddWithValue("@name", newCategory);
                        cmd.ExecuteNonQuery();

                        LoadCategories(); // Reload danh sách
                        cboCategory.SelectedIndex = cboCategory.Items.Count - 1; // Chọn mục vừa thêm cuối cùng
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm loại linh kiện: " + ex.Message);
                }
            }
        }

        private void BtnAddManufacturer_Click(object sender, EventArgs e)
        {
            string newManufacturer = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên nhà sản xuất mới:", "Thêm nhà sản xuất", "");

            if (!string.IsNullOrWhiteSpace(newManufacturer))
            {
                try
                {
                    using (var conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        var cmd = new MySqlCommand("INSERT INTO manufacturers (name) VALUES (@name)", conn);
                        cmd.Parameters.AddWithValue("@name", newManufacturer);
                        cmd.ExecuteNonQuery();

                        LoadManufacturers(); // Reload danh sách
                        cboManufacturer.SelectedIndex = cboManufacturer.Items.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm nhà sản xuất: " + ex.Message);
                }
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
