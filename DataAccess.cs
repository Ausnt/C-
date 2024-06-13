using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace BaiThi
{
    static class DataAccess
    {
        private static string DuongDan = $@"Data Source=.\sqlexpress;Initial Catalog=TeamLeader;Integrated Security=True;Encrypt=False";
        private static SqlConnection creatConnect()
        {
            return new SqlConnection(DuongDan);
        }
        // Phương thức lấy dữ liệu ra dưới dạng table/view
        public static DataTable getTable(string sql)
        {
            SqlConnection con = creatConnect();
            con.Open();
           SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            con.Close();
            ad.Dispose();
            return tb;

        }
        public static void insertUpdateDelete(string sql)
        {
            SqlConnection con = creatConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }
        public static object executeScalar(string query)
        {
            using(SqlConnection con = creatConnect())
            {
                SqlCommand command = new SqlCommand(query, con);
                con.Open();
               return command.ExecuteScalar();
            }
        }
    }
}
