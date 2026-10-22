namespace BanHangLuuNiem.DanhMuc
{
    partial class frmKhachHang
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
            groupBox1 = new GroupBox();
            txtDienThoai = new TextBox();
            txtDiaChi = new TextBox();
            txtTenKhach = new TextBox();
            txtMaKhach = new TextBox();
            lblDienThoai = new Label();
            lblDiaChi = new Label();
            lblTenKhach = new Label();
            lblMaKhach = new Label();
            dgvKhach = new DataGridView();
            label5 = new Label();
            groupBox2 = new GroupBox();
            btnThoat = new Button();
            btnBoQua = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnLuu = new Button();
            btnThem = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhach).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtDienThoai);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(txtTenKhach);
            groupBox1.Controls.Add(txtMaKhach);
            groupBox1.Controls.Add(lblDienThoai);
            groupBox1.Controls.Add(lblDiaChi);
            groupBox1.Controls.Add(lblTenKhach);
            groupBox1.Controls.Add(lblMaKhach);
            groupBox1.Location = new Point(57, 60);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(770, 197);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(513, 130);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(239, 27);
            txtDienThoai.TabIndex = 7;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(513, 47);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(239, 27);
            txtDiaChi.TabIndex = 6;
            // 
            // txtTenKhach
            // 
            txtTenKhach.Location = new Point(128, 130);
            txtTenKhach.Name = "txtTenKhach";
            txtTenKhach.Size = new Size(239, 27);
            txtTenKhach.TabIndex = 5;
            // 
            // txtMaKhach
            // 
            txtMaKhach.Location = new Point(131, 47);
            txtMaKhach.Name = "txtMaKhach";
            txtMaKhach.Size = new Size(239, 27);
            txtMaKhach.TabIndex = 4;
            // 
            // lblDienThoai
            // 
            lblDienThoai.AutoSize = true;
            lblDienThoai.Location = new Point(429, 133);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(78, 20);
            lblDienThoai.TabIndex = 3;
            lblDienThoai.Text = "Điện thoại";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(429, 50);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(55, 20);
            lblDiaChi.TabIndex = 2;
            lblDiaChi.Text = "Địa chỉ";
            // 
            // lblTenKhach
            // 
            lblTenKhach.AutoSize = true;
            lblTenKhach.Location = new Point(53, 133);
            lblTenKhach.Name = "lblTenKhach";
            lblTenKhach.Size = new Size(74, 20);
            lblTenKhach.TabIndex = 1;
            lblTenKhach.Text = "Tên khách";
            // 
            // lblMaKhach
            // 
            lblMaKhach.AutoSize = true;
            lblMaKhach.Location = new Point(53, 50);
            lblMaKhach.Name = "lblMaKhach";
            lblMaKhach.Size = new Size(72, 20);
            lblMaKhach.TabIndex = 0;
            lblMaKhach.Text = "Mã khách";
            // 
            // dgvKhach
            // 
            dgvKhach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhach.Location = new Point(57, 263);
            dgvKhach.Name = "dgvKhach";
            dgvKhach.RowHeadersWidth = 51;
            dgvKhach.Size = new Size(770, 211);
            dgvKhach.TabIndex = 1;
            dgvKhach.CellClick += dgvKhach_CellClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(359, 22);
            label5.Name = "label5";
            label5.Size = new Size(182, 20);
            label5.TabIndex = 2;
            label5.Text = "Danh sách các khách hàng";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnThoat);
            groupBox2.Controls.Add(btnBoQua);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Controls.Add(btnLuu);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Location = new Point(57, 480);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(770, 104);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(635, 45);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnBoQua
            // 
            btnBoQua.Location = new Point(513, 45);
            btnBoQua.Name = "btnBoQua";
            btnBoQua.Size = new Size(94, 29);
            btnBoQua.TabIndex = 4;
            btnBoQua.Text = "Bỏ qua";
            btnBoQua.UseVisualStyleBackColor = true;
            btnBoQua.Click += btnBoQua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(390, 45);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(259, 45);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(145, 43);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(19, 41);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(106, 33);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // frmKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 610);
            Controls.Add(groupBox2);
            Controls.Add(label5);
            Controls.Add(dgvKhach);
            Controls.Add(groupBox1);
            Name = "frmKhachHang";
            Text = "frmKhachHang";
            Load += frmKhachHang_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhach).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtDienThoai;
        private TextBox txtDiaChi;
        private TextBox txtTenKhach;
        private TextBox txtMaKhach;
        private Label lblDienThoai;
        private Label lblDiaChi;
        private Label lblTenKhach;
        private Label lblMaKhach;
        private DataGridView dgvKhach;
        private Label label5;
        private GroupBox groupBox2;
        private Button btnBoQua;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLuu;
        private Button btnThem;
        private Button btnThoat;
    }
}