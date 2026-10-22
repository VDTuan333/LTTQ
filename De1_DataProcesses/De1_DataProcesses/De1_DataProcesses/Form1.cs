using De1_DataProcesses.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De1_DataProcesses
{
    public partial class frmNhanVien : Form
    {
        Classes.DataProcesses dataProcesses = new Classes.DataProcesses();
        Classes.Function function = new Classes.Function();
        string FileAnh = "";

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            //do du lieu vao dgv
            DataTable dataTable = dataProcesses.DocBang("select * from tblNhanVien");
            
            dgvNhanVien.DataSource = dataTable;
            

            lbTenNv.DataBindings.Add("Text", dataTable, "TenNV");

            dataTable.Dispose();
            // Nút sửa, xóa ở trạng thái không hoạt động (
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnThoat.Enabled = true;


        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đồng thời nút Sửa, xóa trở nên hoạt động, Nút thêm về trạng thái không hoạt động
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            btnThoat.Enabled = true;

            //Hien thi data len dieu khien tuong ung 
            txtMaNv.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNv.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtSoDt.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
            txtMucLuong.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
            cboPhongBan.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
            try
            {
                string tenAnh = dgvNhanVien.CurrentRow.Cells[6].Value.ToString();
                string duongDanAnh = Application.StartupPath + "\\images\\" + tenAnh;
                picAnh.Image = Image.FromFile(duongDanAnh);
            }
            catch
            {
                picAnh.Image = null;
            }

            string gioitinh = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            if (gioitinh == "Nam")

            {
                rbNam.Checked = true;
                rbNu.Checked = false;

            }
            else
            {
                rbNam.Checked = false;
                rbNu.Checked = true;
            }
            

        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "jpg(*.jpg)|*.jpg|AllFile(*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.Title = "chon anh hien thi";
            openFileDialog.InitialDirectory = Application.StartupPath;

            if (openFileDialog.ShowDialog() ==  System.Windows.Forms.DialogResult.OK)
            {

                picAnh.Image = Image.FromFile(openFileDialog.FileName);
                string[] str = openFileDialog.FileName.Split('\\');
                FileAnh = str[str.Length - 1].ToString();

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;

            

            //            Kiểm tra xem người dùng đã nhập đủ dữ liệu chưa ? (Các trường phải kiểm tra bao
            //gồm: Mã NV, Tên NV, Giới tính, Mức lương). Nếu chưa nhập trường nào chương
            //trình sẽ yêu cầu người dùng nhập trường đó.
            if(txtMaNv.Text.Trim() == "")
            {
                MessageBox.Show("ban phai nhap ma nhan vien!");
                txtMaNv.Focus();
                return;
            }
            if (txtTenNv.Text.Trim() == "")
            {
                MessageBox.Show("ban phai nhap ten nhan vien!");
                txtTenNv.Focus();
                return;
            }
            if (!rbNam.Checked && !rbNu.Checked)
            {
                MessageBox.Show("ban phai chon gioi tinh nhan vien!");
                
                return;
            }
            if (txtMucLuong.Text.Trim() == "")
            {
                MessageBox.Show("ban phai nhap muc luong nhan vien!");
                txtMucLuong.Focus();
                return;
            }




            //            Kiểra có trùng mã học viên không, nếu trùng mã sẽ đưa con trỏ về TextBox
            ////nhập mã nhân viên bắt người dùng nhập lại.
            //Thêm nhân viên vừa nhập vào CSDL(với Mật khẩu được mặc định là mã nhân
            //viên, ảnh chỉ lưu tên ảnh) và hiển thị dữ liệu trên datagridview(1.5 điểm)
            string gioitinh = "";
            if(rbNam.Checked == true)
            {
                gioitinh = "Nam";
            }
            else
            {
                gioitinh = "Nữ";
            }

            string Anh = "";
            
            
            string MatKhau = txtMaNv.Text.Trim();
            if (btnThem.Enabled == true)
            {
                DataTable dtMa = dataProcesses.DocBang("select * from tblNhanVien where MaNV = '" + txtMaNv.Text + "'");
                if(dtMa.Rows.Count >= 1)
                {
                    MessageBox.Show("ma san pham da ton tai , hay nhap ma khac!");
                    txtMaNv.Focus();
                    return;
                }
                //them moi
                string strInsert = "Insert into tblNhanVien values(N'" + txtMaNv.Text + "', N'" + txtTenNv.Text + "',N'" + txtSoDt.Text + "',N'"+gioitinh+"','"+cboPhongBan.Text+"',N'"+txtMucLuong.Text+"','"+FileAnh+"',N'"+MatKhau+"')";
                dataProcesses.DataUpdate(strInsert);
                DataTable dataTable = dataProcesses.DocBang("select *from tblNhanVien");
                dgvNhanVien.DataSource = dataTable;
                    
            }
            MessageBox.Show("them thanh cong");
            ReSetValues();
        }
        public void ReSetValues()
        {
            txtMaNv.Text = "";
            txtMucLuong.Text = "";
            picAnh.Image = null;
            txtSoDt.Text = "";
            txtTenNv.Text = "";
            cboPhongBan.Text = "";
            txtMaNv.Focus();
        }
        private void rbNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gioitinh = "";
            if (rbNam.Checked == true)
            {
                gioitinh = "Nam";
            }
            else
            {
                gioitinh = "Nữ";
            }

            string Anh = "";
            if (dgvNhanVien.CurrentRow != null && dgvNhanVien.CurrentRow.Cells[6].Value != null)
            {
                Anh = dgvNhanVien.CurrentRow.Cells[6].Value.ToString();
            }
            string MatKhau = txtMaNv.Text.Trim();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
            btnSua.Enabled = true;

            if (btnSua.Enabled == true)
            {
                string strUpdate = "Update tblNhanVien set TenNV = N'"+txtTenNv.Text+"',SoDT = '"+txtSoDt.Text+"',GioiTinh = N'"+gioitinh+"',PhongBan = N'"+cboPhongBan.Text+"',MucLuong = '"+txtMucLuong.Text+"',Anh = '"+FileAnh+"',MatKhau = '"+MatKhau+"' where MaNV = N'"+txtMaNv.Text+"'";
                dataProcesses.DataUpdate(strUpdate);
                DataTable dataTable = dataProcesses.DocBang("select * from tblNhanVien");
                dgvNhanVien.DataSource = dataTable;

                
            }
            MessageBox.Show("sua thanh cong");
            btnThem.Enabled = true;
            ReSetValues();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("ban co chac chan muon xoa khong?","xac nhan", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                dataProcesses.DataUpdate("delete tblNhanVien where MaHang = N'" + txtMaNv.Text + "'");
                dgvNhanVien.DataSource = dataProcesses.DocBang("select * from tblNhanVien");


            }
            //// Đồng thời nút sửa 
            //xóa không hoạt động, nút thêm sẽ hoạt động. 
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnThoat.Enabled = true;

            ReSetValues();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("co muon thoat","xac nhan", MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
