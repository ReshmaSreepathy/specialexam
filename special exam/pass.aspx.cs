using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
    

namespace special_exam
{
    public partial class pass : System.Web.UI.Page
    {
        connection obj = new connection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            string s = "select count(Id) from special where name='" + TextBox2.Text + "' and phone=" + TextBox3.Text + "";
            string p = obj.fn_execute(s);
            if(p=="1")
            {
                string q = "select Id from special where name='" + TextBox2.Text + "' and phone=" + TextBox3.Text + "";
                string m = obj.fn_execute(q);
                id = Convert.ToInt32(m);
                Session["uid"] = id;
                Response.Redirect("profile.aspx");
            }
            
        }
    }
}