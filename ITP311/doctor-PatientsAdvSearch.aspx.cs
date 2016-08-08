using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class doctor_PatientsLogAdvSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                }
                else
                {
                    Response.Redirect("adminlogin.aspx");
                }
            }
        }
    }
}