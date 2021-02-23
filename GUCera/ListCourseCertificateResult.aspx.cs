using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class ListCourseCertificateResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //create new connection
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand certificate = new SqlCommand("viewCertificate", conn);
            certificate.CommandType = CommandType.StoredProcedure;

            int courseID = Int16.Parse(Request.QueryString["courseID"]);

            certificate.Parameters.Add(new SqlParameter("@cid", courseID));
            certificate.Parameters.Add(new SqlParameter("@sid", Session["user"]));

            conn.Open();

            SqlDataReader rdr = certificate.ExecuteReader(CommandBehavior.CloseConnection);

            DataTable cou = new DataTable();

            cou.Load(rdr);

            grid.DataSource = cou;

            grid.DataBind();

        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListCourseCertificates.aspx");
        }
    }
}