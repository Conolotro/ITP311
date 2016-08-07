using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class patientportal_changepassword : System.Web.UI.Page
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

        protected void submit_Click(object sender, EventArgs e)
        {
            string nric = Session["loggedIn"].ToString();
            string current = inputCurrent.Text.Trim();
            string newpassword = formPassword.Text.Trim();
            string confirmNew = inputCNew.Text.Trim();

            if (current.Length > 0)
            {
                PatientBLL p = new PatientBLL();
                PatientDAL pd = p.retrievePatientByNric(nric);
                string passwordHash = PatientBLL.generatePasswordHash(current, pd.Salt);
                if (passwordHash.Equals(pd.PasswordHash))
                {
                    if (newpassword.Equals(confirmNew))
                    {
                        if (p.updatePassword(nric, newpassword) == true)
                        {
                            successMsg.Visible = true;
                            errorMsg.Visible = false;
                            inputCurrent.Enabled = false;
                            inputCNew.Enabled = false;
                            formPassword.Enabled = false;
                        }
                    }
                    else
                    {
                        Passwordmismatch.Visible = true;
                        errorMsg.Visible = false;
                    }
                }
                else
                {
                    errorMsg.Visible = true;
                    successMsg.Visible = false;
                    Passwordmismatch.Visible = false;
                }

            }
        }
    }
}