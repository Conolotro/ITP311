using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class patientportal_updateparticulars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("login-register.aspx", false);
                }
                else
                {
                    //normal stuff here
                    string nric = Session["loggedIn"].ToString();
                    PatientBLL p = new PatientBLL();
                    PatientDAL pd = p.retrievePatientByNric(nric);
                    name.Text = pd.FirstName;
                }

            }
            else
            {
                Response.Redirect("login-register.aspx", false);
            }
        }
    }
}