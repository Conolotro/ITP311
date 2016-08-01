using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace ITP311
{
    public class PatientDAL
    {

        private string nric;
        private string passwordHash;
        private string salt;
        private string firstName;
        private string lastName;
        private int contactNo;
        private string address;
        private string dob;
        private string email;
        private string allergyId;
        private bool confirmedEmail;

        public string Nric
        {
            get
            {
                return nric;
            }

            set
            {
                nric = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return passwordHash;
            }

            set
            {
                passwordHash = value;
            }
        }

        public string Salt
        {
            get
            {
                return salt;
            }

            set
            {
                salt = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public int ContactNo
        {
            get
            {
                return contactNo;
            }

            set
            {
                contactNo = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Dob
        {
            get
            {
                return dob;
            }

            set
            {
                dob = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string AllergyId
        {
            get
            {
                return allergyId;
            }

            set
            {
                allergyId = value;
            }
        }

        public bool ConfirmedEmail
        {
            get
            {
                return confirmedEmail;
            }

            set
            {
                confirmedEmail = value;
            }
        }

        string strConnectionString = ConfigurationManager.ConnectionStrings["medicalportal"].ToString();

        public PatientDAL() { }

        public PatientDAL(string nric, string passwordHash, string salt, string firstName, string lastName, int contactNo, string email)
        {
            this.nric = nric;
            this.passwordHash = passwordHash;
            this.salt = salt;
            this.firstName = firstName;
            this.lastName = lastName;
            this.contactNo = contactNo;
            this.email = email;
        }

        public int createPatient(string nric, string passwordHash, string salt, string firstName, string lastName, int contactNo, string email)
        {
            int result = 0;
            string strCommandText = "INSERT INTO Patient(NRIC, PasswordHash, Salt, FirstName, LastName, ContactNo, Email)"
                + "values (@nric, @passwordhash, @salt, @firstname, @lastname, @contactNo, @email)";

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@nric", nric);
            cmd.Parameters.AddWithValue("@passwordhash", passwordHash);
            cmd.Parameters.AddWithValue("@salt", salt);
            cmd.Parameters.AddWithValue("@firstname", firstName);
            cmd.Parameters.AddWithValue("@lastname", lastName);
            cmd.Parameters.AddWithValue("@contactNo", contactNo);
            cmd.Parameters.AddWithValue("@email", email);

            myConnection.Open();

            result += cmd.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();

            return result;
        }

        public int updatePatientEmailConfirmation(string nric)
        {
            int result = 0;
            string strCommandText = "UPDATE Patient SET EmailConfirmed = @emailConfirmed where NRIC = @nric";

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@emailConfirmed", true);
            cmd.Parameters.AddWithValue("@nric", nric);
            myConnection.Open();
            result += cmd.ExecuteNonQuery();

            myConnection.Close();

            return result;

        }

        public int updatePatient(string nric, int contactNo, string email, string address)
        {
            int result = 0;
            string strCommandText = "UPDATE Patient SET ContactNo = @contactNo, email = @email, Address = @address where NRIC = @nric";

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@contactNo", contactNo);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@nric", nric);

            myConnection.Open();

            result += cmd.ExecuteNonQuery();

            myConnection.Close();

            return result;

        }


        public int updatePatientPassword(string nric ,string hashedPassword, string salt)
        {
            int result = 0;
            string strCommandText = "UPDATE Patient SET PasswordHash = @passwordhash, PasswordSalt = @salt where NRIC = @nric";

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
            cmd.Parameters.AddWithValue("@PasswordSalt", salt);
            cmd.Parameters.AddWithValue("@nric", nric);

            myConnection.Open();

            result += cmd.ExecuteNonQuery();

            myConnection.Close();

            return result;

        }

        public PatientDAL retrievePatient(string nric)
        {
            PatientDAL p = null;
            string strCommandText = "Select * from Patient where NRIC = @nric";
            string Nric, passwordHash, salt, firstname, lastname, address, dob, email, allergyID;
            int contactNo;
            bool emailconfirmed;

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@nric", nric);


            try
            {
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Nric = reader["NRIC"].ToString();
                    passwordHash = reader["PasswordHash"].ToString();
                    salt = reader["Salt"].ToString();
                    firstname = reader["FirstName"].ToString();
                    lastname = reader["LastName"].ToString();
                    contactNo = (int)reader["ContactNo"];
                    address = reader["Address"].ToString();
                    dob = reader["DOB"].ToString();
                    email = reader["Email"].ToString();
                    allergyID = reader["AllergyID"].ToString();
                    emailconfirmed = (bool)reader["EmailConfirmed"];

                    p = new PatientDAL(Nric, passwordHash, salt, firstname, lastname, contactNo, email);
                    p.address = address;
                    p.dob = dob;
                    p.AllergyId = allergyID;
                    p.ConfirmedEmail = emailconfirmed;


                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { myConnection.Close(); }
            return p;
        }

        public PatientDAL retrievePatientbyEmail(string email)
        {
            PatientDAL p = null;
            string strCommandText = "Select * from Patient where Email = @Email";
            string Nric, passwordHash, salt, firstname, lastname, address, dob, allergyID;
            int contactNo;
            bool emailconfirmed;

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@email", email);


            try
            {
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Nric = reader["NRIC"].ToString();
                    passwordHash = reader["PasswordHash"].ToString();
                    salt = reader["Salt"].ToString();
                    firstname = reader["FirstName"].ToString();
                    lastname = reader["LastName"].ToString();
                    contactNo = (int)reader["ContactNo"];
                    address = reader["Address"].ToString();
                    dob = reader["DOB"].ToString();
                    email = reader["Email"].ToString();
                    allergyID = reader["AllergyID"].ToString();
                    emailconfirmed = (bool)reader["EmailConfirmed"];

                    p = new PatientDAL(Nric, passwordHash, salt, firstname, lastname, contactNo, email);
                    p.address = address;
                    p.dob = dob;
                    p.AllergyId = allergyID;
                    p.ConfirmedEmail = emailconfirmed;


                }

            }
            catch (Exception ex)
            {
                //throw new Exception(ex.ToString());
                p = null;
            }
            finally { myConnection.Close(); }
            return p;
        }


    }

}