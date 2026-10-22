using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BanHangLuuNiem.Classes;
namespace BanHangLuuNiem.DanhMuc
{
    public partial class frmChatLieu : Form
    {
        DataProcesser dp = new DataProcesser();
        bool dangThem = false;
        bool dangSua = false;

        public frmChatLieu()
        {
            InitializeComponent();
        }


        // Sự Kiện Load -----------------------------------------------------------------------

        private void frmChatLieu_Load(object sender, EventArgs e)
        {
            DataTable dt = dp.DocBang("SELECT * FROM tblChatlieu");
            dgvChatLieu.DataSource = dt;

            // Không cho nhập khi mới mở form
            txtMaChatLieu.Enabled = false;
            txtTenChatLieu.Enabled = false;

            // Trạng thái các nút
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = false;
            btnThoat.Enabled = true;
        }


        // Nút Thêm --------------------------------------------------------------------------

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";

            // Đang ở chế độ thêm
            dangThem = true;
            dangSua = false;

            // Cho phép nhập
            txtMaChatLieu.Enabled = true;
            txtTenChatLieu.Enabled = true;

            // Bật các nút cần thiết
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;

            // Tắt các nút không cần thiết
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaChatLieu.Focus();
        }

        // Nút Lưu --------------------------------------------------------------------------
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaChatLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã chất liệu!");
                txtMaChatLieu.Focus();
                return;
            }

            if (txtTenChatLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu!");
                txtTenChatLieu.Focus();
                return;
            }

            // Nếu đang thêm
            if (dangThem == true)
            {
                string sql = "INSERT INTO tblChatlieu(MaChatLieu, TenChatLieu) VALUES ('" +
                             txtMaChatLieu.Text + "', N'" +
                             txtTenChatLieu.Text + "')";

                dp.CapNhatDuLieu(sql);

                MessageBox.Show("Thêm chất liệu thành công!");
            }

            // Nếu đang sửa
            if (dangSua == true)
            {
                string sql = "UPDATE tblChatlieu SET TenChatLieu = N'" +
                             txtTenChatLieu.Text +
                             "' WHERE MaChatLieu = '" +
                             txtMaChatLieu.Text + "'";

                dp.CapNhatDuLieu(sql);

                MessageBox.Show("Sửa chất liệu thành công!");
            }

            // Load lại dữ liệu
            DataTable dt = dp.DocBang("SELECT * FROM tblChatlieu");
            dgvChatLieu.DataSource = dt;

            // Xóa nội dung TextBox
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";

            // Khóa TextBox
            txtMaChatLieu.Enabled = false;
            txtTenChatLieu.Enabled = false;

            // Trở về trạng thái ban đầu
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = false;
            btnThoat.Enabled = true;

            // Reset trạng thái
            dangThem = false;
            dangSua = false;
        }

        // Nút Sửa --------------------------------------------------------------------------

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaChatLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn chất liệu cần sửa!");
                return;
            }

            // Đang ở chế độ sửa
            dangThem = false;
            dangSua = true;

            // Chỉ cho sửa tên
            txtMaChatLieu.Enabled = false;
            txtTenChatLieu.Enabled = true;

            // Bật Lưu và Bỏ qua
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;

            // Tắt các nút khác
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtTenChatLieu.Focus();
        }

        // Nút Xóa --------------------------------------------------------------------

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaChatLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn chất liệu cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa chất liệu này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblChatlieu WHERE MaChatLieu = '" +
                             txtMaChatLieu.Text + "'";

                dp.CapNhatDuLieu(sql);

                MessageBox.Show("Xóa chất liệu thành công!");

                DataTable dt = dp.DocBang("SELECT * FROM tblChatlieu");
                dgvChatLieu.DataSource = dt;

                txtMaChatLieu.Text = "";
                txtTenChatLieu.Text = "";

                txtMaChatLieu.Enabled = false;
                txtTenChatLieu.Enabled = false;

                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnBoQua.Enabled = false;

                dangThem = false;
                dangSua = false;
            }
        }

        // Nút Bỏ qua -------------------------------------------------------------------

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";

            txtMaChatLieu.Enabled = false;
            txtTenChatLieu.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = false;
            btnThoat.Enabled = true;

            dangThem = false;
            dangSua = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        // Kiểm tra chọn dòng ---------------------------------------------------------------

        private void dgvChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaChatLieu.Text =
                    dgvChatLieu.Rows[e.RowIndex].Cells["MaChatLieu"].Value.ToString();

                txtTenChatLieu.Text =
                    dgvChatLieu.Rows[e.RowIndex].Cells["TenChatLieu"].Value.ToString();

                // Cho phép Sửa và Xóa
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
    }
}
