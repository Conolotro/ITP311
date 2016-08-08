using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITP311.BLL;

using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Security.Authentication;

namespace ITP311
{
    public partial class patientportal_dashboard : System.Web.UI.Page
    {
        appointmentBLL Abll = new appointmentBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
                {
                    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                    {
                        Response.Redirect("login-register.aspx", false);
                    }
                    else
                    {
                        //normal stuff here
                        string nric = Session["loggedIn"].ToString();
                        PatientBLL p = new PatientBLL();
                        PatientDAL pd = p.retrievePatientByNric(nric);
                        name.Text = pd.FirstName;
                        name1.Text = pd.FirstName;
                    }

                }
                else
                {
                    Response.Redirect("login-register.aspx", false);
                }
               //GridViewAppinding();

            }
        }





        public void GridViewAppinding()
        {
            //Data Bind 
            gvApp.DataSource = Abll.BLL_Appointment();

            //Bind the control to the datasource
            gvApp.DataBind();

        }




        protected void btnView_Click(object sender, EventArgs e)
        {

         Response.Redirect("~/patientportal-appoinment-viewmeds.aspx");

        }



    }
}