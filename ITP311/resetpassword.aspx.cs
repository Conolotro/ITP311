using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class resetpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string enteredkey = Request.QueryString["key"];
            PasswordResetBLL pr = new PasswordResetBLL();
            if (enteredkey != null)
            {
                string key = pr.retrieveKey(enteredkey);
                if (enteredkey.Equals(key))
                {
                    inputConfirmPassword.Enabled = true;
                    inputPassword.Enabled = true;
                }
                else
                {
                    Response.Redirect("error.aspx", false);
                }
            }
            else
            {
                Response.Redirect("error.aspx", false);
            }


        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string enteredkey = Request.QueryString["key"];
            string password = inputPassword.Text.Trim();
            string confirmPassword = inputConfirmPassword.Text.Trim();

            if (password.Equals(confirmPassword))
            {
                success.Visible = true;
                error.Visible = false;

                PasswordResetBLL pr = new PasswordResetBLL();
                PasswordResetDAL pr2 = pr.retrievePasswordReset(enteredkey);

                DateTime currenttime = DateTime.Now;
                DateTime keytime = pr2.creationDate;

                TimeSpan timediff = currenttime - keytime;
                success.Text = timediff.ToString();

                if (keytime.AddMinutes(30) > currenttime)
                {
                    PasswordResetBLL p = new PasswordResetBLL();
                    if (p.removePasswordReset(enteredkey) == true)
                    {
                        keyExpired.Visible = true;
                        error.Visible = false;
                        success.Visible = false;
                        networkError.Visible = false;
                    }
                    else
                    {
                        networkError.Visible = true;
                        keyExpired.Visible = false;
                        error.Visible = false;
                        success.Visible = false;

                    }
                }
                else
                {
                    PatientBLL p = new PatientBLL();
                    PatientDAL p2 = p.retrievePatientByNric(pr2.nric);
                    if (p.updatePassword(p2.Nric, password) == true)
                    {
                        success.Visible = false;
                        networkError.Visible = false;
                        keyExpired.Visible = false;
                        error.Visible = false;
                    }
                    else
                    {
                        success.Visible = false;
                        networkError.Visible = true;
                        keyExpired.Visible = false;
                        error.Visible = false;
                    }
                }



            }
            else
            {
                success.Visible = false;
                error.Visible = true;
            }

        }
    }
}