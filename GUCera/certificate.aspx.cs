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
    public partial class certificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void returnTohome_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHome.aspx");
        }

        protected void Issuecertificate_Click(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);


            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("InstructorIssueCertificateToStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (cid.Text.Length==0| sid.Text.Length==0) {
                Response.Write("Please fill all the textboxes");
                return;
            }

            //read user input
            int courseid = 0;
            int studentid = 0;
            try
            {
                courseid = Int16.Parse(cid.Text);
            }
            catch (Exception)
            {
                Response.Write("Please enter numbers only in the course id textbox");
                return;
            }

            try {
                studentid = Int16.Parse(sid.Text);
            }
            catch (Exception) {
                Response.Write("Please enter numbers only in the student id textbox");
                return;
            }
            String issuedate = date.Text;
            DateTime dt;
            if (!DateTime.TryParse(issuedate, out dt))
            {
                Response.Write("Please enter deadline in the correct format");
                return;
            }

            SqlCommand test = new SqlCommand("if (not EXISTS(select * from StudentTakeCourse where sid=" + studentid + " and cid ="+courseid+ " and grade >2.0)) print 's'", conn);
            String printOutput = "";
            conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) => {
                printOutput += e1.Message;
            };
            conn.Open();
            test.ExecuteNonQuery();
            conn.Close();
            if (printOutput == "s")
            {
                Response.Write("You cannot issue this certificate as this student does  not take this course or his grade in this course is less 2.0");
                return;
            }

            if (cid.Text.Length > 0 && cid.Text.Length > 0 && date.Text.Length>0)
            {
                int id = Int16.Parse(Session["userId"].ToString());

                cmd.Parameters.Add(new SqlParameter("@insId", id));
                cmd.Parameters.Add(new SqlParameter("@cid", courseid));
                cmd.Parameters.Add(new SqlParameter("@sid", studentid));
                cmd.Parameters.Add(new SqlParameter("@issueDate", issuedate));


                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception) {
                    Response.Write("You already issued this certificate");
                    conn.Close();
                    return;
                }


                conn.Close();

                Response.Write("The Certificate was issued successfully");
            }
            else
            {
                Response.Write("Please fill all textboxes");
            }
        }
    }
}