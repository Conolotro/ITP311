using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class doctor_index : System.Web.UI.Page
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
                    if (user.Equals("d"))
                    {
                        string Nric = Session["userNric"].ToString();
                        AccountBLL a = new AccountBLL();
                        AccountDAL ad = a.retrieveAccountByNric(Nric);
                        name.Text = ad.firstName;
                        this.AsyncMode = true;
                        Session["search"] = null;
                    }
                    else
                    {
                        Response.Redirect("adminlogin.aspx");
                    }
                    
                }
            }

            
        }
        protected void signUp_Click(object sender, EventArgs e)
        {
            string nric = formNRIC.Text.Trim();
            string password = nric;
            string firstName = formFN.Text.Trim();
            string lastName = formLN.Text.Trim();
            int contactNo = Int32.Parse(formPhone.Text.Trim());
            string email = formEmail.Text.Trim();
            string confirmEmail = formCEmail.Text.Trim();

            if (email.Equals(confirmEmail, StringComparison.OrdinalIgnoreCase))
            {
                PatientBLL patient = new PatientBLL();
                if (patient.createPatient(nric, password, firstName, lastName, contactNo, email) == true)
                {
                    try
                    {
                        sendEmail(nric);
                    }
                    catch (SmtpException ex)
                    {

                    }


                    Response.Redirect("Doctor-PatientCreated.aspx");
                }
                else
                {
                    Response.Redirect("error.aspx");
                }
            }
            else
            {
                //errorMessage.Text = "The Confirmation Email must match your Email Address";
            }

        }

        protected void sendEmail(string nric)
        {
            PatientBLL p = new PatientBLL();
            PatientDAL p2 = p.retrievePatientByNric(nric);

            string email = p2.Email;
   
            MailMessage mail = new MailMessage();
            mail.From = new System.Net.Mail.MailAddress("silverwoodmedical311@gmail.com");
            
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;   
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; 
            smtp.UseDefaultCredentials = false; 
            smtp.Credentials = new NetworkCredential("silverwoodmedical311@gmail.com", "aspitp311");  
            smtp.Host = "smtp.gmail.com";
            
            mail.To.Add(new MailAddress(email));
            mail.Subject = "Account Activation - Silverwood Medical Portal‏";
            string pw = p2.ContactNo.ToString();
            string bodyMessage = "Hello " + p2.FirstName + " " + p2.LastName + ",";
            bodyMessage += "<br /><br />Please click the following link to activate your account";
            bodyMessage += "<br /><a href = '" + "http://localhost:54660/confirmemail.aspx?email=" + p2.Email + "&" + "code=" + p2.Salt + "'>Click here to activate your account.</a>";
            bodyMessage += "<br /><br /> Your username is : " + p2.Nric;
            bodyMessage += "<br /> Your temporary password will be your phone number : ****" + pw.Substring(4, 4);
            bodyMessage += "<br /><br /> <b> Please change your password after you have logged in for the first time. </b>";
            mail.IsBodyHtml = true;
            mail.Body = bodyMessage;
            smtp.Send(mail);
        }

        protected void search_Click(object sender, EventArgs e)
        {
            string searchinfo = searchNric.Text;
            PatientsLogBLL plogbll = new PatientsLogBLL();
            DataTable dt = new DataTable();
            dt = plogbll.getDTGrid(searchinfo);
            if (dt.Rows.Count > 0)
            {
                
                Session["search"] = searchinfo;
                Response.Redirect("doctor-PatientsLog.aspx");
            }else{
                ErrorMsg.Text = "NRIC Not Available!";
            }
        }

      
        
    }
}