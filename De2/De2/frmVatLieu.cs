using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace De2
{
    public partial class frmVatLieu : Form
    {
        DataProcessor dp = new DataProcessor();
        string duongDanAnh = "";
        string maVLDangSua = "";

        public frmVatLieu()
        {
            InitializeComponent();
        }

        private void frmVatLieu_Load(object sender, EventArgs e)
        {
            try
            {
                dgvVatLieu.DataSource = dp.GetAllVatLieu();

                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                btnThem.Enabled = true;
                btnThoat.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh đại diện";
            openFileDialog.Filter= "File ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
        private void ChiChoNhapSo(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím Backspace
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            // Chỉ cho phép nhập số 0-9
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show(
                "ban co muon thoat khong",
                "xac nhan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra mã vật liệu
            if (txtMaVL.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã vật liệu!");
                txtMaVL.Focus();
                return;
            }

            // 2. Kiểm tra tên vật liệu
            if (txtTenVL.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên vật liệu!");
                txtTenVL.Focus();
                return;
            }

            // 3. Kiểm tra đơn vị tính
            if (txtDVT.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn vị tính!");
                txtDVT.Focus();
                return;
            }

            // 4. Kiểm tra giá nhập
            if (txtGiaNhap.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập giá nhập!");
                txtGiaNhap.Focus();
                return;
            }

            // 5. Kiểm tra giá bán
            if (txtGiaBan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập giá bán!");
                txtGiaBan.Focus();
                return;
            }

            // 6. Kiểm tra số lượng
            if (txtSoLuong.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng!");
                txtSoLuong.Focus();
                return;
            }

            // Lấy dữ liệu
            string maVL = txtMaVL.Text.Trim();
            string tenVL = txtTenVL.Text.Trim();
            string dvt = txtDVT.Text.Trim();
            string giaNhap = txtGiaNhap.Text.Trim();
            string giaBan = txtGiaBan.Text.Trim();
            int soLuong = int.Parse(txtSoLuong.Text.Trim());

            string anh = duongDanAnh;
            string ghiChu = txtGhiChu.Text.Trim();

            try
            {
                // 7. Kiểm tra mã có bị trùng không
                if (dp.KiemTraMaVL(maVL))
                {
                    MessageBox.Show(
                        "Mã vật liệu đã tồn tại! Vui lòng nhập mã khác.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMaVL.Focus();
                    txtMaVL.SelectAll();

                    return;
                }

                // 8. Không trùng → thêm vào Database
                dp.ThemVatLieu(
                    maVL,
                    tenVL,
                    dvt,
                    giaNhap,
                    giaBan,
                    soLuong,
                    anh,
                    ghiChu);

                MessageBox.Show(
                    "Thêm vật liệu thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // 9. Load lại dữ liệu lên lưới
                dgvVatLieu.DataSource = dp.GetAllVatLieu();

                // 10. Xóa trắng các ô
                txtMaVL.Clear();
                txtTenVL.Clear();
                txtDVT.Clear();
                txtGiaNhap.Clear();
                txtGiaBan.Clear();
                txtSoLuong.Clear();
                txtGhiChu.Clear();

                picAnh.Image = null;
                duongDanAnh = "";

                // Đưa con trỏ về mã vật liệu
                txtMaVL.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi thêm vật liệu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);  
            }
        }

        private void dgvVatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvVatLieu.Rows[e.RowIndex];

            txtMaVL.Text = row.Cells["MaVL"].Value?.ToString();
            txtTenVL.Text = row.Cells["TenVatLieu"].Value?.ToString();
            txtDVT.Text = row.Cells["DonViTinh"].Value?.ToString();
            txtGiaNhap.Text = row.Cells["GiaNhap"].Value?.ToString();
            txtGiaBan.Text = row.Cells["GiaBan"].Value?.ToString();
            txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();

            maVLDangSua = txtMaVL.Text;

            duongDanAnh = row.Cells["Anh"].Value?.ToString();

            if (duongDanAnh != "")
            {
                try
                {
                    picAnh.Image = Image.FromFile(duongDanAnh);
                }
                catch
                {
                    picAnh.Image = null;
                }
            }
            else
            {
                picAnh.Image = null;
            }

            // Khi chọn vật liệu thì cho phép Sửa và Xóa
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaVL.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn vật liệu cần sửa!");
                return;
            }

            if (txtTenVL.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên vật liệu!");
                txtTenVL.Focus();
                return;
            }

            if (txtDVT.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn vị tính!");
                txtDVT.Focus();
                return;
            }

            if (txtGiaNhap.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập giá nhập!");
                txtGiaNhap.Focus();
                return;
            }

            if (txtGiaBan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập giá bán!");
                txtGiaBan.Focus();
                return;
            }

            if (txtSoLuong.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng!");
                txtSoLuong.Focus();
                return;
            }

            try
            {
                string maVL = maVLDangSua;
                string tenVL = txtTenVL.Text.Trim();
                string dvt = txtDVT.Text.Trim();
                string giaNhap = txtGiaNhap.Text.Trim();
                string giaBan = txtGiaBan.Text.Trim();
                int soLuong = int.Parse(txtSoLuong.Text.Trim());
                string anh = duongDanAnh;
                string ghiChu = txtGhiChu.Text.Trim();

                // Gọi DataProcessor để cập nhật
                dp.SuaVatLieu(
                    maVL,
                    tenVL,
                    dvt,
                    giaNhap,
                    giaBan,
                    soLuong,
                    anh,
                    ghiChu);

                MessageBox.Show(
                    "Sửa vật liệu thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Hiển thị lại danh sách
                dgvVatLieu.DataSource = dp.GetAllVatLieu();

                // Xóa trắng các TextBox
                txtMaVL.Clear();
                txtTenVL.Clear();
                txtDVT.Clear();
                txtGiaNhap.Clear();
                txtGiaBan.Clear();
                txtSoLuong.Clear();
                txtGhiChu.Clear();

                // Xóa ảnh
                picAnh.Image = null;
                duongDanAnh = "";
                maVLDangSua = "";

                // Trạng thái các nút
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThem.Enabled = true;

                // Đưa con trỏ về mã vật liệu
                txtMaVL.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi sửa vật liệu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}