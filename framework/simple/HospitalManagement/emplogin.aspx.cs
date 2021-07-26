using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class userlogin : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(GetConnectionString());
    SqlDataReader dr;

    static string GetConnectionString()
    {
        ConnectionStringSettings settings =
        ConfigurationManager.ConnectionStrings["DBConnection"];
        return settings.ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        cn.Open();
        string qry;
        qry = "select * from hospital_empsignup where loginid='" + lidtxt.Text + "' and password='" + pwdtxt.Text + "'";
        SqlCommand cmd = new SqlCommand(qry, cn);
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["department"].ToString() == "Reception")
            {
                Response.Redirect("emphome.aspx");
            }
            else
            {
                Response.Redirect("emphome.aspx");
            }
            
        }
        else
        {
            pwdlb.Text = "Enter valid UserName/Password";
        }
    }
}
