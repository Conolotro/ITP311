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

        static byte[] Key;
        static byte[] IV; 

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        //Generate a random key
        private void GenKey()
        {
            SymmetricAlgorithm sa = new RijndaelManaged(); 
            sa.GenerateKey();
            Key = sa.Key;
            IV = sa.IV;
            BitConverter.ToString(Key);
        }


        private void encrypt()
        {
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
                //Initialize instance for decryption 
                SymmetricAlgorithm sa = new RijndaelManaged(); 
                sa.Key = Key; 
                sa.IV = IV;

                ICryptoTransform cryptTransform = sa.CreateDecryptor();
                byte[] cipherText = Convert.FromBase64String(lblCipher.Text); 
                byte[] plainText = cryptTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);

                lblShowMeds.Text = Encoding.UTF8.GetString(plainText); 

        }

        //private void btnDecrypt_Click(object sender, EventArgs e)
        //{
        //    //Initialize instance for decryption 
        //    SymmetricAlgorithm sa = new RijndaelManaged(); 
        //    sa.Key = Key; 
        //    sa.IV = IV;

        //    ICryptoTransform cryptTransform = sa.CreateDecryptor(); 
        //    byte[] cipherText = Convert.FromBase64String(txtCipher.Text); 
        //    byte[] plainText = cryptTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);

        //    txtOrg.Text = Encoding.UTF8.GetString(plainText); 
        //    btnDecrypt.Enabled = false;
        //}


    }
}