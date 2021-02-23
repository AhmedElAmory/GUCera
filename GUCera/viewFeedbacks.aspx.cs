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
    public partial class viewFeedbacks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void returnTohome_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHome.aspx");
        }

        protected void viewAssignment_Click(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);


            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;



            if (cid.Text.Length > 0)
            {
                int courseId = 0;
                try
                {
                    courseId = Int16.Parse(cid.Text);
                }
                catch (Exception)
                {
                    Response.Write("Please enter numbers in Course Id textbox");
                    return;
                }
                int id = Int16.Parse(Session["userId"].ToString());


                cmd.Parameters.Add(new SqlParameter("@instrId", id));
                cmd.Parameters.Add(new SqlParameter("@cid", courseId));

                //Executing the SQLCommand
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);



                DataTable dt = new DataTable();
                dt.Clear();


                dt.Load(rdr);

                gridView.DataSource = dt;
                gridView.DataBind();
                conn.Close();
                SqlCommand test = new SqlCommand("if (not EXISTS(Select * From  Course  " +
                    " where id =" + courseId + " and instructorId = " + id + ")) print 's'", conn);
                String printOutput = "";
                conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) => {
                    printOutput += e1.Message;
                };
                conn.Open();
                test.ExecuteNonQuery();
                conn.Close();
                if (printOutput == "s")
                {
                    Response.Write("You do not teach this course");
                    return;
                }

                test = new SqlCommand("if (not EXISTS(Select number,comment ,numberOfLikes From Feedback f inner join course c on c.id = f.cid " +
                   " where cid =" + courseId + " and instructorId = " + id + ")) print 's'", conn);
                printOutput = "";
                conn.Open();
                test.ExecuteNonQuery();
                conn.Close();
                if (printOutput == "s")
                {
                    Response.Write("There is no feedbacks on this course");
                    return;
                }
            }
            else {
                Response.Write("The textbox is empty");
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}