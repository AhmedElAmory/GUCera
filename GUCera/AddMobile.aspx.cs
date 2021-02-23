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
    public partial class AddMobile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addMobileNumber_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //create new connection
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand addMobileproc = new SqlCommand("addMobile", conn);
            addMobileproc.CommandType = CommandType.StoredProcedure;

            if (mobileNumber.Text.Equals(""))
            {
                Response.Write("Please enter a mobile number");
                return;
            }



            addMobileproc.Parameters.Add(new SqlParameter("@ID", Session["user"]));
            addMobileproc.Parameters.Add(new SqlParameter("@mobile_number", mobileNumber.Text));

            conn.Open();

            try
            {
            addMobileproc.ExecuteNonQuery();

            }
            catch
            {
                Response.Write("This mobile number already exists");
                conn.Close();
                return;
            }
            conn.Close();
            
            Response.Write("Mobile Number Added");
            
            
        }

        protected void home_Click(object sender, EventArgs e)
        {
            if (Session["userType"].ToString().Equals("0"))
            {
            Response.Redirect("InstructorHome.aspx");
            }
            else if(Session["userType"].ToString().Equals("1"))
            {
                Response.Redirect("AdminHome.aspx");
            }
            else if (Session["userType"].ToString().Equals("2"))
            {
                Response.Redirect("StudentHome.aspx");
            }
        }
    }
}