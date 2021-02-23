using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class InstructorHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addMobile_Click(object sender, EventArgs e)
        {
            Response.Redirect("addMobile.aspx");
        }

        protected void addCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCourse.aspx");
        }

        protected void addAssignment_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefineAssign.aspx");
        }

        protected void viewAssign_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewAssignmentOfStudents.aspx");
        }

        protected void addContentDescription_Click(object sender, EventArgs e)
        {
            Response.Redirect("addContentAndDescription.aspx");
        }

        protected void grading_Click(object sender, EventArgs e)
        {
            Response.Redirect("gradeAssign.aspx");
        }

        protected void certificate_Click(object sender, EventArgs e)
        {
            Response.Redirect("certificate.aspx");
        }

        protected void viewFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewFeedbacks.aspx");
        }
    }
}