using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class adminPortal_enquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string queryId = Request.QueryString["id"];
            int id;
            EnquiryDAL ed = null;
            if (queryId != null)
            {
               id = Int32.Parse(queryId);
            }
            else
            {
                id = 0;
            }
            
            if (id>0){
                EnquiryBLL eb = new EnquiryBLL();
                 ed = eb.retrieveEnquiryByID(id);

                 name.Text = ed.name;
                 email.Text = ed.email;
                 messageEnquiry.Text = ed.message;
            }
            else
            {

            }

           

        }


        protected void submit_Click(object sender, EventArgs e)
        {

        }
    }
}