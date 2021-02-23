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
    public partial class CreditCardPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddCC(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int id ;
            String ccNumber;
            String chName;
            DateTime expDate;
            String cvvInput;

            if(num.Text.Equals("") || name.Text.Equals("") || date.Text.Equals("") || cvv.Text.Equals(""))
            {
                Response.Write("<span style= 'color:red'>Unsuccessful attempt: Please fill in any blank fields</span>");
                return;
            }
            else
            {
                id = (int)Session["user"];
                ccNumber = num.Text;
                chName = name.Text;
                expDate = DateTime.Parse(date.Text);
                cvvInput = cvv.Text;

            }

            SqlCommand ccProc = new SqlCommand("addCreditCard", conn);
            ccProc.CommandType = CommandType.StoredProcedure;

            ccProc.Parameters.Add(new SqlParameter("@sid", id));
            ccProc.Parameters.Add(new SqlParameter("@number", ccNumber));
            ccProc.Parameters.Add(new SqlParameter("@cardHolderName", chName));
            ccProc.Parameters.Add(new SqlParameter("@expiryDate", expDate));
            ccProc.Parameters.Add(new SqlParameter("@CVV", cvvInput));

            conn.Open();
            try
            {
                ccProc.ExecuteNonQuery();
                Response.Write("<span style= 'color:green'>Successful attempt: Successfully added credit card</span>");
            }
            catch (Exception ex)
            {
                Response.Write("<span style= 'color:red'>Unsuccessful attempt: You have already added a credit card with the same number you entered, please enter another credit card number</span>");
            }
            conn.Close();
        }
    }
}