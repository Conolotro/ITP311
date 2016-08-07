using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string name = inputName.Text.Trim();
            string email = inputEmail.Text.Trim();
            string enquiry = tbEnquiry.Text.Trim();

            if (enquiry.Length > 0)
            {
                EnquiryBLL eb = new EnquiryBLL();
                eb.createEnquiry(name, email, enquiry);
                successmsg.Visible = true;
            }


        }

        protected void reset_Click(object sender, EventArgs e)
        {
            tbEnquiry.Text = "";
        }
    }
}