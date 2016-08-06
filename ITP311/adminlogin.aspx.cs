using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace ITP311
{
    public partial class adminlogin : System.Web.UI.Page
    {
        public static int resetCounter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (resetCounter == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Dear User, you may now login using the pasword you have entered previously.');</script>");
                resetCounter = 0;
            }
            else if (resetCounter == 2)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Dear User, please check your email for the temporary password.');</script>");
                resetCounter = 0;
            }
        }

        protected void submitbutton_Click(object sender, EventArgs e)
        {
            AccountBLL ab = new AccountBLL();
            string name = formUsername.Text;
            string password = formPassword.Text;
            AccountDAL aa = ab.retrieveAccountByNric(name);
            try
            {
                string hashedPass = AccountBLL.generatePasswordHash(password, aa.passwordSalt);
                if (aa.passwordHash == hashedPass && password.IndexOf("IG") != -1)
                {
                    Session["userNric"] = aa.nric;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Dear User, you will be redirected to a page to reset your password.');</script>");
                    Response.Redirect("~/adminReset.aspx",false);
                }
                else if (aa.passwordHash == hashedPass && password.IndexOf("IG") == -1)
                {
                    Session["userNric"] = aa.nric;
                    Session["FullName"] = aa.lastName + " " + aa.firstName;
                    Session["userDesignation"] = aa.type;
                    Response.Redirect("adminportal.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Incorrect Password');</script>");
                }
            }
            catch(Exception a)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No user found with the username')</script>");
            }
        }
    }
}