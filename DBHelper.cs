using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class DBHelper
    {
        public static string connstr= "Data Source=.;Initial Catalog=Xiaocilang;Integrated Security=True";
        private static SqlConnection conn = null;

        private static void Initconnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(connstr);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }
        }
        //进行增删改
        public static bool work(string sql)
        {
            Initconnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            return rows > 0;
        }
        //获取表
        public static DataTable cha(string sql)
        {
            Initconnection();
            DataTable table = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(table);
            return table;
        }

        //店铺id
        public static int dph = 2;

        //查一行
        public static Object cha1(string sql)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            Object n = cmd.ExecuteScalar();
            conn.Close();
            return n;
        }
        //获取店铺ID
        public static void get(int i)
        {
            dph = i;
        }
        //提供店铺ID
        public static int gave()
        {
            return dph;
        }
        //订单号
        public static string ddh;
        public static void get1(string i)
        {
            ddh = i;
        }
        //用户id
        public static int yhid=0;
    }
}
