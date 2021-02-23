using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class DefineAssign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addAssign_Click(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);


            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //read user input
            int courseid = 0;
            int anumber = 0;
            int fullgrade = 0;
            Decimal weightt = 0;

            if (cid.Text.Length == 0 | number.Text.Length == 0 | grade.Text.Length == 0 | weight.Text.Length == 0)
            {
                Response.Write("Please fill all the textboxes");
                return;
            }
            try {
                 courseid = Int16.Parse(cid.Text);

            }
            catch (Exception) {
                Response.Write("Please enter number only in course id textbox");
                return;
            }

            try
            {
                anumber = Int16.Parse(number.Text);

            }
            catch (Exception)
            {
                Response.Write("Please enter number only in assignment number textbox");
                return;
            }

            try
            {
                fullgrade = Int16.Parse(grade.Text);

            }
            catch (Exception)
            {
                Response.Write("Please enter number only in full grade textbox");
                return;
            }

            try
            { 
                weightt = Decimal.Parse(weight.Text);

            }
            catch (Exception)
            {
                Response.Write("Please enter number only in Assignment weight textbox");
                return;
            }




            String deadline = deadlinee.Text;
            DateTime dt;
            if (!DateTime.TryParse(deadline, out dt)) { 
                Response.Write("Please enter deadline in the correct format");
                return;
            }
            String type = DropDownList1.SelectedValue.ToString();
            String contentt = content.Text;

            SqlCommand test = new SqlCommand("if (not EXISTS(select * from Course where id=" + courseid + ")) print 's'", conn);
            String printOutput = "";
            conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) => {
                printOutput += e1.Message;
            };
            conn.Open();
            test.ExecuteNonQuery();
            conn.Close();
            if (printOutput == "s")
            {
                Response.Write("This course id does not exists");
                return;
            }

            if ( deadline.Length>0 && type != "-1" && contentt.Length > 0 )
            {
                int id = Int16.Parse(Session["userId"].ToString());

                cmd.Parameters.Add(new SqlParameter("@instId", id));
                cmd.Parameters.Add(new SqlParameter("@cid", courseid));
                cmd.Parameters.Add(new SqlParameter("@number", anumber));
                cmd.Parameters.Add(new SqlParameter("@type", type));
                cmd.Parameters.Add(new SqlParameter("@weight", weightt));
                cmd.Parameters.Add(new SqlParameter("@fullGrade", fullgrade));
                cmd.Parameters.Add(new SqlParameter("@deadline", deadline));
                cmd.Parameters.Add(new SqlParameter("@content",contentt ));

                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    Response.Write("This assignment is already added");
                    conn.Close();
                    return;
                }

                conn.Close();

                Response.Write("Assignment added successfully");
            }
            else {
                Response.Write("Please fill all the inputs");
            }

        }

        protected void returnTohome_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHome.aspx");
        }
    }
}