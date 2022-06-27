using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWord
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Tao chuoi ket noi = SqlConnectionStringBuider
            var stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder["Server"] = "127.0.0.1,1433";
            stringBuilder["Database"] = "Sales";
            stringBuilder["User Id"] = "sa";
            stringBuilder["Password"] = "123456";
            String sqlConnectionString = stringBuilder.ToString();

            var connection = new SqlConnection(sqlConnectionString);

            connection.Open();

            using (DbCommand command = connection.CreateCommand()) {

                command.CommandText = "Select * from sanpham";
                var reader = command.ExecuteReader();

                Console.WriteLine("\r\nCac san pham:");
                Console.WriteLine($"{"sanphamid",10} {"tensanpham"}");
                //while (reader.Read())
                //{
                //    Console.WriteLine($"{reader["SanphamID"],10}{reader["Tensanpham"]}");
                //}
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }
           // connection.Close();
        }
    }
}