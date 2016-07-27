using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class resetpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {

            string password = inputPassword.Text.Trim();
            string confirmPassword = inputConfirmPassword.Text.Trim();

            if (password.Equals(confirmPassword))
            {
                success.Visible = true;
                error.Visible = false;


            }
            else
            {
                success.Visible = false;
                error.Visible = true;
            }

        }
    }
}