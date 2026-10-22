namespace BanHangLuuNiem
{
    partial class frmMain
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
            menuStrip1 = new MenuStrip();
            danhMụcToolStripMenuItem = new ToolStripMenuItem();
            chấtLiệuToolStripMenuItem = new ToolStripMenuItem();
            nhânViênToolStripMenuItem = new ToolStripMenuItem();
            kháchHàngToolStripMenuItem = new ToolStripMenuItem();
            mnuHangHoa = new ToolStripMenuItem();
            mnuHoaDon = new ToolStripMenuItem();
            tìmKiếmToolStripMenuItem = new ToolStripMenuItem();
            báoCáoToolStripMenuItem = new ToolStripMenuItem();
            trợGiúpToolStripMenuItem = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { danhMụcToolStripMenuItem, mnuHoaDon, tìmKiếmToolStripMenuItem, báoCáoToolStripMenuItem, trợGiúpToolStripMenuItem, mnuThoat });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(940, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // danhMụcToolStripMenuItem
            // 
            danhMụcToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chấtLiệuToolStripMenuItem, nhânViênToolStripMenuItem, kháchHàngToolStripMenuItem, mnuHangHoa });
            danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            danhMụcToolStripMenuItem.Size = new Size(94, 24);
            danhMụcToolStripMenuItem.Text = "Danh mục ";
            // 
            // chấtLiệuToolStripMenuItem
            // 
            chấtLiệuToolStripMenuItem.Name = "chấtLiệuToolStripMenuItem";
            chấtLiệuToolStripMenuItem.Size = new Size(169, 26);
            chấtLiệuToolStripMenuItem.Text = "Chất liệu";
            // 
            // nhânViênToolStripMenuItem
            // 
            nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            nhânViênToolStripMenuItem.Size = new Size(169, 26);
            nhânViênToolStripMenuItem.Text = "Nhân viên";
            // 
            // kháchHàngToolStripMenuItem
            // 
            kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            kháchHàngToolStripMenuItem.Size = new Size(169, 26);
            kháchHàngToolStripMenuItem.Text = "Khách hàng";
            // 
            // mnuHangHoa
            // 
            mnuHangHoa.Name = "mnuHangHoa";
            mnuHangHoa.Size = new Size(169, 26);
            mnuHangHoa.Text = "Hàng hóa";
            mnuHangHoa.Click += mnuHangHoa_Click;
            // 
            // mnuHoaDon
            // 
            mnuHoaDon.Name = "mnuHoaDon";
            mnuHoaDon.Size = new Size(81, 24);
            mnuHoaDon.Text = "Hóa đơn";
            mnuHoaDon.Click += mnuHoaDon_Click;
            // 
            // tìmKiếmToolStripMenuItem
            // 
            tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            tìmKiếmToolStripMenuItem.Size = new Size(84, 24);
            tìmKiếmToolStripMenuItem.Text = "Tìm kiếm";
            // 
            // báoCáoToolStripMenuItem
            // 
            báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            báoCáoToolStripMenuItem.Size = new Size(77, 24);
            báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // trợGiúpToolStripMenuItem
            // 
            trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            trợGiúpToolStripMenuItem.Size = new Size(78, 24);
            trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Size = new Size(61, 24);
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._825278508_1071353289054726_7660851126808406343_n;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(940, 563);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            Text = "Chương trình quản lý bán hàng lưu niệm";
            Load += frmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem danhMụcToolStripMenuItem;
        private ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private ToolStripMenuItem chấtLiệuToolStripMenuItem;
        private ToolStripMenuItem nhânViênToolStripMenuItem;
        private ToolStripMenuItem kháchHàngToolStripMenuItem;
        private ToolStripMenuItem mnuHoaDon;
        private ToolStripMenuItem báoCáoToolStripMenuItem;
        private ToolStripMenuItem trợGiúpToolStripMenuItem;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuHangHoa;
    }
}