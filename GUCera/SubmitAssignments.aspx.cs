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
    public partial class SubmitAssignments : System.Web.UI.Page
    {
        String err;

        void myConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            err = e.Message;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitAssignment_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //create new connection
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand submitAssign = new SqlCommand("submitAssign", conn);
            submitAssign.CommandType = CommandType.StoredProcedure;

            if(assignmentNumber.Text.Equals("") |courseID.Text.Equals(""))
            {
                message.Text = "Please enter all the data";
                return;
            }


            submitAssign.Parameters.Add(new SqlParameter("@assignType", assignmentType.SelectedValue.ToString()));


            try{
            submitAssign.Parameters.Add(new SqlParameter("@assignnumber", Int16.Parse(assignmentNumber.Text)));
            }catch{
                message.Text = "Please enter a number in the assignment number box";
                return;
            }
            
            submitAssign.Parameters.Add(new SqlParameter("@sid", Session["user"]));

            try
            {
            submitAssign.Parameters.Add(new SqlParameter("@cid", Int16.Parse(courseID.Text)));
            }catch{
                message.Text = "Please enter a number in the course number box";
                return;
            }


            conn.Open();
            conn.InfoMessage += new SqlInfoMessageEventHandler(myConnection_InfoMessage);

            try
            {
                submitAssign.ExecuteNonQuery();
            }
            catch
            {
                message.Text = "Assignment already submitted or does not exist!";
                conn.Close();
                return;
            }
            conn.Close();

            if (err != null)
            {
                message.Text = "You are not enrolled in the course";
            }
            else
            {
            message.Text = "Assignment Submitted";

            }

            
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}