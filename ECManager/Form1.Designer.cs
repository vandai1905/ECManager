namespace ECManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnComponents;
        private System.Windows.Forms.Button btnImports;
        private System.Windows.Forms.Button btnExports;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnExit;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnComponents = new System.Windows.Forms.Button();
            this.btnImports = new System.Windows.Forms.Button();
            this.btnExports = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(755, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PHẦN MỀM QUẢN LÝ LINH KIỆN ĐIỆN – ĐIỆN TỬ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnComponents
            // 
            this.btnComponents.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnComponents.Location = new System.Drawing.Point(270, 70);
            this.btnComponents.Name = "btnComponents";
            this.btnComponents.Size = new System.Drawing.Size(230, 40);
            this.btnComponents.TabIndex = 1;
            this.btnComponents.Text = "📦 Quản lý linh kiện";
            this.btnComponents.UseVisualStyleBackColor = true;
            this.btnComponents.Click += new System.EventHandler(this.btnComponents_Click);
            // 
            // btnImports
            // 
            this.btnImports.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnImports.Location = new System.Drawing.Point(270, 120);
            this.btnImports.Name = "btnImports";
            this.btnImports.Size = new System.Drawing.Size(230, 40);
            this.btnImports.TabIndex = 2;
            this.btnImports.Text = "📥 Phiếu nhập kho";
            this.btnImports.UseVisualStyleBackColor = true;
            this.btnImports.Click += new System.EventHandler(this.btnImports_Click);
            // 
            // btnExports
            // 
            this.btnExports.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExports.Location = new System.Drawing.Point(270, 170);
            this.btnExports.Name = "btnExports";
            this.btnExports.Size = new System.Drawing.Size(230, 40);
            this.btnExports.TabIndex = 3;
            this.btnExports.Text = "📤 Phiếu xuất kho";
            this.btnExports.UseVisualStyleBackColor = true;
            this.btnExports.Click += new System.EventHandler(this.btnExports_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnUsers.Location = new System.Drawing.Point(270, 220);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(230, 40);
            this.btnUsers.TabIndex = 4;
            this.btnUsers.Text = "👤 Quản lý người dùng";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExit.Location = new System.Drawing.Point(270, 270);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(230, 40);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "❌ Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 350);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnComponents);
            this.Controls.Add(this.btnImports);
            this.Controls.Add(this.btnExports);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chính - Quản lý linh kiện";
            this.ResumeLayout(false);

        }

        #endregion
    }
}

