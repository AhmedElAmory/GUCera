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
    public partial class ViewAssignments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void viewAssignmentsButton_Click(object sender, EventArgs e)
        {
            if (viewAssignmentsCourseNumber.Text.Equals(""))
            {
                viewAssignError.Text = "Please enter the course number";
            }
            else
            {
                try
                {
                    Int16.Parse(viewAssignmentsCourseNumber.Text);
                }
                catch
                {
                    viewAssignError.Text = "Please enter a number in the course number box";
                    return;
                }
                Response.Redirect("ViewAssignmentResult.aspx?courseID=" + viewAssignmentsCourseNumber.Text);
            }
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}