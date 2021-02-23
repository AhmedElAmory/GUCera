using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class addContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addingCourse_Click(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            //read user input
            int courseId = 0;
            try
            {
                courseId = Int16.Parse(cid.Text);
            }
            catch (Exception) {
                Response.Write("Please enter numbers only in the course Id textbox");
                return;
            }
            String contentt = content.Text;
            String descriptionn = description.Text;
            int id = Int16.Parse(Session["userId"].ToString());

            SqlCommand test = new SqlCommand("if (not EXISTS(select * from Course where id="+courseId+")) print 's'", conn);
            String printOutput = "";
            conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) => {
                printOutput += e1.Message;
            };
            conn.Open();
            test.ExecuteNonQuery();
            conn.Close();
            if (printOutput == "s") {
                Response.Write("This course id does not exists");
                return;
            }

            test = new SqlCommand("if (not EXISTS(select * from Course where id=" + courseId + " and accepted =1)) print 's'", conn);
            printOutput = "";
            conn.Open();
            test.ExecuteNonQuery();
            conn.Close();
            if (printOutput == "s")
            {
                Response.Write("This course is not accepted yet you can not add its content or description");
                return;
            }


            if (contentt.Length > 0 && cid.Text.Length> 0)
            {
                SqlCommand cmdd = new SqlCommand("UpdateCourseContent", conn);
                cmdd.CommandType = CommandType.StoredProcedure;

                cmdd.Parameters.Add(new SqlParameter("@instrId", id));
                cmdd.Parameters.Add(new SqlParameter("@courseId", courseId));
                cmdd.Parameters.Add(new SqlParameter("@content", contentt));
                conn.Open();
                try
                {
                    cmdd.ExecuteNonQuery();
                }
                catch (Exception) {
                    Response.Write("Something went wrong");
                    conn.Close();
                    return;
                }
                conn.Close();
            }

            if (descriptionn.Length > 0 && cid.Text.Length>0)
            {
                SqlCommand cmdd = new SqlCommand("UpdateCourseDescription", conn);
                cmdd.CommandType = CommandType.StoredProcedure;

                cmdd.Parameters.Add(new SqlParameter("@instrId", id));
                cmdd.Parameters.Add(new SqlParameter("@courseId", courseId));
                cmdd.Parameters.Add(new SqlParameter("@courseDescription", descriptionn));
                conn.Open();
                try
                {
                    cmdd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    Response.Write("Something went wrong");
                    conn.Close();
                    return;
                }
                conn.Close();
            }
            if (contentt.Length > 0 && descriptionn.Length > 0 && cid.Text.Length > 0)
            {
                Response.Write("Course Content and description added successfully");
            }
            else if (contentt.Length > 0 && cid.Text.Length > 0)
            {
                Response.Write("Course Content added successfully");
            }
            else if (descriptionn.Length > 0 && cid.Text.Length > 0)
            {
                Response.Write("Course description added successfully");
            }
            else if (cid.Text.Length > 0)
            {
                Response.Write("you must fill the Content or the Description");
            }
            else {
                Response.Write("you must fill the course Id and the Content or the Description or both");
            }
        }

        protected void returnTohome_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHome.aspx");
        }
    }
}