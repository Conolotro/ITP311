using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class adminportal : System.Web.UI.Page
    {
        String adminDesignation, nric;
        protected void Page_Load(object sender, EventArgs e)
        {
            firstOption.InnerText = (string)(Session["FullName"]);
            adminDesignation = (string)(Session["userDesignation"]);
            nric = (string)(Session["userNric"]);
            if (adminDesignation == "d" || adminDesignation == "s")
            {
                createDocPageLink.InnerHtml = "";
            }
            
        }

        protected void btnLogoutClick(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("adminlogin.aspx");
        }

    }
}