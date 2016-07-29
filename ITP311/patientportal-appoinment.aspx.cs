using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITP311.BLL;
using ITP311.NYPSMS;
using System.Net;

namespace ITP311
{
    public partial class patientportal_appoinment : System.Web.UI.Page
    {
        appointmentBLL Abll = new appointmentBLL();

        //SMS (?)
        NYPSMS.SMS appsms = new SMS();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Abll.appDate = (ddlDate.SelectedItem.Text + "-" + ddlMonth.SelectedItem.Text);
            Abll.appTime = ddlTime.SelectedItem.Text;
            Abll.appLocation = ddlLocation.SelectedItem.Text;
            Abll.insertNewAppointmentRecord();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('You have successfully entered a new entry');</script>");

            ddlDate.SelectedIndex = 0;
            ddlTime.SelectedIndex = 0;
            ddlLocation.SelectedIndex = 0;

            appsms.message = "Your appointment has been scheduled on this day";


        }//Submit button

        public string sendMessage(string MobileNo, string Message, string SMSAccount, string SMSPassword)
        {
            NYPSMS.SMS appsms2 = new SMS();
            MobileNo = "90304831";
            Message = "Your appointment has been scheduled on this day" + ddlDate.SelectedItem.Text;
            SMSAccount = "ASPJ40";
            SMSPassword = "635033";

            return sendMessage(MobileNo, Message, SMSAccount, SMSPassword);
        }









        protected void GenerateOTP(object sender, EventArgs e)
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            if (rbType.SelectedItem.Value == "1")
            {
                characters += alphabets + small_alphabets + numbers;
            }
            int length = int.Parse(ddlLength.SelectedItem.Value);
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            lblOTP.Text = otp;
        }

        
    }
}