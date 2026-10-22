using BanHangLuuNiem.Classes;
using BanHangLuuNiem.DanhMuc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BanHangLuuNiem
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string passw = txtMatKhau.Text;

            if (maNV == "" || passw == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên và mật khẩu!");
                return;
            }

            DataProcesser db = new DataProcesser();
            DataTable dt = db.KiemTraDangNhap(maNV, passw);

            if (dt.Rows.Count > 0)
            {
                // Lưu thông tin nhân viên đăng nhập
                PhienDangNhap.MaNV =
                    dt.Rows[0]["MaNV"].ToString() ?? "";

                PhienDangNhap.TenNV =
                    dt.Rows[0]["TenNV"].ToString() ?? "";

                MessageBox.Show(
                    "Đăng nhập thành công!\nXin chào " +
                    PhienDangNhap.TenNV
                );

                // Mở giao diện menu chính
                frmMain f = new frmMain();

                // Đóng form đăng nhập khi đóng form chính
                f.FormClosed += (s, args) => this.Close();

                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "Mã nhân viên hoặc mật khẩu không đúng!"
                );
            }

            dt.Dispose();
        }
    }
}
