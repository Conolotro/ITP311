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
                    formPassword.Enabled = true;
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
            string password = formPassword.Text.Trim();
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
                DateTime timelater = keytime.AddMinutes(30);

                if (currenttime > timelater)
                {
                    PasswordResetBLL p = new PasswordResetBLL();
                    if (p.removePasswordReset(enteredkey) == true)
                    {
                        keyExpired.Visible = true;
                        error.Visible = false;
                        success.Visible = false;
                        networkError.Visible = false;
                        formPassword.Enabled = false;
                        inputConfirmPassword.Enabled = false;
                    }
                    else
                    {
                        networkError.Visible = true;
                        keyExpired.Visible = false;
                        error.Visible = false;
                        success.Visible = false;
                        formPassword.Enabled = false;
                        inputConfirmPassword.Enabled = false;

                    }
                }
                else
                {
                    PatientBLL p = new PatientBLL();
                    PatientDAL p2 = p.retrievePatientByNric(pr2.nric);
                    if (p.updatePassword(p2.Nric, password) == true)
                    {
                        success.Visible = true;
                        networkError.Visible = false;
                        keyExpired.Visible = false;
                        error.Visible = false;
                        pr.removePasswordReset(enteredkey);
                        inputConfirmPassword.Enabled = false;
                        formPassword.Enabled = false;
                        
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