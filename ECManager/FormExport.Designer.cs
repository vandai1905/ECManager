using System.Windows.Forms;

namespace ECManager
{
    partial class FormExport
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvExportDetails;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpExportDate;
        private System.Windows.Forms.TextBox txtReceiver;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblNote;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvExportDetails = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpExportDate = new System.Windows.Forms.DateTimePicker();
            this.txtReceiver = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblReceiver = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvExportDetails)).BeginInit();
            this.SuspendLayout();

            // DGV
            this.dgvExportDetails.Location = new System.Drawing.Point(12, 120);
            this.dgvExportDetails.Size = new System.Drawing.Size(600, 250);
            this.dgvExportDetails.TabIndex = 0;

            // Labels & Controls
            this.lblReceiver.Text = "Người nhận:";
            this.lblReceiver.Location = new System.Drawing.Point(12, 15);
            this.txtReceiver.Location = new System.Drawing.Point(100, 12);
            this.txtReceiver.Width = 200;

            this.lblDate.Text = "Ngày xuất:";
            this.lblDate.Location = new System.Drawing.Point(320, 15);
            this.dtpExportDate.Location = new System.Drawing.Point(400, 12);

            this.lblNote.Text = "Ghi chú:";
            this.lblNote.Location = new System.Drawing.Point(12, 50);
            this.txtNote.Location = new System.Drawing.Point(100, 47);
            this.txtNote.Width = 500;

            // Buttons
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Location = new System.Drawing.Point(620, 120);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Location = new System.Drawing.Point(620, 160);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Location = new System.Drawing.Point(620, 200);
            this.btnSave.Text = "Lưu";
            this.btnSave.Location = new System.Drawing.Point(620, 240);

            // FormExport
            this.ClientSize = new System.Drawing.Size(720, 400);
            this.Controls.AddRange(new Control[] {
                this.dgvExportDetails, this.btnAdd, this.btnEdit, this.btnDelete, this.btnSave,
                this.dtpExportDate, this.txtReceiver, this.txtNote,
                this.lblReceiver, this.lblDate, this.lblNote
            });
            this.Text = "Phiếu xuất kho";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
