using System.Windows.Forms;

namespace ECManager
{
    partial class FormComponentDetail
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.ComboBox cboManufacturer;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnAddManufacturer;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboManufacturer = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            var tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.RowCount = 9;
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            for (int i = 0; i < 8; i++)
                tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));

            void AddRow(string labelText, System.Windows.Forms.Control control, int rowIndex)
            {
                var lbl = new System.Windows.Forms.Label();
                lbl.Text = labelText;
                lbl.Dock = System.Windows.Forms.DockStyle.Fill;
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                lbl.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
                control.Dock = System.Windows.Forms.DockStyle.Fill;
                tableLayoutPanel.Controls.Add(lbl, 0, rowIndex);
                tableLayoutPanel.Controls.Add(control, 1, rowIndex);
            }

            AddRow("Tên linh kiện:", txtName, 0);
            AddRow("Loại linh kiện:", cboCategory, 1);
            AddRow("Nhà sản xuất:", cboManufacturer, 2);
            AddRow("Số lượng:", txtQuantity, 3);
            AddRow("Đơn vị:", txtUnit, 4);
            AddRow("Giá tiền:", txtPrice, 5);
            AddRow("Vị trí:", txtLocation, 6);
            AddRow("Ghi chú:", txtNote, 7);

            var panelButtons = new System.Windows.Forms.Panel();
            panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;

            btnSave.Text = "Lưu";
            btnSave.Width = 80;
            btnSave.Height = 30;
            btnSave.Left = 0;
            btnSave.Top = 10;
            btnSave.Click += BtnSave_Click;

            btnCancel.Text = "Hủy";
            btnCancel.Width = 80;
            btnCancel.Height = 30;
            btnCancel.Left = btnSave.Right + 10;
            btnCancel.Top = 10;
            btnCancel.Click += BtnCancel_Click;

            panelButtons.Controls.Add(btnSave);
            panelButtons.Controls.Add(btnCancel);

            tableLayoutPanel.Controls.Add(panelButtons, 1, 8);

            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(tableLayoutPanel);
            this.Text = "Chi tiết linh kiện";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            txtNote.Multiline = true;
            txtNote.Height = 60;

            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboManufacturer.DropDownStyle = ComboBoxStyle.DropDownList;
            // btnAddCategory
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAddCategory.Text = "+";
            this.btnAddCategory.Size = new System.Drawing.Size(30, 23);
            this.btnAddCategory.Location = new System.Drawing.Point(cboCategory.Right + 5, cboCategory.Top);
            this.btnAddCategory.Click += new System.EventHandler(this.BtnAddCategory_Click);
            this.Controls.Add(this.btnAddCategory);

            // btnAddManufacturer
            this.btnAddManufacturer = new System.Windows.Forms.Button();
            this.btnAddManufacturer.Text = "+";
            this.btnAddManufacturer.Size = new System.Drawing.Size(30, 23);
            this.btnAddManufacturer.Location = new System.Drawing.Point(cboManufacturer.Right + 5, cboManufacturer.Top);
            this.btnAddManufacturer.Click += new System.EventHandler(this.BtnAddManufacturer_Click);
            this.Controls.Add(this.btnAddManufacturer);

        }
    }
}
