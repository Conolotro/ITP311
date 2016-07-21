using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITP311.BLL;
using ITP311.NYPSMS;

namespace ITP311
{
    public partial class patientportal_appoinment : System.Web.UI.Page
    {
        appointmentBLL Abll = new appointmentBLL();

        NYPSMS.SMS appsmsotp= new NYPSMS.SMS();

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



        }
        
    }
}