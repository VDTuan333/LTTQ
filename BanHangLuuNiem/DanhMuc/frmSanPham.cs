using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BanHangLuuNiem.DanhMuc
{
    public partial class frmSanPham : Form
    {

        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        Classes.Function ft = new Classes.Function();
        string fileAnh = "";

        bool dangThem = false;
        bool dangSua = false;

        public frmSanPham()
        {
            InitializeComponent();
        }



        private void frmSanPham_Load(object sender, EventArgs e)
        {

            // Lấy dữ liệu bảng Chất liệu đổ vào cboChatLieu
            DataTable dtChatLieu = dtBase.DocBang("Select * from tblChatLieu");

            ft.FillComBox(
                cboChatLieu,
                dtChatLieu,
                "TenChatLieu",
                "MaChatLieu"
            );

            cboChatLieu.SelectedIndex = -1;

            // Load dữ liệu lên dgvHang
            DataTable dtHang = dtBase.DocBang("SELECT * FROM tblHang");

            dgvHang.DataSource = dtHang;

            dgvHang.ReadOnly = true;

            // Định dạng DataGridView
            dgvHang.Columns[0].HeaderText = "Mã hàng";
            dgvHang.Columns[1].HeaderText = "Tên hàng";
            dgvHang.Columns[2].HeaderText = "Mã CL";
            dgvHang.Columns[3].HeaderText = "Số lượng";
            dgvHang.Columns[4].HeaderText = "Giá nhập";
            dgvHang.Columns[5].HeaderText = "Giá bán";
            dgvHang.Columns[6].HeaderText = "File ảnh";

            dgvHang.Columns[0].Width = 150;
            dgvHang.Columns[1].Width = 250;
            dgvHang.Columns[2].Width = 150;
            dgvHang.Columns[3].Width = 150;
            dgvHang.Columns[4].Width = 150;
            dgvHang.Columns[5].Width = 150;
            dgvHang.Columns[6].Width = 150;

            dgvHang.BackgroundColor = Color.LightBlue;

            dtHang.Dispose();
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgAnh = new OpenFileDialog();

            dlgAnh.Filter =
                "Ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files (*.*)|*.*";

            dlgAnh.InitialDirectory = Application.StartupPath;
            dlgAnh.FilterIndex = 1;
            dlgAnh.Title = "Chọn ảnh để hiển thị";

            if (dlgAnh.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgAnh.FileName);

                string[] str = dlgAnh.FileName.Split('\\');
                fileAnh = str[str.Length - 1];
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            // Nếu không nhập mã hàng thì hiển thị lại toàn bộ danh sách
            if (txtMaHang.Text == "")
            {
                DataTable dtHang = dtBase.DocBang("SELECT * FROM tblHang");
                dgvHang.DataSource = dtHang;

                // Xóa thông tin trên Form
                txtTenHang.Text = "";
                cboChatLieu.SelectedIndex = -1;
                txtSoLuong.Text = "";
                txtDonGiaNhap.Text = "";
                txtDonGiaBan.Text = "";
                txtGhiChu.Text = "";
                picAnh.Image = null;
                fileAnh = "";

                return;
            }

            // Lấy mã hàng cần tìm
            string maHang = txtMaHang.Text;

            // Tìm sản phẩm
            string sql = "SELECT * FROM tblHang " +
                         "WHERE MaHang = N'" + maHang + "'";

            DataTable dtHangTim = dtBase.DocBang(sql);

            // Kiểm tra kết quả
            if (dtHangTim.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!");
            }
            else
            {
                dgvHang.DataSource = dtHangTim;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại chọn nơi lưu file
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "Excel CSV (*.csv)|*.csv";
            saveFile.Title = "Lưu danh sách hàng";
            saveFile.FileName = "DanhSachHang.csv";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                // Tạo file
                using (System.IO.StreamWriter sw =
                       new System.IO.StreamWriter(saveFile.FileName, false,
                       System.Text.Encoding.UTF8))
                {
                    // Ghi tên các cột
                    for (int i = 0; i < dgvHang.Columns.Count; i++)
                    {
                        sw.Write(dgvHang.Columns[i].HeaderText);

                        if (i < dgvHang.Columns.Count - 1)
                            sw.Write(",");
                    }

                    sw.WriteLine();

                    // Ghi dữ liệu từng dòng
                    for (int i = 0; i < dgvHang.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvHang.Columns.Count; j++)
                        {
                            if (dgvHang.Rows[i].Cells[j].Value != null)
                            {
                                sw.Write(dgvHang.Rows[i].Cells[j].Value.ToString());
                            }

                            if (j < dgvHang.Columns.Count - 1)
                                sw.Write(",");
                        }

                        sw.WriteLine();
                    }
                }

                MessageBox.Show(
                    "Xuất danh sách hàng thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            dangThem = true;
            dangSua = false;


            // Xóa dữ liệu cũ
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            cboChatLieu.SelectedIndex = -1;
            txtSoLuong.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            txtGhiChu.Text = "";

            // Xóa ảnh
            picAnh.Image = null;
            fileAnh = "";

            // Cho phép nhập dữ liệu
            txtMaHang.Enabled = true;
            txtTenHang.Enabled = true;
            cboChatLieu.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtGhiChu.Enabled = true;
            btnAnh.Enabled = true;

            // Thiết lập trạng thái các nút
            btnThemMoi.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnThoat.Enabled = true;

            // Đưa con trỏ vào ô Mã hàng
            txtMaHang.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            // Kiểm tra dữ liệu
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hàng!");
                txtMaHang.Focus();
                return;
            }

            if (txtTenHang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên hàng!");
                txtTenHang.Focus();
                return;
            }

            if (cboChatLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn chất liệu!");
                cboChatLieu.Focus();
                return;
            }

            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng!");
                txtSoLuong.Focus();
                return;
            }

            if (txtDonGiaNhap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá nhập!");
                txtDonGiaNhap.Focus();
                return;
            }

            if (txtDonGiaBan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá bán!");
                txtDonGiaBan.Focus();
                return;
            }

            string maHang = txtMaHang.Text;
            string tenHang = txtTenHang.Text;
            string maChatLieu = cboChatLieu.SelectedValue.ToString();
            string soLuong = txtSoLuong.Text;
            string donGiaNhap = txtDonGiaNhap.Text;
            string donGiaBan = txtDonGiaBan.Text;
            string ghiChu = txtGhiChu.Text;

            // Nếu đang thêm mới
            if (dangThem == true)
            {
                string sql = "INSERT INTO tblHang " +
                             "(MaHang, TenHang, MaChatLieu, Soluong, Dongianhap, Dongiaban, Anh, GhiChu) " +
                             "VALUES (" +
                             "N'" + maHang + "', " +
                             "N'" + tenHang + "', " +
                             "N'" + maChatLieu + "', " +
                             soLuong + ", " +
                             donGiaNhap + ", " +
                             donGiaBan + ", " +
                             "N'" + fileAnh + "', " +
                             "N'" + ghiChu + "')";

                dtBase.CapNhatDuLieu(sql);

                MessageBox.Show("Thêm hàng thành công!");
            }

            // Nếu đang sửa
            if (dangSua == true)
            {
                string sql = "UPDATE tblHang SET " +
                             "TenHang = N'" + tenHang + "', " +
                             "MaChatLieu = N'" + maChatLieu + "', " +
                             "Soluong = " + soLuong + ", " +
                             "Dongianhap = " + donGiaNhap + ", " +
                             "Dongiaban = " + donGiaBan + ", " +
                             "Anh = N'" + fileAnh + "', " +
                             "GhiChu = N'" + ghiChu + "' " +
                             "WHERE MaHang = N'" + maHang + "'";

                dtBase.CapNhatDuLieu(sql);

                MessageBox.Show("Sửa hàng thành công!");
            }

            // Load lại dữ liệu
            DataTable dtHang = dtBase.DocBang("SELECT * FROM tblHang");
            dgvHang.DataSource = dtHang;

            // Đưa Form về trạng thái ban đầu
            txtMaHang.Enabled = false;
            txtTenHang.Enabled = false;
            cboChatLieu.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtGhiChu.Enabled = false;
            btnAnh.Enabled = false;

            btnThemMoi.Enabled = true;
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
            // Kiểm tra đã chọn sản phẩm chưa
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần sửa!");
                return;
            }

            dangThem = false;
            dangSua = true;

            // Cho phép sửa thông tin
            txtMaHang.Enabled = false;
            txtTenHang.Enabled = true;
            cboChatLieu.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtGhiChu.Enabled = true;
            btnAnh.Enabled = true;

            // Thiết lập trạng thái các nút
            btnThemMoi.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnThoat.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn sản phẩm chưa
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần xóa!");
                return;
            }

            // Hỏi xác nhận trước khi xóa
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sản phẩm này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maHang = txtMaHang.Text;

                string sql = "DELETE FROM tblHang " +
                             "WHERE MaHang = N'" + maHang + "'";

                dtBase.CapNhatDuLieu(sql);

                MessageBox.Show("Xóa hàng thành công!");

                // Load lại dữ liệu
                DataTable dtHang = dtBase.DocBang("SELECT * FROM tblHang");
                dgvHang.DataSource = dtHang;

                // Xóa dữ liệu trên Form
                txtMaHang.Text = "";
                txtTenHang.Text = "";
                cboChatLieu.SelectedIndex = -1;
                txtSoLuong.Text = "";
                txtDonGiaNhap.Text = "";
                txtDonGiaBan.Text = "";
                txtGhiChu.Text = "";
                picAnh.Image = null;
                fileAnh = "";

                // Khóa các ô nhập
                txtMaHang.Enabled = false;
                txtTenHang.Enabled = false;
                cboChatLieu.Enabled = false;
                txtSoLuong.Enabled = false;
                txtDonGiaNhap.Enabled = false;
                txtDonGiaBan.Enabled = false;
                txtGhiChu.Enabled = false;
                btnAnh.Enabled = false;

                // Thiết lập lại trạng thái nút
                btnThemMoi.Enabled = true;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnBoQua.Enabled = false;
                btnThoat.Enabled = true;
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu trên Form
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            cboChatLieu.SelectedIndex = -1;
            txtSoLuong.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            txtGhiChu.Text = "";

            // Xóa ảnh
            picAnh.Image = null;
            fileAnh = "";

            // Khóa các ô nhập
            txtMaHang.Enabled = false;
            txtTenHang.Enabled = false;
            cboChatLieu.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtGhiChu.Enabled = false;
            btnAnh.Enabled = false;

            // Đưa các nút về trạng thái ban đầu
            btnThemMoi.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = false;
            btnThoat.Enabled = true;

            // Hủy trạng thái Thêm/Sửa
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

        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Hiển thị Mã hàng
                txtMaHang.Text =
                    dgvHang.Rows[e.RowIndex].Cells["MaHang"].Value.ToString();

                // Hiển thị Tên hàng
                txtTenHang.Text =
                    dgvHang.Rows[e.RowIndex].Cells["TenHang"].Value.ToString();

                // Hiển thị Chất liệu
                cboChatLieu.SelectedValue =
                    dgvHang.Rows[e.RowIndex].Cells["MaChatLieu"].Value.ToString();

                // Hiển thị Số lượng
                txtSoLuong.Text =
                    dgvHang.Rows[e.RowIndex].Cells["Soluong"].Value.ToString();

                // Hiển thị Giá nhập
                txtDonGiaNhap.Text =
                    dgvHang.Rows[e.RowIndex].Cells["Dongianhap"].Value.ToString();

                // Hiển thị Giá bán
                txtDonGiaBan.Text =
                    dgvHang.Rows[e.RowIndex].Cells["Dongiaban"].Value.ToString();

                // Hiển thị Ghi chú
                txtGhiChu.Text =
                    dgvHang.Rows[e.RowIndex].Cells["GhiChu"].Value.ToString();

                // Lấy tên ảnh từ CSDL
                string tenAnh =
                    dgvHang.Rows[e.RowIndex].Cells["Anh"].Value.ToString();

                // Tạo đường dẫn đến ảnh
                string duongDanAnh =
                    Application.StartupPath + "\\Images\\Hang\\" + tenAnh;

                // Kiểm tra và hiển thị ảnh
                if (System.IO.File.Exists(duongDanAnh))
                {
                    picAnh.Image = Image.FromFile(duongDanAnh);
                }
                else
                {
                    picAnh.Image = null;
                }
            }
        }


    }
}
