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
    public partial class PromoCodePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int id = (int)Session["user"];

            SqlCommand pcProc = new SqlCommand("viewPromocode", conn);
            pcProc.CommandType = CommandType.StoredProcedure;
            pcProc.Parameters.Add(new SqlParameter("@sid", id));



            conn.Open();
            SqlDataReader rdr = pcProc.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable tb = new DataTable();
            tb.Load(rdr);

            GridView1.DataSource = tb;

            GridView1.DataBind();
        
        }
    }
}