using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ITP311
{
    public class PasswordResetDAL
    {
        public int id { get; set; }
        public string nric { get; set; }
        public string key { get; set; }
        public DateTime creationDate { get; set; }

        public PasswordResetDAL(string nric, string key, DateTime creationDate)
        {
            this.nric = nric;
            this.key = key;
            this.creationDate = creationDate;
        }

        public PasswordResetDAL()
        {

        }

        string strConnectionString = ConfigurationManager.ConnectionStrings["medicalportal"].ToString();

        public int CreatePasswordReset(string nric, string key, DateTime creationDate)
        {
            int result = 0;
            string strCommandText = "INSERT INTO PasswordReset(Nric,CreationDate,Key)"
                + "values (@nric, @createionDate, @key)";

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@nric", nric);
            cmd.Parameters.AddWithValue("@creationDate", creationDate);
            cmd.Parameters.AddWithValue("@key", key);


            myConnection.Open();

            result += cmd.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();

            return result;
        }

        public PasswordResetDAL retrievePasswordReset(string enteredKey)
        {
            PasswordResetDAL rr = null;
            string strCommandText = "Select * from PasswordReset where Key = @key";
            string Nric, Key;
            DateTime creationDate;


            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@key", enteredKey);

            try
            {
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    nric = reader["Nric"].ToString();
                    creationDate = (DateTime)reader["CreationDate"];
                    key = reader["Key"].ToString();

                    rr = new PasswordResetDAL(nric, key, creationDate);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { myConnection.Close(); }
            return rr;
        }

        public int RemovePasswordReset(string key)
        {
            int result = 0;
            string strCommandText = "DELETE from PasswordReset where Key = @key"
                + "values (@key)";

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@key", key);

            myConnection.Open();

            result += cmd.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();

            return result;
        }

        public int RemovePasswordResetByNRIC(string nric)
        {
            int result = 0;
            string strCommandText = "DELETE from PasswordReset where Nric = @nric"
                + "values (@key)";

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@nric", nric);

            myConnection.Open();

            result += cmd.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();

            return result;
        }

    }
}