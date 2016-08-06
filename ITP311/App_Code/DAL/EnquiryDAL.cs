using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ITP311
{
    public class EnquiryDAL
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string message { get; set; }
        public DateTime dateTime { get; set; }
        public string SK { get; set; }
        public string IV { get; set; }

        string strConnectionString = ConfigurationManager.ConnectionStrings["medicalportal"].ToString();

        public EnquiryDAL()
        {

        }

        public EnquiryDAL(int id, string name, string email, string message, DateTime dateTime, string SK, string IV)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.message = message;
            this.dateTime = dateTime;
            this.SK = SK;
            this.IV = IV;
        }

        string cn = ConfigurationManager.ConnectionStrings["medicalportal"].ToString();

        public int CreateEnquiry(string name, string email, string message, DateTime dateTime, string secretKey, string IV)
        {
            int result = 0;
            string strCommandText = "INSERT INTO Enquiry(name, email, message, dateTime,SK,IV)"
                + "values (@name,@email, @message, @dateTime, @SK, @IV)";

            SqlConnection myConnection = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@message", message);
            cmd.Parameters.AddWithValue("@dateTime", dateTime);
            cmd.Parameters.AddWithValue("@SK", secretKey);
            cmd.Parameters.AddWithValue("@IV", IV);
            myConnection.Open();
            result += cmd.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();

            return result;
        }

        public EnquiryDAL retrieveEnquiryById(int id)
        {
            EnquiryDAL e = null;
            string strCommandText = "Select * from Enquiry where Id = @id";
            String name, email, message, IV, SK;
            DateTime dateTime;

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@id", id);


            try
            {
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = (int)reader["Id"];
                    name = reader["name"].ToString();
                    email = reader["email"].ToString();
                    message = reader["message"].ToString();
                    dateTime = (DateTime)reader["dateTime"];
                    SK = reader["SK"].ToString();
                    IV = reader["IV"].ToString();


                    e = new EnquiryDAL(id, name, email, message, dateTime, SK, IV);

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { myConnection.Close(); }
            return e;
        }


        public List<EnquiryDAL> retrieveAllEnquiry(int id)
        {
            EnquiryDAL e = null;
            string strCommandText = "Select * from Enquiry where Id = @id";
            String name, email, message;
            DateTime dateTime;
            List<EnquiryDAL> enquiryList = new List<EnquiryDAL>();

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@id", id);


            try
            {
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = (int)reader["Id"];
                    name = reader["name"].ToString();
                    email = reader["email"].ToString();
                    message = reader["message"].ToString();
                    dateTime = (DateTime)reader["dateTime"];
                    SK = reader["SK"].ToString();
                    IV = reader["IV"].ToString();

                    e = new EnquiryDAL(id, name, email, message, dateTime, SK, IV);
                    enquiryList.Add(e);

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { myConnection.Close(); }
            return enquiryList;
        }
    }

}