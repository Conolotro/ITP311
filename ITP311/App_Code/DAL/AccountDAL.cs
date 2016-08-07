using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ITP311.BLL;
using System.Collections;

namespace ITP311
{
    public class AccountDAL
    {

        public string nric { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string passwordHash { get; set; }
        public string passwordSalt { get; set; }
        public string email { get; set; }
        public string contactNo { get; set; }
        public string type { get; set; }

        public AccountDAL()
        {

        }

        public AccountDAL(string Nric,string passwordHash,string salt,string firstname,string lastName,string contactNo,string email,string type)
        {
            this.nric = Nric;
            this.passwordHash = passwordHash;
            this.passwordSalt = salt;
            this.firstName = firstname;
            this.lastName = lastName;
            this.contactNo = contactNo;
            this.email = email;
            this.type = type;
        }


        string cn = ConfigurationManager.ConnectionStrings["medicalportal"].ToString();


        public int CreateAccount(string nric, string firstName, string lastName, string passwordHash, string passwordSalt, string email, string contactNo, string type)
        {
            int result = 0;
            string strCommandText = "INSERT INTO Account(NRIC, FirstName, LastName, PasswordHash, PasswordSalt, Email, ContactNo, Type)"
                + "values (@nric,@firstname, @lastname, @passwordhash, @salt, @email, @contactNo,@type)";

            SqlConnection myConnection = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@nric", nric);
            cmd.Parameters.AddWithValue("@firstname", firstName);
            cmd.Parameters.AddWithValue("@lastname", lastName);
            cmd.Parameters.AddWithValue("@passwordhash", passwordHash);
            cmd.Parameters.AddWithValue("@salt", passwordSalt);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@contactNo", contactNo);
            cmd.Parameters.AddWithValue("@type", type);

            myConnection.Open();

            try
            {
                result += cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
                result = 0;
            }

            myConnection.Close();
            myConnection.Dispose();

            return result;
        }

        public int updatePasswordForUser(string nric, string hashedpass)
        {
            int result = 0;
            string strCommandText = "UPDATE Account SET PasswordHash='" + hashedpass + "' WHERE NRIC='"+nric+"'";
            SqlConnection myConnection = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            myConnection.Open();
            result = cmd.ExecuteNonQuery();
            myConnection.Close();
            return result;
        }

        public int updateUserProfile(string nric, string fName, string lName, string email, string contactNo)
        {
            int result = 0;
            string strCommandText = "UPDATE Account SET FirstName='"+fName+"', LastName='"+lName+"', Email='"+email+"', ContactNo='"+contactNo
                +"' WHERE NRIC='" + nric + "'";
            SqlConnection myConnection = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            myConnection.Open();
            result = cmd.ExecuteNonQuery();
            myConnection.Close();
            return result;
        }

        public AccountDAL retrieveAccount(string nric)
        {
            AccountDAL a = null;
            string strCommandText = "Select * from Account where NRIC = '"+nric+"'";
            string Nric, passwordHash, salt, firstname, lastname, contactNo, email, type;
            

            SqlConnection myConnection = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
    
            try
            {
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Nric = reader["Nric"].ToString();
                    passwordHash = reader["PasswordHash"].ToString();
                    salt = reader["PasswordSalt"].ToString();
                    firstname = reader["FirstName"].ToString();
                    lastname = reader["LastName"].ToString();
                    contactNo = reader["ContactNo"].ToString();
                    email = reader["Email"].ToString();
                    type = reader["Type"].ToString();


                    a = new AccountDAL (Nric, passwordHash, salt, firstname, lastname, contactNo, email,type);



                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { myConnection.Close(); }
            return a;
        }

      

        


       

    }

    }
