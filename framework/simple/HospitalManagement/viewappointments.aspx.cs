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

public partial class viewappointments : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(GetConnectionString());

    static string GetConnectionString()
    {
        ConnectionStringSettings settings =
        ConfigurationManager.ConnectionStrings["DBConnection"];
        return settings.ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            filldrop();
            doctorddl.Items.Insert(0, "...Select...");
        }
    }
    void filldrop()
    {
        cn.Open();
        string qry = "select name from hospital_doctorsignup";
        SqlDataAdapter da = new SqlDataAdapter(qry, cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "hospital_doctorsignup");
        doctorddl.DataSource = ds;
        doctorddl.DataTextField = "name";
        doctorddl.DataBind();        
        cn.Close();
        
    }

    protected void doctorddl_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void appbtn_Click(object sender, EventArgs e)
    {
        cn.Open();
        //string str = doctorddl.SelectedItem.ToString();
        string qry = "select * from hospital_patientinfo where doctor='" + doctorddl.SelectedValue +  "' ";
        SqlDataAdapter da = new SqlDataAdapter(qry,cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        cn.Close();
    }
    protected void backbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("doctorsden.aspx");
    }
}
