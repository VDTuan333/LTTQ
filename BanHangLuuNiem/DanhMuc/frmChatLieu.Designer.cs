namespace BanHangLuuNiem.DanhMuc
{
    partial class frmChatLieu
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
            txtTenChatLieu = new TextBox();
            txtMaChatLieu = new TextBox();
            lblTenChatLieu = new Label();
            lblMaChatLieu = new Label();
            groupBox2 = new GroupBox();
            btnThoat = new Button();
            btnBoQua = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnLuu = new Button();
            btnThem = new Button();
            dgvChatLieu = new DataGridView();
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChatLieu).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTenChatLieu);
            groupBox1.Controls.Add(txtMaChatLieu);
            groupBox1.Controls.Add(lblTenChatLieu);
            groupBox1.Controls.Add(lblMaChatLieu);
            groupBox1.Location = new Point(35, 142);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(951, 156);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // txtTenChatLieu
            // 
            txtTenChatLieu.Location = new Point(201, 93);
            txtTenChatLieu.Name = "txtTenChatLieu";
            txtTenChatLieu.Size = new Size(404, 27);
            txtTenChatLieu.TabIndex = 3;
            // 
            // txtMaChatLieu
            // 
            txtMaChatLieu.Location = new Point(201, 39);
            txtMaChatLieu.Name = "txtMaChatLieu";
            txtMaChatLieu.Size = new Size(404, 27);
            txtMaChatLieu.TabIndex = 2;
            // 
            // lblTenChatLieu
            // 
            lblTenChatLieu.AutoSize = true;
            lblTenChatLieu.Location = new Point(85, 93);
            lblTenChatLieu.Name = "lblTenChatLieu";
            lblTenChatLieu.Size = new Size(92, 20);
            lblTenChatLieu.TabIndex = 1;
            lblTenChatLieu.Text = "Tên chất liệu";
            // 
            // lblMaChatLieu
            // 
            lblMaChatLieu.AutoSize = true;
            lblMaChatLieu.Location = new Point(85, 39);
            lblMaChatLieu.Name = "lblMaChatLieu";
            lblMaChatLieu.Size = new Size(90, 20);
            lblMaChatLieu.TabIndex = 0;
            lblMaChatLieu.Text = "Mã chất liệu";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnThoat);
            groupBox2.Controls.Add(btnBoQua);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Controls.Add(btnLuu);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Location = new Point(1047, 142);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(198, 489);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(59, 419);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnBoQua
            // 
            btnBoQua.Location = new Point(59, 348);
            btnBoQua.Name = "btnBoQua";
            btnBoQua.Size = new Size(94, 29);
            btnBoQua.TabIndex = 4;
            btnBoQua.Text = "Bỏ Qua";
            btnBoQua.UseVisualStyleBackColor = true;
            btnBoQua.Click += btnBoQua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(59, 272);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(59, 197);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(59, 127);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(59, 59);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click_1;
            // 
            // dgvChatLieu
            // 
            dgvChatLieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChatLieu.Location = new Point(35, 304);
            dgvChatLieu.Name = "dgvChatLieu";
            dgvChatLieu.RowHeadersWidth = 51;
            dgvChatLieu.Size = new Size(951, 314);
            dgvChatLieu.TabIndex = 2;
            dgvChatLieu.CellClick += dgvChatLieu_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(449, 41);
            label1.Name = "label1";
            label1.Size = new Size(165, 20);
            label1.TabIndex = 3;
            label1.Text = "Danh Sách các chất liệu";
            // 
            // frmChatLieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 641);
            Controls.Add(label1);
            Controls.Add(dgvChatLieu);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmChatLieu";
            Text = "frmChatLieu";
            Load += frmChatLieu_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChatLieu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtTenChatLieu;
        private TextBox txtMaChatLieu;
        private Label lblTenChatLieu;
        private Label lblMaChatLieu;
        private GroupBox groupBox2;
       
        private DataGridView dgvChatLieu;
        private Label label1;
      
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnThoat;
        private Button btnBoQua;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLuu;
        private Button btnThem;
    }
}