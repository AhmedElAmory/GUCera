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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //create new connection
            SqlConnection conn = new SqlConnection(connStr);

            int id;

            try
            {
            id = Int16.Parse(Username.Text);
            }
            catch
            {
                error.Text = "Please enter a number in the ID box";
                return;
            }

            String pass = Password.Text;

            SqlCommand loginproc = new SqlCommand("userLogin", conn);
            loginproc.CommandType = CommandType.StoredProcedure;


            loginproc.Parameters.Add(new SqlParameter("@id", id));
            loginproc.Parameters.Add(new SqlParameter("@password", pass));

            SqlParameter success = loginproc.Parameters.Add("@success", SqlDbType.Int);
            SqlParameter type = loginproc.Parameters.Add("@type", SqlDbType.Int);

            success.Direction = ParameterDirection.Output;
            type.Direction = ParameterDirection.Output;


            conn.Open();
            try
            {
                loginproc.ExecuteNonQuery();
            }
            catch
            {
                error.Text = "Something went Wrong!!";
                conn.Close();
                return;
            }
            conn.Close();

            if (success.Value.ToString()=="1")
            {
                Session["user"] = id;
                Session["userId"] = id;
                Session["userType"] = type.Value.ToString();
                if (type.Value.ToString() == "0")
                {
                    Response.Redirect("InstructorHome.aspx");
                }
                else if(type.Value.ToString() == "1")
                {
                    Response.Redirect("AdminHome.aspx");
                }
                else if(type.Value.ToString() == "2")
                {
                    Response.Redirect("StudentHome.aspx");
                }
            }
            else
            {
                error.Text="id or password is not correct";
            }

        }

        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}