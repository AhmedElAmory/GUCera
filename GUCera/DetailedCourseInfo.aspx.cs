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
    public partial class DetailedCourseInfo : System.Web.UI.Page
    {
        String err;
        Boolean exists;

        void myConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            err = e.Message;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int id = (Int32)Session["courseID"];

            SqlCommand viewDetailedCourseInfo = new SqlCommand("courseInformation", conn);
            viewDetailedCourseInfo.CommandType = CommandType.StoredProcedure;
            viewDetailedCourseInfo.Parameters.Add(new SqlParameter("@id", id));


            conn.Open();
            SqlDataReader rdr = viewDetailedCourseInfo.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb = new DataTable();
            tb.Load(rdr);

            try
            {
                Object rows=tb.Rows[0];
                exists = true;
            }
            catch(Exception ex)
            {
                exists = false;
            }
            


            GridView1.DataSource = tb;
            GridView1.DataBind();
        }

        protected void Enroll(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int id = (int)Session["user"];
            int courseID = (Int32)Session["courseID"];
            int instID;
            if (instructor.Text.Equals(""))
            {
                Response.Write("<span style= 'color:red'>Unsuccessful attempt: You have not entered an instructor ID, please enter an instructor ID</span>");
                return;
            }
            try
            {
                instID = Int32.Parse(instructor.Text);
                
            }
            catch (Exception ex)
            {
                Response.Write("<span style= 'color:red'>Unsuccessful attempt: the instructor ID you have entered is not valid, please enter a valid instructor ID</span>");
                return;
            }

            if (!exists)
            {
                Response.Write("<span style= 'color:red'>Unsuccessful attempt: Cannot enroll in a course that doesn't exist, please go back and enter an existing course ID</span>");
                return;
            }

            SqlCommand enrollProc = new SqlCommand("enrollInCourse", conn);
            enrollProc.CommandType = CommandType.StoredProcedure;

            enrollProc.Parameters.Add(new SqlParameter("@sid", id));
            enrollProc.Parameters.Add(new SqlParameter("@cid", courseID));
            enrollProc.Parameters.Add(new SqlParameter("@instr", instID));

            conn.Open();
            conn.InfoMessage += new SqlInfoMessageEventHandler(myConnection_InfoMessage);
            try
            {
                enrollProc.ExecuteNonQuery();
                if (err != null && err.Equals("This instructor does not teach this course"))
                {
                    Response.Write("<span style= 'color:red'>Unsuccessful attempt: " + err + " or does not exist, please choose a valid instructor</span>");

                }
                else if (err != null)
                {
                    Response.Write("<span style= 'color:red'>Unsuccessful attempt: " + err + "</span>");
                }
                else
                {
                    Response.Write("<span style= 'color:green'>Successful attempt: You have successfully enrolled in this course</span>");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    Response.Write("<span style= 'color:red'>Unsuccessful attempt: You have already enrolled in this course, please go back and choose another course to enroll in</span>");
            }
            conn.Close();
            
        }
    }

}