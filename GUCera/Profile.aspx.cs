using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera_Website
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int id = (int)Session["user"];

            SqlCommand profile = new SqlCommand("viewMyProfile", conn);
            profile.CommandType = CommandType.StoredProcedure;
            profile.Parameters.Add(new SqlParameter("@id", id));

            

            conn.Open();
            SqlDataReader rdr = profile.ExecuteReader(CommandBehavior.CloseConnection);

            DataTable tb = new DataTable();
            tb.Load(rdr);
            tb.Columns.Add("Gender1", typeof(String));
            Byte[] gend= (Byte[])tb.Rows[0]["gender"];
            if (gend[0] == 0)
            {
                tb.Rows[0]["Gender1"] = "Male";
            }
            else
            {
                tb.Rows[0]["Gender1"] = "Female";
            }
            GridView1.DataSource = tb;

            GridView1.DataBind();
            


        }
    }
}