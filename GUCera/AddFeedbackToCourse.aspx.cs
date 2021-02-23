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
    public partial class AddFeedbackToCourse : System.Web.UI.Page
    {
        String err;
        void myConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            err = e.Message;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitFeedback_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //create new connection
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand submitFeedback = new SqlCommand("addFeedback", conn);
            submitFeedback.CommandType = CommandType.StoredProcedure;

            if (courseID.Text.Equals(""))
            {
                error.Text = "Please enter the course ID";
                return;
            }

            try
            {
            submitFeedback.Parameters.Add(new SqlParameter("@cid", Int16.Parse(courseID.Text)));
            }
            catch
            {
                error.Text = "Please enter a number in the course ID box";
                return;
            }

            if (feedback.Text.Equals(""))
            {
                error.Text = "Please enter a feedback!";
                return;
            }

            submitFeedback.Parameters.Add(new SqlParameter("@comment", feedback.Text));

            submitFeedback.Parameters.Add(new SqlParameter("@sid", Session["user"]));

            conn.Open();
            conn.InfoMessage += new SqlInfoMessageEventHandler(myConnection_InfoMessage);
            try
            {
                submitFeedback.ExecuteNonQuery();
            }
            catch
            {
                error.Text = "Something went Wrong!!";
                conn.Close();
                return;
            }
            conn.Close();

            if (err == null)
            {
            error.Text = "Feedback added";

            }
            else
            {
                error.Text = "You are not enrolled in the course";
            }
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}