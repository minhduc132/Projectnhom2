using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWord
{
    public partial class FeedBack1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            var v1 = TextBox1.Text;
            var v2 = TextBox2.Text;

            Label1.Text = v1 + "-" + v2;
        }
    }
}