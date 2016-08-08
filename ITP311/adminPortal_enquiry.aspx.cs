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
    public partial class adminPortal_enquiry : System.Web.UI.Page
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

                        string queryId = Request.QueryString["id"];
                        int id;
                        EnquiryDAL ed = null;
                        if (queryId != null)
                        {
                            id = Int32.Parse(queryId);
                        }
                        else
                        {
                            id = 0;
                        }

                        if (id > 0)
                        {
                            EnquiryBLL eb = new EnquiryBLL();
                            ed = eb.retrieveEnquiryByID(id);

                            name.Text = ed.name;
                            email.Text = ed.email;
                            messageEnquiry.Text = ed.message;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        Response.Redirect("adminlogin.aspx");
                    }
                    


                }

            }
        }

        protected async void submit_Click(object sender, EventArgs e)
        {
            string queryId = Request.QueryString["id"];
            EnquiryDAL ed = null;
            int id = 0;
            if (queryId != null)
            {
                id = Int32.Parse(queryId);
            }
            EnquiryBLL eb = new EnquiryBLL();
            ed = eb.retrieveEnquiryByID(id);
            await sendRegisterEmail(ed.email,replybox.Text);
            successMsg.Visible = true;
            replybox.Enabled = false;
        }

        protected async Task sendRegisterEmail(string email, string message)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(email);
            mailMessage.From = new MailAddress("silverwoodmedical311@gmail.com");
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Subject = "RE: Enquiry - Silverwood Medical Portal‏";
            string bodyMessage = message;
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = bodyMessage;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("silverwoodmedical311@gmail.com", "aspitp311");
            smtpClient.EnableSsl = true;
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}