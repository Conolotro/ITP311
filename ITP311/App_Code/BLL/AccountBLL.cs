using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using ITP311.DAL;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace ITP311
{
    public class AccountBLL
    {
        public AccountBLL()
        {

        }


        public bool CreateAccount(string NRIC, string fname, string lname, string password, string Email, string ContactNo, string type)
        {
            bool result = false;
            AccountDAL acct = new AccountDAL();
            string salt = generateSalt();
            string passwordHash = generatePasswordHash(password, salt);
            if (acct.CreateAccount(NRIC, fname, lname, passwordHash, salt, Email, ContactNo, type) == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
           
        }

        public static string generateSalt()
        {
            //Generate random "salt"
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltByte = new byte[32];
            //Fills array of bytes with a cryptographically strong sequence of random values.
            rng.GetBytes(saltByte);
            string salt = Convert.ToBase64String(saltByte);
            return salt;
        }

        public static string generatePasswordHash(string password, string salt)
        {
            //concate password with hash
            string passwordWithSalt = String.Concat(password, salt);

            //convert string to bytes
            byte[] rawTextBytes = Encoding.UTF8.GetBytes(passwordWithSalt);

            //hashing
            SHA512Managed sha512 = new SHA512Managed();
            byte[] hashedBytes = sha512.ComputeHash(rawTextBytes);

            //onverts the 64 bytes hash into a string
            string hashedPassword = BitConverter.ToString(hashedBytes);
            return hashedPassword;
        }

        public AccountDAL retrieveAccountByNric(string nric)
        {
            AccountDAL a = new AccountDAL();
            return a.retrieveAccount(nric);
        }




    }
}