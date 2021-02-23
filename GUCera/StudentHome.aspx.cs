using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class StudentHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addMobile_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMobile.aspx");
        }


        //Part One Methods

        protected void ViewProfile(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void ViewCourses(object sender, EventArgs e)
        {
            Response.Redirect("Courses.aspx");
        }

        protected void CreditCard(object sender, EventArgs e)
        {
            Response.Redirect("CreditCardPage.aspx");
        }

       

        protected void ViewPromoCode(object sender, EventArgs e)
        {
            Response.Redirect("PromoCodePage.aspx");
        }


        //Part Two Methods
        protected void viewAssignments_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAssignments.aspx");
        }

        protected void submitAssignments_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubmitAssignments.aspx");
        }

        protected void viewAssignmentGrade_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAssignmentGrade.aspx");
        }

        protected void addFeedbackToCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddFeedbackToCourse.aspx");
        }

        protected void listCourseCertificates_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListCourseCertificates.aspx");
        }
    }
}