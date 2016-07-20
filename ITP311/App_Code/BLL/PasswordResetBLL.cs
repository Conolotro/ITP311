using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ITP311
{
    public class PasswordResetBLL
    {
        public PasswordResetBLL()
        {

        }

        public bool createPatientPasswordReset(string nric)
        {
            bool result = false;

            DateTime creationDate = DateTime.Now;
            string key = generateKey();


            PasswordResetDAL pr = new PasswordResetDAL();

            if (pr.CreatePasswordReset(nric,key,creationDate) == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }


        public static string generateKey()
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[36];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(36);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

    }
}