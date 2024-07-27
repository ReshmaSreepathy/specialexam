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
    public partial class profile : System.Web.UI.Page
    {
        connection obj = new connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                string s = "select * from special where Id= " + Session["uid"] + "";
                SqlDataReader dr = obj.fn_reader(s);
                while (dr.Read())
                {
                    TextBox1.Text = dr["name"].ToString();
                    TextBox2.Text = dr["addr"].ToString();
                    TextBox3.Text = dr["phone"].ToString();
                    Image1.ImageUrl = dr["photo"].ToString();

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "update special set addr='" + TextBox2.Text + "', phone=" + TextBox3.Text + " where Id=" + Session["uid"];
            int i = obj.fn_nonquery(s);
            if(i==1)
            {
                Label1.Text = "updated";
            }
        }
    }
}