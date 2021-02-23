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
    public partial class viewAssignmentOfStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void viewAssignment_Click(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);


            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("InstructorViewAssignmentsStudents", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //read user input
            

     
            if (cid.Text.Length > 0) {
                int courseId = 0;
                try
                {
                     courseId = Int16.Parse(cid.Text);
                }
                catch (Exception) {
                    Response.Write("Please enter numbers in Course Id textbox");
                    return;
                }
                int id = Int16.Parse(Session["userId"].ToString());
                cmd.Parameters.Add(new SqlParameter("@instrId", id));
                cmd.Parameters.Add(new SqlParameter("@cid", courseId));


                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("Student Id");
                dt.Columns.Add("Course Id");
                dt.Columns.Add("Assignment Number");
                dt.Columns.Add("Assignment Type");
                dt.Columns.Add("Grade");
                //Executing the SQLCommand
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read()) {
                    int sid = rdr.GetInt32(rdr.GetOrdinal("sid"));
                    int coid = rdr.GetInt32(rdr.GetOrdinal("cid"));
                    int assNo = rdr.GetInt32(rdr.GetOrdinal("assignmentNumber"));
                    String assType = rdr.GetString(rdr.GetOrdinal("assignmenttype"));
                    DataRow d = dt.NewRow();
                    Decimal g=0;
                    if (rdr["grade"] != DBNull.Value)
                    {
                        g = rdr.GetDecimal(rdr.GetOrdinal("grade"));
                        d["Grade"] = g;
                    }
                    else
                    {
                        d["Grade"] = "";
                    }

                    d["Student Id"] = sid;
                    d["Course Id"] = coid;
                    d["Assignment Number"] =assNo;
                    d["Assignment Type"] = assType;

                    dt.Rows.Add(d);
                }
          
                    gridView.DataSource = dt;
                    gridView.DataBind();
                conn.Close();
                SqlCommand test = new SqlCommand("if (not EXISTS(Select * From  Course " +
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

                 test = new SqlCommand("if (not EXISTS(Select * From  StudentTakeAssignment  " +
                    " where cid =" + courseId +")) print 's'", conn);
                 printOutput = "";
                conn.Open();
                test.ExecuteNonQuery();
                conn.Close();
                if (printOutput == "s")
                {
                    Response.Write("No assignments submitted for this course");
                    return;
                }



            }
            else
            {
                Response.Write("Please fill the textbox");
            }
        }

        protected void returnTohome_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHome.aspx");
        }

        
    }
}