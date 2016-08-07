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
    public partial class forgetpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"];
            if (email != null)
            {
                error.Visible = true;
            }
        }

        protected async void emailForget_Click(object sender, EventArgs e)
        {
            string resetPasswordEmail = inputEmail.Text.Trim();
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
                Response.Redirect("/forgetPassword.aspx?email=invalid",false);
                
            }

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