using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITP311.BLL;

namespace ITP311
{
    public partial class patientportal_dashboard : System.Web.UI.Page
    {
        appointmentBLL Abll = new appointmentBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewAppinding();

            }
        }

        public void GridViewAppinding()
        {
            //Data Bind 
            gvApp.DataSource = Abll.BLL_Appointment();

            //Bind the control to the datasource
            gvApp.DataBind();

        }
    }
}