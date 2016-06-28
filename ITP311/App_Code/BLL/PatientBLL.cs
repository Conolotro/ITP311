using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ITP311
{
    public class PatientBLL
    {
        public PatientBLL()
        {

        }

        public bool createPatient(string nric, string firstName, string lastName, int contactNo, string email)
        {
            bool result = false;
            string salt = generateSalt();
            string passwordHash = generatePasswordHash(contactNo.ToString(), salt);

            PatientDAL patient = new PatientDAL();

            if (patient.createPatient(nric, passwordHash, salt, firstName, lastName, contactNo, email) == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
           
            return result;
        }

        public bool retrievePatientLogin(string username, string password)
        {
            bool result = false;

            PatientDAL p = new PatientDAL();
            PatientDAL p2 = p.retrievePatient(username);

            string userPasswordHash = generatePasswordHash(password, p2.Salt);

            if (userPasswordHash.Equals(p2.PasswordHash)){
                result = true;
            }
            else
            {
                result = false;
            }
           

            return result;
        }

        public PatientDAL retrievePatientByNric(string nric)
        {
            PatientDAL p = new PatientDAL();
            return p.retrievePatient(nric);
        }

        public bool validateEmail(string email, string code)
        {
            bool result = false;

            PatientDAL p = new PatientDAL();
            PatientDAL p2 = p.retrievePatientbyEmail(email);

            if (p2 != null) {
                if (p2.Salt.Equals(code))
                {
                    result = true;
                    p.updatePatientEmailConfirmation(p2.Nric);
                    
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }



            return result;
        }

        public bool EmailConfirmed(string username)
        {
            bool result = false;
            PatientDAL p = new PatientDAL();
            p = p.retrievePatient(username);
            if(p.ConfirmedEmail == true)
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

        public static string generatePasswordHash(string password,string salt)
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

    }
}