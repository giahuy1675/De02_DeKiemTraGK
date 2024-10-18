namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.cboLoaiSP = new System.Windows.Forms.ComboBox();
            this.lvSanpham = new System.Windows.Forms.ListView();
            this.dtNgaynhap = new System.Windows.Forms.DateTimePicker();
            this.bt_Them = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btTim = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.bt_Luu = new System.Windows.Forms.Button();
            this.bt_KhongLuu = new System.Windows.Forms.Button();
            this.bt_LoadLaiDuLieu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(824, 88);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(160, 22);
            this.txtMaSP.TabIndex = 0;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(824, 120);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(160, 22);
            this.txtTenSP.TabIndex = 2;
            // 
            // cboLoaiSP
            // 
            this.cboLoaiSP.FormattingEnabled = true;
            this.cboLoaiSP.Location = new System.Drawing.Point(824, 160);
            this.cboLoaiSP.Name = "cboLoaiSP";
            this.cboLoaiSP.Size = new System.Drawing.Size(160, 24);
            this.cboLoaiSP.TabIndex = 3;
            // 
            // lvSanpham
            // 
            this.lvSanpham.HideSelection = false;
            this.lvSanpham.Location = new System.Drawing.Point(16, 80);
            this.lvSanpham.Name = "lvSanpham";
            this.lvSanpham.Size = new System.Drawing.Size(736, 208);
            this.lvSanpham.TabIndex = 4;
            this.lvSanpham.UseCompatibleStateImageBehavior = false;
            this.lvSanpham.SelectedIndexChanged += new System.EventHandler(this.lvSanpham_SelectedIndexChanged);
            // 
            // dtNgaynhap
            // 
            this.dtNgaynhap.Location = new System.Drawing.Point(784, 224);
            this.dtNgaynhap.Name = "dtNgaynhap";
            this.dtNgaynhap.Size = new System.Drawing.Size(200, 22);
            this.dtNgaynhap.TabIndex = 5;
            // 
            // bt_Them
            // 
            this.bt_Them.Location = new System.Drawing.Point(16, 304);
            this.bt_Them.Name = "bt_Them";
            this.bt_Them.Size = new System.Drawing.Size(120, 39);
            this.bt_Them.TabIndex = 6;
            this.bt_Them.Text = "Thêm";
            this.bt_Them.UseVisualStyleBackColor = true;
            this.bt_Them.Click += new System.EventHandler(this.bt_Them_Click);
            // 
            // btSua
            // 
            this.btSua.Location = new System.Drawing.Point(136, 304);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(120, 39);
            this.btSua.TabIndex = 7;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(256, 304);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(120, 39);
            this.btXoa.TabIndex = 8;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(24, 32);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(176, 22);
            this.txtTim.TabIndex = 9;
            // 
            // btTim
            // 
            this.btTim.Location = new System.Drawing.Point(208, 32);
            this.btTim.Name = "btTim";
            this.btTim.Size = new System.Drawing.Size(88, 23);
            this.btTim.TabIndex = 10;
            this.btTim.Text = "Tìm";
            this.btTim.UseVisualStyleBackColor = true;
            this.btTim.Click += new System.EventHandler(this.btTim_Click);
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(376, 304);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(120, 39);
            this.btThoat.TabIndex = 11;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // bt_Luu
            // 
            this.bt_Luu.Location = new System.Drawing.Point(496, 304);
            this.bt_Luu.Name = "bt_Luu";
            this.bt_Luu.Size = new System.Drawing.Size(120, 39);
            this.bt_Luu.TabIndex = 12;
            this.bt_Luu.Text = "Lưu";
            this.bt_Luu.UseVisualStyleBackColor = true;
            this.bt_Luu.Click += new System.EventHandler(this.bt_Luu_Click);
            // 
            // bt_KhongLuu
            // 
            this.bt_KhongLuu.Location = new System.Drawing.Point(616, 304);
            this.bt_KhongLuu.Name = "bt_KhongLuu";
            this.bt_KhongLuu.Size = new System.Drawing.Size(120, 39);
            this.bt_KhongLuu.TabIndex = 13;
            this.bt_KhongLuu.Text = "Không lưu";
            this.bt_KhongLuu.UseVisualStyleBackColor = true;
            this.bt_KhongLuu.Click += new System.EventHandler(this.bt_KhongLuu_Click);
            // 
            // bt_LoadLaiDuLieu
            // 
            this.bt_LoadLaiDuLieu.Location = new System.Drawing.Point(16, 352);
            this.bt_LoadLaiDuLieu.Name = "bt_LoadLaiDuLieu";
            this.bt_LoadLaiDuLieu.Size = new System.Drawing.Size(120, 39);
            this.bt_LoadLaiDuLieu.TabIndex = 14;
            this.bt_LoadLaiDuLieu.Text = "Load dữ liệu";
            this.bt_LoadLaiDuLieu.UseVisualStyleBackColor = true;
            this.bt_LoadLaiDuLieu.Click += new System.EventHandler(this.bt_LoadLaiDuLieu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(768, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mã SP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(760, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tên SP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(760, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ngày nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(760, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Loại SP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 395);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_LoadLaiDuLieu);
            this.Controls.Add(this.bt_KhongLuu);
            this.Controls.Add(this.bt_Luu);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btTim);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.bt_Them);
            this.Controls.Add(this.dtNgaynhap);
            this.Controls.Add(this.lvSanpham);
            this.Controls.Add(this.cboLoaiSP);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.txtMaSP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.ListView lvSanpham;
        private System.Windows.Forms.DateTimePicker dtNgaynhap;
        private System.Windows.Forms.Button bt_Them;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btTim;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button bt_Luu;
        private System.Windows.Forms.Button bt_KhongLuu;
        private System.Windows.Forms.Button bt_LoadLaiDuLieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

