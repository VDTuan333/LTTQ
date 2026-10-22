using System.Data;
using Microsoft.Data.SqlClient;

namespace BanHangLuuNiem.Classes
{
    internal class DataProcesser
    {
        string strConnect =
    @"Data Source=Admin-PC;" +
    "Initial Catalog=BanHangLuuNiem;" +
    "Integrated Security=True;" +
    "TrustServerCertificate=True;";


        SqlConnection sqlConnect = null;

        // Hàm mở kết nối
        private void KetNoiCSDL()
        {
            sqlConnect = new SqlConnection(strConnect);
            if (sqlConnect.State != ConnectionState.Open)
            {
                sqlConnect.Open();
            }
        }
        

        // Hàm đóng kết nối
        private void DongKetNoiCSDL()
        {
            if (sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }
        

        // Hàm thực thi câu lệnh SELECT
        // trả về một DataTable
        public DataTable DocBang(string sql)
        {
            DataTable dtBang = new DataTable();

            KetNoiCSDL();

            SqlDataAdapter sqldataAdapte =
                new SqlDataAdapter(sql, sqlConnect);

            sqldataAdapte.Fill(dtBang);

            DongKetNoiCSDL();

            return dtBang;
        }
        

        // Hàm thực hiện INSERT, UPDATE, DELETE
        
        public void CapNhatDuLieu(string sql)
        {
            KetNoiCSDL();

            SqlCommand sqlcommand = new SqlCommand();

            sqlcommand.Connection = sqlConnect;
            sqlcommand.CommandText = sql;

            sqlcommand.ExecuteNonQuery();

            DongKetNoiCSDL();

            sqlcommand.Dispose();
        }

        public DataTable KiemTraDangNhap(string maNV, string passw)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                string sql = @"
            SELECT MaNV, TenNV
            FROM tblNhanVien
            WHERE MaNV = @MaNV
              AND Passw = @Passw";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 10).Value = maNV;
                    cmd.Parameters.Add("@Passw", SqlDbType.NVarChar, 50).Value = passw;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}