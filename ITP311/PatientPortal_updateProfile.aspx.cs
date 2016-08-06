using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class PatientPortal_updateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["loggedIn"] != null)
                {
                    string nric = Session["loggedIn"].ToString();
                    PatientBLL pb = new PatientBLL();
                    PatientDAL pd = pb.retrievePatientByNric(nric);

                    inputFirstName.Text = pd.FirstName;
                    inputLastName.Text = pd.LastName;

                    inputFirstName.Enabled = false;
                    inputLastName.Enabled = false;
                    inputAddress.Text = pd.Address;
                    inputContact.Text = pd.ContactNo.ToString();
                    inputDOB.Text = pd.Dob;
                    inputEmail.Text = pd.Email;
                }
                else
                {
                    Response.Redirect("login-register.aspx", false);
                }
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string nric = Session["loggedIn"].ToString();
            PatientBLL pb = new PatientBLL();
            PatientDAL pd = pb.retrievePatientByNric(nric);
            string password = inputPassword.Text.Trim();
            string passwordHash = PatientBLL.generatePasswordHash(password,pd.Salt);
            if (passwordHash.Equals(pd.PasswordHash))
            {
                string address = inputAddress.Text.Trim();
                int contactNo = Int32.Parse(inputContact.Text.Trim());
                string dob = inputDOB.Text.Trim();
                string email = inputEmail.Text.Trim();
                if (pb.updatePatient(nric, contactNo, dob, email, address) == true)
                {
                    inputFirstName.Enabled = false;
                    inputLastName.Enabled = false;
                    inputAddress.Enabled = false;
                    inputContact.Enabled = false;
                    inputDOB.Enabled = false;
                    inputEmail.Enabled = false;
                    successMsg.Visible = true;
                }
                else
                {

                }
                
            }
            else
            {



            }
            

        }
    }
}