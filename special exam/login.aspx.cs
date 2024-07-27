using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace special_exam
{
    public partial class login : System.Web.UI.Page
    {
        connection obj = new connection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/photo/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));


            string s = "insert into special values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + p + "'," + TextBox3.Text + ")";
            int i = obj.fn_nonquery(s);
            if(i==1)
            {
                Label1.Text = "inserted";
            }
        }
    }
}