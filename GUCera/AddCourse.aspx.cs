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
    public partial class AddCourse : System.Web.UI.Page
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


            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("InstAddCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //read user input
            String name = cname.Text;
            int credithours = 0;
            Decimal pricee = 0;
            if (hours.Text.Length ==0| price.Text.Length==0) {
                Response.Write("Please fill all the textboxes");
                return;
            }
            try { 
                credithours = Int16.Parse(hours.Text);
            } 
            catch (Exception) { 
                Response.Write("Please enter numbers only in credit hours textbox");
                return;
            }
            try { 
                pricee = Decimal.Parse(price.Text); 
            } catch (Exception)
            {
                Response.Write("Please enter numbers only in price textbox");
                return;
            }

            if (name.Length<=10 && name.Length>0 && hours.Text.Length>0 && price.Text.Length >0 ) {
                int id = Int16.Parse(Session["userId"].ToString());

                cmd.Parameters.Add(new SqlParameter("@instructorId", id));
                cmd.Parameters.Add(new SqlParameter("@price", pricee));
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@creditHours", credithours));

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception) {
                    Response.Write("This Coure is already added");
                    conn.Close();
                    return;
                }
                conn.Close();

                Response.Write("Course added successfully");
            }
            else {
                Response.Write("Please fill all the textboxes");
            }
        }

        protected void returnTohome_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHome.aspx");
        }
    }
}