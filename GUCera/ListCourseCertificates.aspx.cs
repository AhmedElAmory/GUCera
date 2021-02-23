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
    public partial class ListCourseCertificates : System.Web.UI.Page
    {

        String err;

        void myConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            err = e.Message;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showCertificate_Click(object sender, EventArgs e)
        {

            if (courseID.Text.Equals(null))
            {
                error.Text = "Please enter the course ID";
                return;
            }

            try
            {
                Int16.Parse(courseID.Text);
            }
            catch
            {
                error.Text = "Please enter a number in the course ID box";
                return;
            }



            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //create new connection
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand certificate = new SqlCommand("viewCertificate", conn);
            certificate.CommandType = CommandType.StoredProcedure;

           

            certificate.Parameters.Add(new SqlParameter("@cid", Int16.Parse(courseID.Text)));
            certificate.Parameters.Add(new SqlParameter("@sid", Session["user"]));

            conn.Open();

            conn.InfoMessage += new SqlInfoMessageEventHandler(myConnection_InfoMessage);

            SqlDataReader rdr = certificate.ExecuteReader(CommandBehavior.CloseConnection);

            if (err == null)
            {
            Response.Redirect("ListCourseCertificateResult.aspx?courseID="+courseID.Text);

            }
            else
            {
                error.Text=("You are not enrolled in the course");
            }
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}