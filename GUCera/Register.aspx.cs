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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerAsStudent(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //create new connection
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand studentRegisterproc = new SqlCommand("studentRegister", conn);
            studentRegisterproc.CommandType = CommandType.StoredProcedure;

            if (firstName.Text.Equals("") | lastName.Text.Equals("") | password.Text.Equals("") | email.Text.Equals("") | address.Text.Equals(""))
            {
                error.Text = "Please fill all the fields";
                return;
            }


            studentRegisterproc.Parameters.Add(new SqlParameter("@first_name", firstName.Text));
            studentRegisterproc.Parameters.Add(new SqlParameter("@last_name", lastName.Text));
            studentRegisterproc.Parameters.Add(new SqlParameter("@password", password.Text));
            studentRegisterproc.Parameters.Add(new SqlParameter("@email", email.Text));
            studentRegisterproc.Parameters.Add(new SqlParameter("@gender", Gender.SelectedValue));
            studentRegisterproc.Parameters.Add(new SqlParameter("@address", address.Text));

            conn.Open();
            try
            {
            studentRegisterproc.ExecuteNonQuery();
            }
            catch
            {
                error.Text = "The email is already registered";
                Button1.Visible = true;
                conn.Close();
                return;
            }
            conn.Close();

            Button1.Visible = true;
            error.Text = "user registered successfully";
            
        }

        protected void registerAsInstructor(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //create new connection
            SqlConnection conn = new SqlConnection(connStr);
            
            SqlCommand instructorRegisterproc = new SqlCommand("InstructorRegister", conn);
            instructorRegisterproc.CommandType = CommandType.StoredProcedure;

            if (firstName.Text.Equals("") | lastName.Text.Equals("") | password.Text.Equals("") | email.Text.Equals("") | address.Text.Equals(""))
            {
                error.Text = "Please fill all the fields";
                return;
            }

            instructorRegisterproc.Parameters.Add(new SqlParameter("@first_name", firstName.Text));
            instructorRegisterproc.Parameters.Add(new SqlParameter("@last_name", lastName.Text));
            instructorRegisterproc.Parameters.Add(new SqlParameter("@password", password.Text));
            instructorRegisterproc.Parameters.Add(new SqlParameter("@email", email.Text));
            instructorRegisterproc.Parameters.Add(new SqlParameter("@gender", Gender.SelectedValue));
            instructorRegisterproc.Parameters.Add(new SqlParameter("@address", address.Text));

            conn.Open();
            try
            {
            instructorRegisterproc.ExecuteNonQuery();
            }
            catch
            {
                error.Text = "The email is already registered";
                Button1.Visible = true;
                conn.Close();
                return;
            }
            conn.Close();

            Button1.Visible = true;
            error.Text = "user registered successfully";
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }
}