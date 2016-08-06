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
        public string Codekey { get; set; }
        public DateTime creationDate { get; set; }

        public PasswordResetDAL(string nric, string CodeKey, DateTime creationDate)
        {
            this.nric = nric;
            this.Codekey = CodeKey;
            this.creationDate = creationDate;
        }

        public PasswordResetDAL()
        {

        }

        string strConnectionString = ConfigurationManager.ConnectionStrings["medicalportal"].ToString();

        public int CreatePasswordReset(string nric, string CodeKey, DateTime creationDate)
        {
            int result = 0;
            string strCommandText = "INSERT INTO PasswordReset(Nric,CreationDate,CodeKey)"
                + "values (@nric, @creationDate,@Codekey)";

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@nric", nric);
            cmd.Parameters.AddWithValue("@creationDate", creationDate);
            cmd.Parameters.AddWithValue("@Codekey", CodeKey);


            myConnection.Open();

            result += cmd.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();

            return result;
        }

        public PasswordResetDAL retrievePasswordResetByNric(string nric)
        {
            PasswordResetDAL rr = null;
            string strCommandText = "Select * from PasswordReset where Nric = @nric";
            string Codekey;
            DateTime creationDate;


            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@nric", nric);

            try
            {
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    nric = reader["Nric"].ToString();
                    creationDate = (DateTime)reader["CreationDate"];
                    Codekey = reader["Codekey"].ToString();

                    rr = new PasswordResetDAL(nric, Codekey, creationDate);
                }

            }
            catch (Exception ex)
            {
                rr = null;
            }
            finally { myConnection.Close(); }
            return rr;
        }


        public PasswordResetDAL retrievePasswordReset(string enteredKey)
        {
            PasswordResetDAL rr = null;
            string strCommandText = "Select * from PasswordReset where Codekey = @key";
            string nric, Codekey;
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
                    Codekey = reader["Codekey"].ToString();

                    rr = new PasswordResetDAL(nric, Codekey, creationDate);
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
            string strCommandText = "DELETE from PasswordReset where Codekey = @Codekey";

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@Codekey", key);

            myConnection.Open();

            result += cmd.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();

            return result;
        }


        public int RemovePasswordResetByNRIC(string nric)
        {
            int result = 0;
            string strCommandText = "DELETE from PasswordReset where Nric = @nric";

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