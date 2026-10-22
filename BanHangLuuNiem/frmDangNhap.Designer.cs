namespace BanHangLuuNiem
{
    partial class frmDangNhap
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
            txtMaNV = new TextBox();
            txtMatKhau = new TextBox();
            button1 = new Button();
            btnDangNhap = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtMaNV
            // 
            txtMaNV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMaNV.Location = new Point(370, 207);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.PlaceholderText = "Tên Đăng Nhập";
            txtMaNV.Size = new Size(291, 41);
            txtMaNV.TabIndex = 2;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMatKhau.Location = new Point(370, 293);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.PlaceholderText = "Mật Khẩu";
            txtMatKhau.RightToLeft = RightToLeft.No;
            txtMatKhau.Size = new Size(291, 41);
            txtMatKhau.TabIndex = 3;
            txtMatKhau.Tag = "";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.Transparent;
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(574, 392);
            button1.Name = "button1";
            button1.Size = new Size(156, 50);
            button1.TabIndex = 4;
            button1.Text = "&Thoát";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDangNhap.BackColor = Color.Transparent;
            btnDangNhap.ForeColor = SystemColors.ActiveCaptionText;
            btnDangNhap.Location = new Point(321, 392);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(156, 50);
            btnDangNhap.TabIndex = 5;
            btnDangNhap.Text = "&Đăng Nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(txtMaNV);
            groupBox1.Controls.Add(btnDangNhap);
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1076, 644);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._2021021012300413606;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1076, 644);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 15F);
            ForeColor = SystemColors.Control;
            Margin = new Padding(5);
            Name = "frmDangNhap";
            Text = "frmDangNhap";
            Load += frmDangNhap_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtMaNV;
        private TextBox txtMatKhau;
        private Button button1;
        private Button btnDangNhap;
        private GroupBox groupBox1;
    }
}