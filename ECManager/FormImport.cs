using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ECManager
{
    public partial class FormImport : Form
    {
        private DataTable detailTable;

        public FormImport()
        {
            InitializeComponent();
            InitDetailTable();
        }

        private void FormImport_Load(object sender, EventArgs e)
        {
            LoadComponents();
            dgvDetails.DataSource = detailTable;
        }

        private void InitDetailTable()
        {
            detailTable = new DataTable();
            detailTable.Columns.Add("component_id", typeof(int));
            detailTable.Columns.Add("name", typeof(string));
            detailTable.Columns.Add("quantity", typeof(int));
            detailTable.Columns.Add("unit_price", typeof(decimal));
        }

        private void LoadComponents()
        {
            using (var conn = new MySqlConnection(connect.GetConnectionString()))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT component_id, name FROM components", conn);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                cboComponent.DataSource = dt;
                cboComponent.DisplayMember = "name";
                cboComponent.ValueMember = "component_id";
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (cboComponent.SelectedItem == null || string.IsNullOrWhiteSpace(txtQty.Text) || string.IsNullOrWhiteSpace(txtUnitPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin chi tiết.");
                return;
            }

            DataRow row = detailTable.NewRow();
            row["component_id"] = cboComponent.SelectedValue;
            row["name"] = ((DataRowView)cboComponent.SelectedItem)["name"].ToString();
            row["quantity"] = int.Parse(txtQty.Text);
            row["unit_price"] = decimal.Parse(txtUnitPrice.Text);
            detailTable.Rows.Add(row);

            txtQty.Clear();
            txtUnitPrice.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (detailTable.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có chi tiết nhập kho.");
                return;
            }

            using (var conn = new MySqlConnection(connect.GetConnectionString()))
            {
                conn.Open();
                var trans = conn.BeginTransaction();

                try
                {
                    // Insert into imports
                    string sqlImport = "INSERT INTO imports (date, supplier, note) VALUES (@date, @supplier, @note)";
                    var cmdImport = new MySqlCommand(sqlImport, conn, trans);
                    cmdImport.Parameters.AddWithValue("@date", dtpDate.Value.Date);
                    cmdImport.Parameters.AddWithValue("@supplier", txtSupplier.Text);
                    cmdImport.Parameters.AddWithValue("@note", txtNote.Text);
                    cmdImport.ExecuteNonQuery();
                    long importId = cmdImport.LastInsertedId;

                    // Insert into import_details
                    foreach (DataRow row in detailTable.Rows)
                    {
                        string sqlDetail = @"INSERT INTO import_details (import_id, component_id, quantity, unit_price)
                                            VALUES (@import_id, @component_id, @quantity, @unit_price)";
                        var cmdDetail = new MySqlCommand(sqlDetail, conn, trans);
                        cmdDetail.Parameters.AddWithValue("@import_id", importId);
                        cmdDetail.Parameters.AddWithValue("@component_id", row["component_id"]);
                        cmdDetail.Parameters.AddWithValue("@quantity", row["quantity"]);
                        cmdDetail.Parameters.AddWithValue("@unit_price", row["unit_price"]);
                        cmdDetail.ExecuteNonQuery();

                        // Cập nhật tồn kho
                        var updateCmd = new MySqlCommand("UPDATE components SET quantity = quantity + @addQty WHERE component_id = @cid", conn, trans);
                        updateCmd.Parameters.AddWithValue("@addQty", row["quantity"]);
                        updateCmd.Parameters.AddWithValue("@cid", row["component_id"]);
                        updateCmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show("Lưu phiếu nhập thành công!");
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi khi lưu: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
