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

        //SMS
        NYPSMS.SMSService appsms = new SMSService();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (ddlDate.SelectedIndex == 0 || ddlMonth.SelectedIndex == 0 || ddlTime.SelectedIndex == 0 || ddlLocation.SelectedIndex == 0)
            {
                lblError.Visible = true;
                lblError.Text = "You did not make a selection in one or more drop down lists!";
            }

            else
            {
                Abll.appDate = (ddlDate.SelectedItem.Text + "-" + ddlMonth.SelectedItem.Text);
                Abll.appTime = ddlTime.SelectedItem.Text;
                Abll.appLocation = ddlLocation.SelectedItem.Text;
                Abll.insertNewAppointmentRecord();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('You have successfully entered a new entry');</script>");


                //SMS
                string MobileNo = "90304831";
                string Message = "Your appointment has been scheduled on this day: " + ddlDate.SelectedItem.Text + "-"
                    + ddlMonth.SelectedItem.Text + " " + "at" + " " + ddlTime.SelectedItem.Text + " " + "at" + " " 
                    + ddlLocation.SelectedItem.Text;
                string SMSAccount = "ASPJ40";
                string SMSPassword = "635033";

                string sendSMS = appsms.sendMessage(MobileNo, Message, SMSAccount, SMSPassword);

                //Reset the DDLs
                ddlDate.SelectedIndex = 0;
                ddlMonth.SelectedIndex = 0;
                ddlLocation.SelectedIndex = 0;

                //Remove a timing so that it can't be used in new appointments
                ddlTime.Items.Remove(ddlTime.SelectedItem.ToString());

            }


        }





        //protected void GenerateOTP(object sender, EventArgs e)
        //{
        //    string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //    string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
        //    string numbers = "1234567890";

        //    string characters = numbers;
        //    if (rbType.SelectedItem.Value == "1")
        //    {
        //        characters += alphabets + small_alphabets + numbers;
        //    }
        //    int length = int.Parse(ddlLength.SelectedItem.Value);
        //    string otp = string.Empty;
        //    for (int i = 0; i < length; i++)
        //    {
        //        string character = string.Empty;
        //        do
        //        {
        //            int index = new Random().Next(0, characters.Length);
        //            character = characters.ToCharArray()[index].ToString();
        //        } while (otp.IndexOf(character) != -1);
        //        otp += character;
        //    }
        //    lblOTP.Text = otp;
        //}

        
    }
}