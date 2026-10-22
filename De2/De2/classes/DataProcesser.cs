using System;
using System.Data;
using System.Data.SqlClient;

namespace De2
{
    public class DataProcessor
    {
        private string connectionString =
            @"Data Source=Admin-PC;Initial Catalog=DuLieu3;Integrated Security=True";

        private SqlConnection conn;

        public DataProcessor()
        {
            conn = new SqlConnection(connectionString);
        }

        // Lấy toàn bộ dữ liệu bảng VatLieu
        public DataTable GetAllVatLieu()
        {
            DataTable dt = new DataTable();

            string sql = "SELECT * FROM VatLieu";

            SqlDataAdapter adapter =
                new SqlDataAdapter(sql, conn);

            adapter.Fill(dt);

            return dt;
        }
        public bool KiemTraMaVL(string maVL)
        {
            string sql = "SELECT COUNT(*) FROM VatLieu WHERE MaVL = @MaVL";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaVL", maVL);

                conn.Open();

                int count = (int)cmd.ExecuteScalar();

                conn.Close();

                return count > 0;
            }
        }
        public void ThemVatLieu(
            string maVL,
            string tenVatLieu,
            string donViTinh,
            string giaNhap,
            string giaBan,
            int soLuong,
            string anh,
            string ghiChu)
        {
            string sql = @"INSERT INTO VatLieu
                   (MaVL, TenVatLieu, DonViTinh,
                    GiaNhap, GiaBan, SoLuong, Anh, GhiChu)
                   VALUES
                   (@MaVL, @TenVatLieu, @DonViTinh,
                    @GiaNhap, @GiaBan, @SoLuong, @Anh, @GhiChu)";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaVL", maVL);
                cmd.Parameters.AddWithValue("@TenVatLieu", tenVatLieu);
                cmd.Parameters.AddWithValue("@DonViTinh", donViTinh);
                cmd.Parameters.AddWithValue("@GiaNhap", giaNhap);
                cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@Anh", anh);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
        // Sửa vật liệu
        public void SuaVatLieu(
            string maVL,
            string tenVatLieu,
            string donViTinh,
            string giaNhap,
            string giaBan,
            int soLuong,
            string anh,
            string ghiChu)
        {
            string sql = @"UPDATE VatLieu
                   SET TenVatLieu = @TenVatLieu,
                       DonViTinh = @DonViTinh,
                       GiaNhap = @GiaNhap,
                       GiaBan = @GiaBan,
                       SoLuong = @SoLuong,
                       Anh = @Anh,
                       GhiChu = @GhiChu
                   WHERE MaVL = @MaVL";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaVL", maVL);
                cmd.Parameters.AddWithValue("@TenVatLieu", tenVatLieu);
                cmd.Parameters.AddWithValue("@DonViTinh", donViTinh);
                cmd.Parameters.AddWithValue("@GiaNhap", giaNhap);
                cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@Anh", anh);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
