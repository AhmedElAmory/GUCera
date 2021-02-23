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
    public partial class ViewAssignmentGrade : System.Web.UI.Page
    {

        String err;

        void myConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            err = e.Message;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void checkGrade_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //create new connection
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewAssignGrades = new SqlCommand("viewAssignGrades", conn);
            viewAssignGrades.CommandType = CommandType.StoredProcedure;

            if (assignmentNumber.Text.Equals("") | courseID.Text.Equals(""))
            {
                grade.Text = "Please enter all the data";
                return;
            }


            viewAssignGrades.Parameters.Add(new SqlParameter("@assignType", assignmentType.SelectedValue.ToString()));

            try
            {
                viewAssignGrades.Parameters.Add(new SqlParameter("@assignnumber", Int16.Parse(assignmentNumber.Text)));
            }
            catch
            {
                grade.Text = "Please enter a number in the assignment number box";
                return;
            }

            viewAssignGrades.Parameters.Add(new SqlParameter("@sid", Session["user"]));

            try
            {
                viewAssignGrades.Parameters.Add(new SqlParameter("@cid", Int16.Parse(courseID.Text)));
            }
            catch
            {
                grade.Text = "Please enter a number in the course number box";
                return;
            }

            SqlParameter gradeValue = viewAssignGrades.Parameters.Add(new SqlParameter("@assignGrade", SqlDbType.Decimal));

            gradeValue.Direction = ParameterDirection.Output;

            conn.Open();

            conn.InfoMessage += new SqlInfoMessageEventHandler(myConnection_InfoMessage);
            try
            {
                viewAssignGrades.ExecuteNonQuery();
            }
            catch
            {
                grade.Text = "Something went Wrong!!";
                conn.Close();
                return;
            }
            conn.Close();


            grade.Text = gradeValue.Value.ToString();

            if (err==null&gradeValue.Value.ToString().Equals(""))
            {
                grade.Text = "assignment not graded yet or does not exist";
            }else if (err != null)
            {
                grade.Text = "You did not submit the Assignment or you are not enrolled in the course";
            }


        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}