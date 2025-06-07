namespace ECManager
{
    partial class FormImport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.cboComponent = new System.Windows.Forms.ComboBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblComponent = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(110, 20);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 0;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(110, 50);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(300, 20);
            this.txtSupplier.TabIndex = 1;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(110, 80);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(300, 50);
            this.txtNote.TabIndex = 2;
            // 
            // cboComponent
            // 
            this.cboComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComponent.FormattingEnabled = true;
            this.cboComponent.Location = new System.Drawing.Point(110, 150);
            this.cboComponent.Name = "cboComponent";
            this.cboComponent.Size = new System.Drawing.Size(200, 21);
            this.cboComponent.TabIndex = 3;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(110, 180);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(100, 20);
            this.txtQty.TabIndex = 4;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(110, 210);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(100, 20);
            this.txtUnitPrice.TabIndex = 5;
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Location = new System.Drawing.Point(230, 207);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(80, 25);
            this.btnAddDetail.TabIndex = 6;
            this.btnAddDetail.Text = "Thêm";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(20, 250);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.Size = new System.Drawing.Size(560, 200);
            this.dgvDetails.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(410, 470);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(500, 470);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Labels
            // 
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDate.Text = "Ngày nhập:";
            this.lblDate.Location = new System.Drawing.Point(20, 20);
            this.lblDate.AutoSize = true;

            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblSupplier.Text = "Nhà cung cấp:";
            this.lblSupplier.Location = new System.Drawing.Point(20, 50);
            this.lblSupplier.AutoSize = true;

            this.lblNote = new System.Windows.Forms.Label();
            this.lblNote.Text = "Ghi chú:";
            this.lblNote.Location = new System.Drawing.Point(20, 80);
            this.lblNote.AutoSize = true;

            this.lblComponent = new System.Windows.Forms.Label();
            this.lblComponent.Text = "Linh kiện:";
            this.lblComponent.Location = new System.Drawing.Point(20, 150);
            this.lblComponent.AutoSize = true;

            this.lblQty = new System.Windows.Forms.Label();
            this.lblQty.Text = "Số lượng:";
            this.lblQty.Location = new System.Drawing.Point(20, 180);
            this.lblQty.AutoSize = true;

            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblUnitPrice.Text = "Đơn giá:";
            this.lblUnitPrice.Location = new System.Drawing.Point(20, 210);
            this.lblUnitPrice.AutoSize = true;

            // 
            // FormImport
            // 
            this.ClientSize = new System.Drawing.Size(600, 520);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.cboComponent);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.btnAddDetail);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblComponent);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lblUnitPrice);
            this.Name = "FormImport";
            this.Text = "Phiếu nhập kho";
            this.Load += new System.EventHandler(this.FormImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.ComboBox cboComponent;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblComponent;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblUnitPrice;
    }
}
