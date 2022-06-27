using SqlDemo.entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SqlDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        protected void Button1_Click1(object sender, EventArgs e)
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

                SqlCommand command1 = new SqlCommand(
                    "INSERT INTO Sanpham (SanphamID, TenSanpham)  VALUES (@SanphamID, TenSanpham)", connection);

                command1.Parameters.AddWithValue("@SanphamID", 5);
                command1.Parameters.AddWithValue("@TenSanpham", "san pham 5");

                command1.ExecuteNonQuery();
                command1.Dispose();

                connection.Close();

                var sp = new Sanpham();
                sp.SanphamID = 6;
                sp.TenSanpham = "Sp 6";
                using (var db = new SalesEntities())
                {
                    db.Sanphams.Add(sp);
                    db.SaveChanges();
                }
           
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}