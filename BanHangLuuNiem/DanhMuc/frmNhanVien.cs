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
    public partial class frmNhanVien : Form
    {
        DataProcesser dp = new DataProcesser();

        bool dangThem = false;
        bool dangSua = false;


        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            DataTable dt = dp.DocBang("SELECT * FROM tblNhanvien");
            dgvNhanVien.DataSource = dt;

            txtMaNhanVien.Enabled = false;
            txtTenNhanVien.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
            rdoNam.Enabled = false;
            rdoNu.Enabled = false;
            dtpNgaySinh.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = false;
            btnThoat.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";

            rdoNam.Checked = false;
            rdoNu.Checked = false;

            dangThem = true;
            dangSua = false;

            txtMaNhanVien.Enabled = true;
            txtTenNhanVien.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            rdoNam.Enabled = true;
            rdoNu.Enabled = true;
            dtpNgaySinh.Enabled = true;

            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaNhanVien.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã nhân viên
            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên!");
                txtMaNhanVien.Focus();
                return;
            }

            // Kiểm tra tên nhân viên
            if (txtTenNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên!");
                txtTenNhanVien.Focus();
                return;
            }

            // Kiểm tra giới tính
            if (rdoNam.Checked == false && rdoNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính!");
                return;
            }

            // Kiểm tra địa chỉ
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!");
                txtDiaChi.Focus();
                return;
            }

            // Kiểm tra điện thoại
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập điện thoại!");
                txtDienThoai.Focus();
                return;
            }

            string gioiTinh = "";

            if (rdoNam.Checked == true)
            {
                gioiTinh = "Nam";
            }
            else
            {
                gioiTinh = "Nữ";
            }

            // THÊM NHÂN VIÊN
            if (dangThem == true)
            {
                string sql = "INSERT INTO tblNhanvien " +
                             "(Manhanvien, Tennhanvien, Gioitinh, Diachi, Dienthoai, Ngaysinh) " +
                             "VALUES ('" +
                             txtMaNhanVien.Text + "', N'" +
                             txtTenNhanVien.Text + "', N'" +
                             gioiTinh + "', N'" +
                             txtDiaChi.Text + "', '" +
                             txtDienThoai.Text + "', '" +
                             dtpNgaySinh.Value.ToString("yyyy-MM-dd") + "')";

                dp.CapNhatDuLieu(sql);

                MessageBox.Show("Thêm nhân viên thành công!");
            }

            // SỬA NHÂN VIÊN
            if (dangSua == true)
            {
                string sql = "UPDATE tblNhanvien SET " +
                             "Tennhanvien = N'" + txtTenNhanVien.Text +
                             "', Gioitinh = N'" + gioiTinh +
                             "', Diachi = N'" + txtDiaChi.Text +
                             "', Dienthoai = '" + txtDienThoai.Text +
                             "', Ngaysinh = '" +
                             dtpNgaySinh.Value.ToString("yyyy-MM-dd") +
                             "' WHERE Manhanvien = '" +
                             txtMaNhanVien.Text + "'";

                dp.CapNhatDuLieu(sql);

                MessageBox.Show("Sửa nhân viên thành công!");
            }

            // Load lại dữ liệu
            DataTable dt = dp.DocBang("SELECT * FROM tblNhanvien");
            dgvNhanVien.DataSource = dt;

            // Xóa dữ liệu trên Form
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";

            rdoNam.Checked = false;
            rdoNu.Checked = false;

            // Khóa các Control
            txtMaNhanVien.Enabled = false;
            txtTenNhanVien.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
            rdoNam.Enabled = false;
            rdoNu.Enabled = false;
            dtpNgaySinh.Enabled = false;

            // Trạng thái nút
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = false;
            btnThoat.Enabled = true;

            dangThem = false;
            dangSua = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhân viên cần sửa!");
                return;
            }

            dangThem = false;
            dangSua = true;

            // Không cho sửa mã nhân viên
            txtMaNhanVien.Enabled = false;

            // Cho phép sửa các thông tin còn lại
            txtTenNhanVien.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            rdoNam.Enabled = true;
            rdoNu.Enabled = true;
            dtpNgaySinh.Enabled = true;

            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtTenNhanVien.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhân viên cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa nhân viên này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblNhanvien WHERE Manhanvien = '" +
                             txtMaNhanVien.Text + "'";

                dp.CapNhatDuLieu(sql);

                MessageBox.Show("Xóa nhân viên thành công!");

                // Load lại danh sách
                DataTable dt = dp.DocBang("SELECT * FROM tblNhanvien");
                dgvNhanVien.DataSource = dt;

                // Xóa dữ liệu trên Form
                txtMaNhanVien.Text = "";
                txtTenNhanVien.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";

                rdoNam.Checked = false;
                rdoNu.Checked = false;

                // Khóa các Control
                txtMaNhanVien.Enabled = false;
                txtTenNhanVien.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
                rdoNam.Enabled = false;
                rdoNu.Enabled = false;
                dtpNgaySinh.Enabled = false;

                // Trạng thái nút
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
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";

            rdoNam.Checked = false;
            rdoNu.Checked = false;

            txtMaNhanVien.Enabled = false;
            txtTenNhanVien.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
            rdoNam.Enabled = false;
            rdoNu.Enabled = false;
            dtpNgaySinh.Enabled = false;

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

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNhanVien.Text =
                    dgvNhanVien.Rows[e.RowIndex].Cells["Manhanvien"].Value.ToString();

                txtTenNhanVien.Text =
                    dgvNhanVien.Rows[e.RowIndex].Cells["Tennhanvien"].Value.ToString();

                string gioiTinh =
                    dgvNhanVien.Rows[e.RowIndex].Cells["Gioitinh"].Value.ToString();

                if (gioiTinh == "Nam")
                {
                    rdoNam.Checked = true;
                    rdoNu.Checked = false;
                }
                else
                {
                    rdoNam.Checked = false;
                    rdoNu.Checked = true;
                }

                txtDiaChi.Text =
                    dgvNhanVien.Rows[e.RowIndex].Cells["Diachi"].Value.ToString();

                txtDienThoai.Text =
                    dgvNhanVien.Rows[e.RowIndex].Cells["Dienthoai"].Value.ToString();

                dtpNgaySinh.Value =
                    Convert.ToDateTime(
                        dgvNhanVien.Rows[e.RowIndex].Cells["Ngaysinh"].Value
                    );

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
    }
}
