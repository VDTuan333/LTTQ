using BanHangLuuNiem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BanHangLuuNiem.DanhMuc
{
    public partial class frmKhachHang : Form
    {
        DataProcesser dp = new DataProcesser();

        bool dangThem = false;
        bool dangSua = false;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            DataTable dt = dp.DocBang("SELECT * FROM tblKhach");
            dgvKhach.DataSource = dt;

            // Khóa các ô nhập khi mới mở Form
            txtMaKhach.Enabled = false;
            txtTenKhach.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;

            // Trạng thái các nút
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = false;
            btnThoat.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            // Xóa dữ liệu cũ
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";

            // Đang ở chế độ thêm
            dangThem = true;
            dangSua = false;

            // Cho phép nhập dữ liệu
            txtMaKhach.Enabled = true;
            txtTenKhach.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;

            // Bật các nút cần thiết
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;

            // Tắt các nút không cần thiết
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Đưa con trỏ vào ô mã khách
            txtMaKhach.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKhach.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khách!");
                txtMaKhach.Focus();
                return;
            }

            if (txtTenKhach.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách!");
                txtTenKhach.Focus();
                return;
            }

            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!");
                txtDiaChi.Focus();
                return;
            }

            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập điện thoại!");
                txtDienThoai.Focus();
                return;
            }

            // Nếu đang thêm
            if (dangThem == true)
            {
                string sql = "INSERT INTO tblKhach(Makhach, Tenkhach, Diachi, Dienthoai) VALUES ('" +
                             txtMaKhach.Text + "', N'" +
                             txtTenKhach.Text + "', N'" +
                             txtDiaChi.Text + "', '" +
                             txtDienThoai.Text + "')";

                dp.CapNhatDuLieu(sql);

                MessageBox.Show("Thêm khách hàng thành công!");
            }

            // Nếu đang sửa
            if (dangSua == true)
            {
                string sql = "UPDATE tblKhach SET " +
                             "Tenkhach = N'" + txtTenKhach.Text +
                             "', Diachi = N'" + txtDiaChi.Text +
                             "', Dienthoai = '" + txtDienThoai.Text +
                             "' WHERE Makhach = '" + txtMaKhach.Text + "'";

                dp.CapNhatDuLieu(sql);

                MessageBox.Show("Sửa khách hàng thành công!");
            }

            // Load lại dữ liệu
            DataTable dt = dp.DocBang("SELECT * FROM tblKhach");
            dgvKhach.DataSource = dt;

            // Xóa dữ liệu trên TextBox
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";

            // Khóa TextBox
            txtMaKhach.Enabled = false;
            txtTenKhach.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng cần sửa!");
                return;
            }

            // Chuyển sang chế độ sửa
            dangThem = false;
            dangSua = true;

            // Không cho sửa mã khách
            txtMaKhach.Enabled = false;

            // Cho phép sửa thông tin khách
            txtTenKhach.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;

            // Bật Lưu và Bỏ qua
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;

            // Tắt các nút khác
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtTenKhach.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa khách hàng này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblKhach WHERE Makhach = '" +
                             txtMaKhach.Text + "'";

                dp.CapNhatDuLieu(sql);

                MessageBox.Show("Xóa khách hàng thành công!");

                // Load lại dữ liệu
                DataTable dt = dp.DocBang("SELECT * FROM tblKhach");
                dgvKhach.DataSource = dt;

                // Xóa TextBox
                txtMaKhach.Text = "";
                txtTenKhach.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";

                // Khóa TextBox
                txtMaKhach.Enabled = false;
                txtTenKhach.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;

                // Trở về trạng thái ban đầu
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnBoQua.Enabled = false;
                btnThoat.Enabled = true;

                dangThem = false;
                dangSua = false;
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";

            txtMaKhach.Enabled = false;
            txtTenKhach.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;

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
            DialogResult result = MessageBox.Show(
               "Bạn có chắc chắn muốn thoát không?",
               "Xác nhận thoát",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaKhach.Text =
                    dgvKhach.Rows[e.RowIndex].Cells["Makhach"].Value.ToString();

                txtTenKhach.Text =
                    dgvKhach.Rows[e.RowIndex].Cells["Tenkhach"].Value.ToString();

                txtDiaChi.Text =
                    dgvKhach.Rows[e.RowIndex].Cells["Diachi"].Value.ToString();

                txtDienThoai.Text =
                    dgvKhach.Rows[e.RowIndex].Cells["Dienthoai"].Value.ToString();

                // Cho phép Sửa và Xóa
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
    }
}
