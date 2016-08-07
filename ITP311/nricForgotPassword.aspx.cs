using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Security;

namespace ITP311
{
    public partial class nricForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
        }

        protected void submitbutton_Click(object sender, EventArgs e)
        {
            AccountBLL a = new AccountBLL();
            AccountDAL a2 = a.retrieveAccountByNric(formNRIC.Text);
            if (a2 != null)
            {
                string password = "IG" + Membership.GeneratePassword(10, 1);
                sendEm(formNRIC.Text, password);
                password = AccountBLL.generatePasswordHash(password, a2.passwordSalt);
                a.updatePasswordForUser(formNRIC.Text, password);
                adminlogin.resetCounter = 2;
                Response.Redirect("adminlogin.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No user found with this NRIC.');</script>");
            }
        }

        protected void cancel_buttonClick(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void sendEm(string nric, string password)
        {
            AccountBLL a = new AccountBLL();
            AccountDAL a2 = a.retrieveAccountByNric(nric);

            var fromAddress = new MailAddress("silverwoodmedical311@gmail.com", "silverwoodmedical311");
            var toAddress = new MailAddress(a2.email);
            const string fromPassword = "aspitp311";
            const string subject = "Forgot Password - Silverwood Medical Portal";
            string bodyMessage = "Hello " + a2.firstName + " " + a2.lastName + ",";
            bodyMessage += "\n\nYour username is: " + a2.nric;
            bodyMessage += "\n Your Password will be : " + password;
            bodyMessage += "\n\n Please change your password after you have logged in for the first time";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = bodyMessage
            })
            {
                smtp.Send(message);
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}