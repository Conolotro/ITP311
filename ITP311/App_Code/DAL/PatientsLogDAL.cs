using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Data;
using System.Web.Services;


namespace ITP311
{
    public class PatientsLogDAL
    {
        private int caseNo;
        private string nric;
        private string datetime;
        private string symptomsList;
        private int medicineListID;
        private int receiptID;
        private int certID;
        private string doctorsNotes;

        public int _caseNo
        {
            get
            {
                return caseNo;
            }

            set
            {
                caseNo = value;
            }
        }
        public string _nric
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
        public string _datetime
        {
            get
            {
                return datetime;
            }

            set
            {
                datetime = value;
            }
        }
        public string _symptomsList
        {
            get
            {
                return symptomsList;
            }

            set
            {
                symptomsList = value;
            }
        }
        public int _medicineListID
        {
            get
            {
                return medicineListID;
            }

            set
            {
                medicineListID = value;
            }
        }
        public int _receiptID
        {
            get
            {
                return receiptID;
            }

            set
            {
                receiptID = value;
            }
        }
        public int _certID
        {
            get
            {
                return certID;
            }

            set
            {
                certID = value;
            }
        }
        public string _doctorsNotes
        {
            get
            {
                return doctorsNotes;
            }

            set
            {
                doctorsNotes = value;
            }
        }

        public PatientsLogDAL() { }

        string strConnectionString = ConfigurationManager.ConnectionStrings["medicalportal"].ToString();


        public PatientsLogDAL(string _nric, string _datetime, string _symptomsList, int _medicineListID, int _receiptID, int _certID, string _doctorsNotes)
        {
            nric = _nric;
            datetime = _datetime;
            symptomsList = _symptomsList;
            medicineListID = _medicineListID;
            receiptID = _receiptID;
            certID = _certID;
            doctorsNotes = _doctorsNotes;
        }
        
        public int createPatientsLog(string nric, string datetime, string symptomsList, int medicineListID, int receiptID, int certID, string doctorsNotes)
        {
            int result = 0;
            string strCommandText = "INSERT INTO PatientsLog(nric, datetime, SymptomsList, MedicineListID, ReceiptID, CertID, DoctorsNotes)"
                + "values (@nric, @datetime, @symptomsList, @medicineListID, @receiptID, @certID, @doctorsNotes)";

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@nric", nric);
            cmd.Parameters.AddWithValue("@datetime", datetime);
            cmd.Parameters.AddWithValue("@symptomsList", symptomsList);
            cmd.Parameters.AddWithValue("@medicineListID", medicineListID);
            cmd.Parameters.AddWithValue("@receiptID", receiptID);
            cmd.Parameters.AddWithValue("@certID", certID);
            cmd.Parameters.AddWithValue("@doctorsNotes", doctorsNotes);

            myConnection.Open();

            result += cmd.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();

            return result;
        }


        public PatientsLogDAL retrievePatientsLog(string nric)
        {
            PatientsLogDAL p = null;
            string strCommandText = "Select * from PatientsLog where NRIC = @nric";

            string caseNo;
            string datetime;
            string symptomsList;
            string medicineListID;
            string receiptID;
            string certID;
            string doctorsNotes;

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@nric", nric);


            try
            {
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    caseNo = reader["caseNo"].ToString();
                    datetime = reader["datetime"].ToString();
                    symptomsList = reader["symptomsList"].ToString();
                    medicineListID = reader["medicineListID"].ToString();
                    receiptID = reader["receiptID"].ToString();
                    certID = reader["certID"].ToString();
                    doctorsNotes = reader["doctorsNotes"].ToString();



                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { myConnection.Close(); }
            return p;
        }
        public DataTable getDTGrid()
        {
            DataTable dt = new DataTable();
            SqlConnection myConnection = new SqlConnection(strConnectionString);

            string strCommandText = "SELECT * FROM PatientsLog";
            SqlDataAdapter myAdapter = new SqlDataAdapter(strCommandText, myConnection);
            myConnection.Open();

            myAdapter.Fill(dt);
            myConnection.Dispose();

            return dt;
        }

        public PatientsLogDAL getPatientsLogByCaseNo(int caseNo)
        {
            PatientsLogDAL patientsLog = null;
            string _nric = "";
            string _datetime = "";
            string _symptomsList = "";
            int _medicineListID;
            int _receiptID;
            int _certID;
            string _doctorsNotes = "";

            string queryStr = "SELECT * FROM PatientsLog where caseNo = @caseNo ";

            SqlConnection conn = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@caseNo", caseNo);


            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    _nric = reader["nric"].ToString();
                    _datetime = reader["datetime"].ToString();
                    _symptomsList = reader["symptomsList"].ToString();
                    _medicineListID = Int32.Parse(reader["medicineListID"].ToString());
                    _receiptID = Int32.Parse(reader["receiptID"].ToString());
                    _certID = Int32.Parse(reader["certID"].ToString());
                    _doctorsNotes = reader["doctorsNotes"].ToString();



                    patientsLog = new PatientsLogDAL(_nric, _datetime, _symptomsList, _medicineListID, _receiptID, _certID, _doctorsNotes);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                reader.Close();
                reader.Dispose();
            }

            return patientsLog;
        }
        
    }
}