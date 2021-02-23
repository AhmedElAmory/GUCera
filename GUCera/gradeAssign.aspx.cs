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
    public partial class gradeAssign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void gradeAssign_Click(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);


            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("InstructorgradeAssignmentOfAStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //read user input
            int courseid = 0;
            int anumber = 0;
            Decimal studentgrade = 0;
            int studentid = 0;
            if (cid.Text.Length == 0 | sid.Text.Length == 0 | number.Text.Length==0 |grade.Text.Length==0)
            {
                Response.Write("Please fill all the textboxes");
                return;
            }
            try
            {
                courseid = Int16.Parse(cid.Text);
            }
            catch (Exception)
            {
                Response.Write("Please enter numbers only in course id textbox");
                return;

            }
            try
            {
                anumber = Int16.Parse(number.Text);
                
            }
            catch (Exception)
            {
                Response.Write("Please enter numbers only in assignment number textbox");
                return;

            }
            try
            {
                studentgrade = Decimal.Parse(grade.Text);
            }
            catch (Exception)
            {
                Response.Write("Please enter numbers only in Grade textbox");
                return;

            }
            try
            {
                studentid = Int16.Parse(sid.Text);
            }
            catch (Exception)
            {
                Response.Write("Please enter numbers only in Student id textbox");
                return;

            }
         
            String type = DropDownList1.SelectedValue.ToString();



                if ( type != "-1"  )
            {
                int id = Int16.Parse(Session["userId"].ToString());

                SqlCommand test = new SqlCommand("if (not EXISTS(select * from StudentTakeCourse where sid=" + studentid + " and cid =" + courseid + ")) print 's'", conn);
                String printOutput = "";
                conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) => {
                    printOutput += e1.Message;
                };
                conn.Open();
                test.ExecuteNonQuery();
                conn.Close();
                if (printOutput == "s")
                {
                    Response.Write(" this student does  not take this course ");
                    return;
                }

                String q = "if (not exists(select * from StudentTakeAssignment S inner join Course C on C.id = S.cid where cid =" + courseid + "" +
                " and assignmentNumber = " + anumber + " and sid = " + studentid + " and instructorId = " + id + " and assignmenttype = '" + type + "')) print 's'";

                 test = new SqlCommand(q, conn);
                 printOutput = "";
                conn.Open();
                test.ExecuteNonQuery();
                conn.Close();
                if (printOutput == "s")
                {
                    Response.Write("This assignment does not exists  ");
                    return;
                }

                cmd.Parameters.Add(new SqlParameter("@instrId", id));
                cmd.Parameters.Add(new SqlParameter("@cid", courseid));
                cmd.Parameters.Add(new SqlParameter("@assignmentNumber", anumber));
                cmd.Parameters.Add(new SqlParameter("@type", type));
                cmd.Parameters.Add(new SqlParameter("@grade", studentgrade));
                cmd.Parameters.Add(new SqlParameter("@sid", studentid));

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception) {
                    Response.Write("Somethimg went wrong");
                    conn.Close();
                    return;
                }
                
             
                conn.Close();

                Response.Write("The Assignment was graded successfully");
            }
            else
            {
                Response.Write("Please fill all the inputs");
            }
        }

        protected void returnTohome_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHome.aspx");
        }
    }
}