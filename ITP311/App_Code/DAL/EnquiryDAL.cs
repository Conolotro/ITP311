using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ITP311
{
    public class Enquiry
    {
        public int id { get; set; }
        public string name{ get; set; }
        public string email { get; set; }
        public string message { get; set; }
        public DateTime dateTime { get; set; }

        public Enquiry()
        {

        }

        public Enquiry(int id, string name, string email, string message)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.message = message;

        }

        string cn = ConfigurationManager.ConnectionStrings["medicalportal"].ToString();

        public int CreateEnquiry(string name, string firstName, string lastName, string passwordHash, string passwordSalt, string email, string contactNo, string type)
        {
            int result = 0;
            string strCommandText = "INSERT INTO Account(NRIC, FirstName, LastName, PasswordHash, PasswordSalt, Email, ContactNo, Type)"
                + "values (@nric,@firstname, @lastname, @passwordhash, @salt,  @contactNo, @email,@type)";

            SqlConnection myConnection = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@firstname", firstName);
            cmd.Parameters.AddWithValue("@lastname", lastName);
            cmd.Parameters.AddWithValue("@passwordhash", passwordHash);
            cmd.Parameters.AddWithValue("@salt", passwordSalt);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@contactNo", contactNo);
            cmd.Parameters.AddWithValue("@type", type);

            myConnection.Open();

            result += cmd.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();

            return result;
        }



    }
}