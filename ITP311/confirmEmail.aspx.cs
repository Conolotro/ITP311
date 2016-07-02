using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class confirmation : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailVerified = Request.QueryString["verified"];
            string email = Request.QueryString["email"];
            string code = Request.QueryString["
                "];

            if(email != null && code != null)
            {
                PatientBLL p = new PatientBLL();
                if(p.validateEmail(email,code) == true)
                {
                    panelHeading.Text = "Account Activated!";
                    panelBody.Text = "Your email has been confirmed. <br /> Please log into your account to change your password. ";
                }
                else
                {
                    panelHeading.Text = "Error";
                    panelBody.Text = "Invalid activation code";
                }

            }
            else if(emailVerified != null)
            {
                panelHeading.Text = "Account not activated!";
                panelBody.Text = "Please check your email to activate your account.";
            }
            else
            {
                panelHeading.Text = "Error";
                panelBody.Text = "Invalid activation code";
            }

        }

    }
}