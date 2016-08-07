using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class login_register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                   
                }
                else
                {
                    Response.Redirect("patientportal-dashboard.aspx", false);
                }

            }
            else
            {
                
            }

        }

        protected void signIn_Click(object sender, EventArgs e)
        {
            string username = loginUsername.Text.Trim();
            string password = loginPassword.Text.Trim();

            PatientBLL patient = new PatientBLL();
            if (patient.retrievePatientLogin(username, password) == true)
            {
                if (patient.EmailConfirmed(username) == true)
                {
                    Session["loggedIn"] = username;

                    //create a new GUID and save into session
                    string guid = Guid.NewGuid().ToString();
                    Session["AuthToken"] = guid;
                    //create a new cookie with guid value;
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                    Response.Redirect("patientportal-dashboard.aspx", false);
                }
                else
                {
                    Response.Redirect("confirmEmail.aspx?verified=false", false);
                }

            }
            else
            {
                loginError.Visible = true;
            }
        }

        protected async void signUp_Click(object sender, EventArgs e)
        {
            errorMessage.Text = " ";
            if (formNRIC.Text.Length != 0 && formPassword.Text.Length != 0 && formFN.Text.Length != 0 && formLN.Text.Length !=0 && formPhone.Text.Length != 00)
            {             
                string nric = formNRIC.Text.Trim();
                string password = formPassword.Text.Trim();
                string firstName = formFN.Text.Trim();
                string lastName = formLN.Text.Trim();
                int contactNo = 0;
                try
                {
                    contactNo = Int32.Parse(formPhone.Text.Trim());
                }
                catch (FormatException ex)
                {
                    contactNo = 0;
                }
                string email = formEmail.Text.Trim();
                string confirmEmail = formCEmail.Text.Trim();


                if (email.Equals(confirmEmail, StringComparison.OrdinalIgnoreCase))
                {
                    PatientBLL patient = new PatientBLL();
                    if (patient.checkPatientbyNRIC(nric) == true)
                    {
                        errorMessage.Text = "The nric you have entered has already registered.";
                    }
                    else
                    {
                        if (patient.createPatient(nric, password, firstName, lastName, contactNo, email) == true)
                        {
                            await sendRegisterEmail(email);
                            Response.Redirect("registered.aspx", false);
                        }
                        else
                        {
                            errorMessage.Text = "Database Error";
                        }
                    }
                    
                }
                else
                {
                    errorMessage.Text = "The Confirmation Email must match your Email Address <br />";
                }
           
            }
            else
            {
                errorMessage.Text += "Please fill up all fields";
            }
            


        }


        protected async void resetPassword_Click(object sender, EventArgs e)
        {
            string resetPasswordEmail = forgetEmail.Text.Trim();
            PatientBLL p = new PatientBLL();
            if (p.checkPatientbyEmail(resetPasswordEmail) == true)
            {
                PasswordResetBLL pr = new PasswordResetBLL();
                if (pr.checkPasswordReset(resetPasswordEmail) == true)
                {
                    string nric = p.retrievePatientNRICbyEmail(resetPasswordEmail);
                    pr.createPatientPasswordReset(nric);
                    success.Visible = true;
                    await sendForgetPasswordEmail(resetPasswordEmail);
                }
                else
                {
                    if (pr.removePasswordResetByEmail(resetPasswordEmail) == true)
                    {
                        string nric = p.retrievePatientNRICbyEmail(resetPasswordEmail);
                        pr.createPatientPasswordReset(nric);
                        success.Visible = true;
                        await sendForgetPasswordEmail(resetPasswordEmail);
                    }
                    else
                    {
                        errorMsg.Visible = true;
                    }
                }


            }
            else
            {
                Response.Redirect("/forgetPassword.aspx?email=invalid", false);
                Context.ApplicationInstance.CompleteRequest();
            }

        }


        protected async Task sendRegisterEmail(string nric)
        {
            PatientBLL p = new PatientBLL();
            PatientDAL p2 = p.retrievePatientByEmail(nric);

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(p2.Email);
            mailMessage.From = new MailAddress("silverwoodmedical311@gmail.com");
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Subject = "Account Activation - Silverwood Medical Portal‏";

            string bodyMessage = "Hello " + p2.FirstName + " " + p2.LastName + ",";
            bodyMessage += "<br /><br />Please click the following link to activate your account";
            bodyMessage += "<br /><a href = '" + "http://localhost:54660/confirmemail.aspx?email=" + Server.UrlEncode(p2.Email) + "&" + "code=" + Server.UrlEncode(p2.Salt) + "'>Click here to activate your account.</a>";

            mailMessage.IsBodyHtml = true;
            mailMessage.Body = bodyMessage;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("silverwoodmedical311@gmail.com", "aspitp311");
            smtpClient.EnableSsl = true;
            await smtpClient.SendMailAsync(mailMessage);
        }


        protected async Task sendForgetPasswordEmail(string email)
        {
            PatientBLL p = new PatientBLL();
            PatientDAL p2 = p.retrievePatientByEmail(email);
            PasswordResetBLL pr = new PasswordResetBLL();
            string code = pr.retrieveKeybyNRIC(p2.Nric);

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(p2.Email);
            mailMessage.From = new MailAddress("silverwoodmedical311@gmail.com");
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Subject = "Forgetten Password- Silverwood Medical Portal‏";

            string bodyMessage = "Hello " + p2.FirstName + " " + p2.LastName + ",";
            bodyMessage += "<br /><br />You recently requested to reset your password for your Silverwood Medical account.";
            bodyMessage += "<br /><a href = '" + "http://localhost:54660/resetpassword.aspx?key=" + Server.UrlEncode(code) + "'>Click here to reset your password.</a>";
            bodyMessage += "<br /><br /> If you did not request for a password reset, please ignore this email or reply to let us know. This password reset is only valid for the next 30 minutes.";
            bodyMessage += "<br /><br /> Thanks,<br /> Sliverwood Medical Team";

            mailMessage.IsBodyHtml = true;
            mailMessage.Body = bodyMessage;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("silverwoodmedical311@gmail.com", "aspitp311");
            smtpClient.EnableSsl = true;
            await smtpClient.SendMailAsync(mailMessage);
        }



    }

}