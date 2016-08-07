using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class Doctor_PatientCreated : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userNric"] == null)
            {
                Response.Redirect("adminlogin.aspx");
            }
        }
    }
}