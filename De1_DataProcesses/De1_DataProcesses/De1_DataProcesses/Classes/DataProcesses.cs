using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace De1_DataProcesses.Classes
{
    internal class DataProcesses
    {
        string sqlConnect = "Data Source=LAPTOP-UCT675BS\\SQLEXPRESS;Initial Catalog=DuLieu;" +
            "Integrated Security=True";
        SqlConnection sqlConnection = null;

        //keet noi 
        public void KetNoi()
        {
            sqlConnection = new SqlConnection(sqlConnect);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }
        //dong ket noi 
        public void DongKetNoi()
        {
            sqlConnection = new SqlConnection(sqlConnect);
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        //ham thuc thi cau lenh slect
        public DataTable DocBang(string sql)
        {
            DataTable dataTable = new DataTable();
            KetNoi();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnect);
            sqlDataAdapter.Fill(dataTable);
            DongKetNoi();
            return dataTable;
        }
        //ham thu thi cau lenh update , insert, delete
        public void DataUpdate(string sql)
        {
            KetNoi();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = sql;
            sqlCommand.ExecuteNonQuery();
            DongKetNoi();
            sqlCommand.Dispose();
        }
    }
}
