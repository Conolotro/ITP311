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
    public partial class adminportal_updateProfile : System.Web.UI.Page
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

                    string nric = Session["userNric"].ToString();
                    AccountBLL a = new AccountBLL();
                    AccountDAL ad = a.retrieveAccountByNric(nric);
                    name.Text = ad.firstName;
                    tbNric.Text = nric;
                    tbFname.Text = ad.firstName;
                    tbLname.Text = ad.lastName;
                    tbEmail.Text = ad.email;
                    tbContact.Text = ad.contactNo;
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbLname.Text != "" && tbFname.Text != "" && tbEmail.Text != "" && tbContact.Text != "")
            {
                if (IsValidEmail(tbEmail.Text) == true)
                {
                    AccountBLL a = new AccountBLL();
                    a.updateUserProfile(tbNric.Text, tbFname.Text, tbLname.Text, tbEmail.Text, tbContact.Text);
                    sendEmail(tbNric.Text);
                    Response.Redirect("adminportal.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Email invalid.');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please ensure all fields are filled');</script>");
            }
        }

        protected void sendEmail(string nric)
        {
            AccountBLL a = new AccountBLL();
            AccountDAL a2 = a.retrieveAccountByNric(nric);

            var fromAddress = new MailAddress("silverwoodmedical311@gmail.com", "silverwoodmedical311");
            var toAddress = new MailAddress(a2.email);
            const string fromPassword = "aspitp311";
            const string subject = "Update of Profile - Silverwood Medical Portal";
            string bodyMessage = "Hello " + a2.firstName + " " + a2.lastName + ",";
            bodyMessage += "\n\nThis is to inform you that you have successfully changed your profile details.\n\nIf this is not done by you, please contact 67811315 \n\nBest Regards,\nSilverWood Medical";

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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminportal.aspx");
        }
    }
    
}


