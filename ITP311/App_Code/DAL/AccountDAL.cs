using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ITP311.BLL;

namespace ITP311.DAL
{
    public class AccountDAL
    {

        string cn = ConfigurationManager.ConnectionStrings["medicalportalconnectionstring"].ToString();

        public int CreateAccount(string NRIC, string fname, string lname, string PasswordHash, string PasswordSalt, string Email, string ContactNo, string Type)
        {
            
            SqlConnection conn = new SqlConnection(cn);
            string sqlSelectString = "INSERT INTO Account(NRIC, fname, lname, PasswordHash, PasswordSalt, Email, ContactNo, Type) VALUES (@NRIC, @fname, @lname, @PasswordHash, @PasswordSalt, @Email, @ContactNo, @Type)";
            SqlCommand cmd = new SqlCommand(sqlSelectString, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmd.Parameters.AddWithValue("@NRIC", NRIC);
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@lname", lname);
                    cmd.Parameters.AddWithValue("@PasswordHash", PasswordHash);
                    cmd.Parameters.AddWithValue("@PasswordSalt", PasswordSalt);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
                    cmd.Parameters.AddWithValue("@Type", Type);
                }
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return cmd.ExecuteNonQuery();
        }

      

        


       

    }

    }
