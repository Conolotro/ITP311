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

            if (pr.CreatePasswordReset(nric, key, creationDate) == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public string retrieveKeybyNRIC(string nric)
        {
            PasswordResetDAL pr = new PasswordResetDAL();
            pr = pr.retrievePasswordResetByNric(nric);
            return pr.Codekey;
        }

        public string retrieveKey(string enteredkey)
        {
            PasswordResetDAL pr = new PasswordResetDAL();
            pr = pr.retrievePasswordReset(enteredkey);
            if (pr != null)
            {
                return pr.Codekey;
            }
            else
            {
                return null;
            }

        }

        public PasswordResetDAL retrievePasswordReset(string key)
        {
            PasswordResetDAL pr = new PasswordResetDAL();
            return pr.retrievePasswordReset(key);
        }

        public bool removePasswordReset(string key)
        {
            bool result = false;
            PasswordResetDAL pr = new PasswordResetDAL();
            if (pr.RemovePasswordReset(key) == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;

        }


        public bool removePasswordResetByEmail(string email)
        {
            bool result = false;
            PatientBLL pb = new PatientBLL();
            PatientDAL pd = pb.retrievePatientByEmail(email);
            PasswordResetDAL pr = new PasswordResetDAL();
            if (pr.RemovePasswordResetByNRIC(pd.Nric) == 1)
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

        public bool checkPasswordReset(string email)
        {
            bool result = false;
            PatientBLL p = new PatientBLL();
            PatientDAL p2 = p.retrievePatientByEmail(email);
            PasswordResetDAL pr = new PasswordResetDAL();
            pr = pr.retrievePasswordResetByNric(p2.Nric);
            if (pr == null)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }


    }
}