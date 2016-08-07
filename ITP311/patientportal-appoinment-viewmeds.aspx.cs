using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Security.Cryptography;
using System.IO;
using System.Text;


namespace ITP311
{
    public partial class patientportal_appoinment_viewmeds : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("login-register.aspx", false);
                }
                else
                {
                    //normal stuff here
                    string nric = Session["loggedIn"].ToString();
                    PatientBLL p = new PatientBLL();
                    PatientDAL pd = p.retrievePatientByNric(nric);
                    name.Text = pd.FirstName;
                }

            }
            else
            {
                Response.Redirect("login-register.aspx", false);
            }

        }

        static byte[] Key;
        static byte[] IV; 

        //Generate a random key
        private void GenKey()
        {
            SymmetricAlgorithm sa = new RijndaelManaged(); 
            sa.GenerateKey();
            Key = sa.Key;
            IV = sa.IV;
            BitConverter.ToString(Key);
            lblKey.Text = BitConverter.ToString(Key);
        }


        private void encrypt()
        {
            GenKey();
            //Initialize instance for encryption 
            SymmetricAlgorithm sa = new RijndaelManaged();
            sa.Key = Key;
            sa.IV = IV;

            ICryptoTransform cryptTransform = sa.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(lblEnMeds.Text);
            byte[] cipherText = cryptTransform.TransformFinalBlock(plainText, 0, plainText.Length);
            lblCipher.Text = Convert.ToBase64String(cipherText);
        }

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            encrypt();
            //Initialize instance for decryption 
            SymmetricAlgorithm sa = new RijndaelManaged(); 
            sa.Key = Key; 
            sa.IV = IV;

            ICryptoTransform cryptTransform = sa.CreateDecryptor();
            byte[] cipherText = Convert.FromBase64String(lblCipher.Text); 
            byte[] plainText = cryptTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);

            lblShowMeds.Text = Encoding.UTF8.GetString(plainText); 
        }


    }
}