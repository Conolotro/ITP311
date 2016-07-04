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
                    Response.Redirect("registered.aspx", false);
                }
                else
                {
                    Response.Redirect("confirmEmail.aspx?verified=false", false);
                }

            }
            else
            {
                Response.Redirect("error.aspx", false);
            }
        }

        protected async void signUp_Click(object sender, EventArgs e)
        {
            string nric = formNRIC.Text.Trim();
            string password = formPassword.Text.Trim();
            string firstName = formFN.Text.Trim();
            string lastName = formLN.Text.Trim();
            int contactNo = Int32.Parse(formPhone.Text.Trim());
            string email = formEmail.Text.Trim();
            string confirmEmail = formCEmail.Text.Trim();


            if (email.Equals(confirmEmail,StringComparison.OrdinalIgnoreCase))
            {
                PatientBLL patient = new PatientBLL();
                if (patient.createPatient(nric, password, firstName, lastName, contactNo, email) == true)
                {
                    try
                    {
                        await sendEmail(nric);
                    }
                    catch (SmtpException ex)
                    {
                       
                    }
                    

                    Response.Redirect("registered.aspx");
                }
                else
                {
                    Response.Redirect("error.aspx");
                }
            }
            else
            {
                errorMessage.Text = "The Confirmation Email must match your Email Address";
            }
           


        }

        protected async Task sendEmail(string nric)
        {
            PatientBLL p = new PatientBLL();
            PatientDAL p2 = p.retrievePatientByNric(nric);

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(p2.Email);
            mailMessage.From = new MailAddress("silverwoodmedical311@gmail.com");
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Subject = "Account Activation - Silverwood Medical Portal‏";

            string bodyMessage = "Hello " + p2.FirstName + " " + p2.LastName + ",";
            bodyMessage += "<br /><br />Please click the following link to activate your account";
            bodyMessage += "<br /><a href = '" + "http://localhost:54660/confirmemail.aspx?email=" + p2.Email + "&" + "code=" + p2.Salt + "'>Click here to activate your account.</a>";
            bodyMessage += "<br /><br /> Your username will be : " + p2.Nric;
            bodyMessage += "<br /> Your Password will be : " + p2.ContactNo;
            bodyMessage += "<br /><br /> <b> Please change your password after you have logged in for the first time </b>";

            mailMessage.IsBodyHtml = true;
            mailMessage.Body = bodyMessage;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("silverwoodmedical311@gmail.com", "aspitp311");
            smtpClient.EnableSsl = true;
            await smtpClient.SendMailAsync(mailMessage);
        }



    }

}