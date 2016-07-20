using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class forgetpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"];
            if (email != null)
            {
                Literal1.Visible = true;
            }
        }

        protected void emailForget_Click(object sender, EventArgs e)
        {
            
        }
    }
}