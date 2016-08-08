using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ITP311.BLL;
using ITP311.DAL;
using System.Web.Security;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace ITP311
{
    public partial class adminportal_createDoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userNric"] == null)
                {
                    Response.Redirect("adminlogin.aspx");
                }
                else
                {
                    string user = Session["userDesignation"].ToString();
                    if (user.Equals("a"))
                    {
                        string Nric = Session["userNric"].ToString();
                        AccountBLL a = new AccountBLL();
                        AccountDAL ad = a.retrieveAccountByNric(Nric);
                        name.Text = ad.firstName;
                    }
                    else
                    {
                        Response.Redirect("adminlogin.aspx");
                    }
                }

            }
        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            string nric = tbNric.Text.Trim();
            string firstName = tbFname.Text.Trim();
            string lastName = tbLname.Text.Trim();
            string contactNo = tbContact.Text.Trim();
            string email = tbEmail.Text.Trim();
            string type = ddlType.SelectedValue;


            string password = "IG"+Membership.GeneratePassword(10,1);
            AccountBLL acc = new AccountBLL();

            if (IsValidEmail(email))
            {
                if (acc.CreateAccount(nric, firstName, lastName, password, email, contactNo, type) == true)
                {
                    await sendEmail(nric, password);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Staff profile successfully created.');</script>");

                    tbNric.Text = "";
                    tbFname.Text = "";
                    tbLname.Text = "";
                    tbContact.Text = "";
                    tbEmail.Text = "";
                    ddlType.SelectedValue = "";
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Duplicated Staff Profile.');</script>");
                }

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Duplicated Staff Profile.');</script>");
            }

        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        protected async Task sendEmail(string nric,string password)
        {
            AccountBLL a = new AccountBLL();
            AccountDAL a2 = a.retrieveAccountByNric(nric);

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(a2.email);
            mailMessage.From = new MailAddress("silverwoodmedical311@gmail.com");
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Subject = "Account Activation - Silverwood Medical Portal‏";

            string bodyMessage = "Hello " + a2.firstName + " " + a2.lastName + ",";
            bodyMessage += "<br /><br />Please click the following link to activate your account";
            bodyMessage += "<br /><a href = '" + "http://localhost:54660/confirmemail.aspx?email=" + a2.email + "&" + "code=" + a2.passwordSalt + "'>Click here to activate your account.</a>";
            bodyMessage += "<br /><br /> Your username will be : " + a2.nric;
            bodyMessage += "<br /> Your Password will be : " + password;
            bodyMessage += "<br /><br /> <b> Please change your password after you have logged in for the first time </b>";

            mailMessage.IsBodyHtml = true;
            mailMessage.Body = bodyMessage;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("silverwoodmedical311@gmail.com", "aspitp311");
            smtpClient.EnableSsl = true;
            await smtpClient.SendMailAsync(mailMessage);
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected async void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminportal.aspx");
        }

    
    }

}


