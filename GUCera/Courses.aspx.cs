using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera_Website
{
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand courses = new SqlCommand("availableCourses",conn);
            courses.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = courses.ExecuteReader(CommandBehavior.CloseConnection);
            
                DataTable tb = new DataTable();
                tb.Load(rdr);

                GridView1.DataSource = tb;
            
                GridView1.DataBind();
        }

        protected void ViewDetailedInfo(object sender, EventArgs e)
        {
            if (courseid.Text.Equals(""))
            {
                Response.Write("<span style= 'color:red'>Unsuccessful attempt: You have not entered a course ID, please enter a course ID</span>");
                return;
            }
            try
            {
                Session["courseID"] = Int32.Parse(courseid.Text);
                Response.Redirect("DetailedCourseInfo.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<span style= 'color:red'>Unsuccessful attempt: The course ID you have entered is not valid, please enter a valid course ID</span>");
            }
        }
    }
}