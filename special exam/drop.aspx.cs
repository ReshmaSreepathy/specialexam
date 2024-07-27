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
    public partial class drop : System.Web.UI.Page
    {
        connection obj = new connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                //string s = "select Id,name from special ";
                //DataSet ds = obj.fn_data(s);
                //DropDownList1.DataSource = ds;
                //DropDownList1.DataTextField = "name";
                //DropDownList1.DataValueField = "Id";
                //DropDownList1.DataBind();
                //DropDownList1.Items.Insert(0, "select");

                string p = "select * from special ";
                DataSet ds1 = obj.fn_data(p);
                GridView1.DataSource = ds1;
                GridView1.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "select * from special where Id=" + DropDownList1.SelectedItem.Value + "";
            DataSet ds = obj.fn_data(s);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            //string s = "select * from special where Id=" + DropDownList1.SelectedItem.Value + "";
            //DataSet ds = obj.fn_data(s);
            //DataList1.DataSource = ds;
            //DataList1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string s = "select * from special ";
            DataSet ds = obj.fn_data(s);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow rw = GridView1.Rows[e.NewSelectedIndex];
            Label2.Text = rw.Cells[4].Text;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox addr = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            string s = "update special set addr='" + addr.Text + "' where Id=" + getid + "";
            int m = obj.fn_nonquery(s);
            GridView1.EditIndex = -1;
            string q = "select * from special ";
            DataSet ds = obj.fn_data(q);
            GridView1.DataSource = ds;
            GridView1.DataBind();



        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            string q = "select * from special ";
            DataSet ds = obj.fn_data(q);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            string q = "select * from special ";
            DataSet ds = obj.fn_data(q);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
    }
}