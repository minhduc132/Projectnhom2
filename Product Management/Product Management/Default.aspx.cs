using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Product_Management
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //tao chuoi ket noi bang sqlconnectionStringBuilder
            var stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder["Server"] = "127.0.0.1,1433";
            stringBuilder["Database"] = "Sales";
            stringBuilder["User Id"] = "sa";
            stringBuilder["Password"] = "123456";
            string sqlConnectionString = stringBuilder.ToString();

            var connection = new SqlConnection(sqlConnectionString);

            connection.Open();

            //dung sql command thi hanh sql
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "select * from sanpham";
                var reader = command.ExecuteReader();

                ////doc ket qua truy  van
                //Console.WriteLine("\r\ncac san pham:");
                //Console.WriteLine($"{"sanphamid ",10} {"tensanpham "}");
                //while (reader.Read())
                //{
                //    Console.WriteLine($"{reader["SanphamID"],10} {reader["TenSanpham"]}");
                //}

              
            }
            connection.Close();
        }
    }
}