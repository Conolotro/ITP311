using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ITP311
{
    public class EnquiryBLL
    {

        public EnquiryBLL()
        {

        }

        public bool createEnquiry(string name, string email, string message)
        {
            bool result = false;
            byte[] key;
            byte[] IV;

            DateTime dateTime = DateTime.Now;
            EnquiryDAL ed = new EnquiryDAL();


            SymmetricAlgorithm ciper = new RijndaelManaged();
            ciper.GenerateKey();
            //ciper.GenerateIV();
            key = ciper.Key;
            IV = ciper.IV;

           string SK = Convert.ToBase64String(key);
           string StringIV = Convert.ToBase64String(IV);

            ciper.Key = key;
            ciper.IV = IV;

            ICryptoTransform cryptTransform = ciper.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(message);
            byte[] cipherText = cryptTransform.TransformFinalBlock(plainText, 0, plainText.Length);
            string encryptedMessage = Convert.ToBase64String(cipherText);
           

            if (ed.CreateEnquiry(name, email, encryptedMessage, dateTime, SK, StringIV) == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public EnquiryDAL retrieveEnquiryByID(int id)
        {
            EnquiryDAL e = new EnquiryDAL();
            e = e.retrieveEnquiryById(id);
            string encryptedMessage = e.message;

            //Initialize instance for decryption
            SymmetricAlgorithm sa = new RijndaelManaged();
            sa.Key = Convert.FromBase64String(e.SK);
            sa.IV = Convert.FromBase64String(e.IV);

            ICryptoTransform cryptTransform = sa.CreateDecryptor();
            byte[] cipherText = Convert.FromBase64String(encryptedMessage);
            byte[] plainText = cryptTransform.TransformFinalBlock(cipherText, 0,
            cipherText.Length);
            string decryptedMessage = Encoding.UTF8.GetString(plainText);
            e.message = decryptedMessage;

            return e;
        }


    }
}