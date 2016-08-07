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
        private string briefDescription;
        private int doctorID;
        private int pressure;
        private int pulse;
        private decimal temperature;
        private string enIV;
        private string enkey;

        public string _enkey
        {
            get { return enkey; }
            set { enkey = value; }
        }
        public string _enIV
        {
            get { return enIV; }
            set { enIV = value; }
        }
        public int _pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
        public int _pulse
        {
            get { return pulse; }
            set { pulse = value; }
        }
        public decimal _temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        public int _doctorID
        {
            get { return doctorID;}
            set { doctorID = value; }
        }
        public string _briefDescription
        {
            get { return briefDescription; }
            set { briefDescription = value;}
        }
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

        public PatientsLogDAL(string _nric, string _datetime, string _symptomsList, int _medicineListID, int _receiptID, int _certID, string _doctorsNotes, string _briefDescription, int _doctorID, int _pressure, int _pulse, decimal _temperature, string _enkey,string _enIV)
        {
            nric = _nric;
            datetime = _datetime;
            symptomsList = _symptomsList;
            medicineListID = _medicineListID;
            receiptID = _receiptID;
            certID = _certID;
            doctorsNotes = _doctorsNotes;
            briefDescription = _briefDescription;
            doctorID = _doctorID;
            pressure = _pressure;
            pulse = _pulse;
            temperature = _temperature;
            enkey = _enkey;
            enIV = _enIV;
        }

        public int createPatientsLog(string nric, string datetime, string symptomsList, int receiptID, int certID, string doctorsNotes, string briefDescription, int doctorID, int pressure, int pulse, decimal temperature, string enkey, string enIV)
        {
            int result = 0;
            SqlConnection myConnection = new SqlConnection(strConnectionString);
            string strCommandText = "INSERT INTO PatientsLog(nric, datetime, SymptomsList, ReceiptID, CertID, DoctorsNotes, briefDescription, doctorID, pressure, pulse, temperature, enkey, enIV)"
                    + "values (@nric, @datetime, @symptomsList, @receiptID, @certID, @doctorsNotes, @briefDescription, @doctorID, @pressure, @pulse, @temperature, @enkey, @enIV)";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            try
            {
                
                cmd.Parameters.AddWithValue("@nric", nric);
                cmd.Parameters.AddWithValue("@datetime", datetime);
                cmd.Parameters.AddWithValue("@symptomsList", symptomsList);
                cmd.Parameters.AddWithValue("@receiptID", receiptID);
                cmd.Parameters.AddWithValue("@certID", certID);
                cmd.Parameters.AddWithValue("@doctorsNotes", doctorsNotes);
                cmd.Parameters.AddWithValue("@briefDescription", briefDescription);
                cmd.Parameters.AddWithValue("@doctorID", doctorID);
                cmd.Parameters.AddWithValue("@pressure", pressure);
                cmd.Parameters.AddWithValue("@pulse", pulse);
                cmd.Parameters.AddWithValue("@temperature", temperature);
                cmd.Parameters.AddWithValue("@enkey", enkey);
                cmd.Parameters.AddWithValue("@enIV", enIV);

                myConnection.Open();

                result += cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
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
            string briefDescription;
            string doctorID;
            string pulse;
            string pressure;
            string temperature;
            string enkey;
            string enIV;

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
                    briefDescription = reader["briefDescription"].ToString();
                    doctorID = reader["doctorID"].ToString();
                    pulse = reader["pulse"].ToString();
                    pressure = reader["pressure"].ToString();
                    temperature = reader["temperature"].ToString();
                    enkey = reader["enkey"].ToString();
                    enIV = reader["enIV"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { myConnection.Close(); }
            return p;
        }

        

        public DataTable getDTGrid(string nric)
        {
            DataTable dt = new DataTable();
            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PatientsLog where nric = @nric", myConnection);
            da.SelectCommand.Parameters.AddWithValue("@nric", nric);
            myConnection.Open();

            da.Fill(dt);
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
            string _briefDescription = "";
            int _doctorID;
            int _pressure;
            int _pulse;
            decimal _temperature;
            string _enkey = "";
            string _enIV = "";


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
                    _briefDescription = reader["briefDescription"].ToString();
                    _doctorID = Int32.Parse(reader["doctorID"].ToString());
                    _pulse = Int32.Parse(reader["pulse"].ToString());
                    _pressure = Int32.Parse(reader["pressure"].ToString());
                    _temperature = Decimal.Parse(reader["temperature"].ToString());
                    _enkey = reader["enkey"].ToString();
                    _enIV = reader["enIV"].ToString();



                    patientsLog = new PatientsLogDAL(_nric, _datetime, _symptomsList, _medicineListID, _receiptID, _certID, _doctorsNotes, _briefDescription, _doctorID, _pressure, _pulse, _temperature, _enkey, _enIV);
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


        public int updatePatientsLog(int caseNo, string nric, string datetime, string symptomsList, int receiptID, int certID, string doctorsNotes, string briefDescription, int doctorID, int pressure, int pulse, decimal temperature, string enkey, string enIV)
        {
            int result = 0;
            string queryStr = "UPDATE PatientsLog SET nric= @nric, datetime=@datetime , SymptomsList=@SymptomsList, ReceiptID=@ReceiptID, CertID=@CertID, DoctorsNotes=@DoctorsNotes, briefDescription=@briefDescription, doctorID=@doctorID, pressure=@pressure, pulse=@pulse, temperature=@temperature, enkey=@enkey, enIV =@enIV where caseNo = @caseNo";
            SqlConnection conn = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            try
            {
                cmd.Parameters.AddWithValue("@nric", nric);
                cmd.Parameters.AddWithValue("@datetime", datetime);
                cmd.Parameters.AddWithValue("@SymptomsList", symptomsList);
                cmd.Parameters.AddWithValue("@MedicineListID", medicineListID);
                cmd.Parameters.AddWithValue("@ReceiptID", receiptID);
                cmd.Parameters.AddWithValue("@CertID", certID);
                cmd.Parameters.AddWithValue("@DoctorsNotes", doctorsNotes);
                cmd.Parameters.AddWithValue("@briefDescription", briefDescription);
                cmd.Parameters.AddWithValue("@doctorID", doctorID);
                cmd.Parameters.AddWithValue("@pressure", pressure);
                cmd.Parameters.AddWithValue("@pulse", pulse);
                cmd.Parameters.AddWithValue("@temperature", temperature);
                cmd.Parameters.AddWithValue("@caseNo", caseNo);
                cmd.Parameters.AddWithValue("@enkey", enkey);
                cmd.Parameters.AddWithValue("@enIV", enIV);


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                result = cmd.ExecuteNonQuery();

                conn.Close();
            }

            return result;

        }//end Update

        public int deletePatientsLog(int caseNo)
        {
            int result = 0;
            SqlConnection myConnection = new SqlConnection(strConnectionString);
            string strCommandText = "DELETE FROM PatientsLog WHERE caseNo=@caseNo";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            try
            {
                cmd.Parameters.AddWithValue("@caseNo", caseNo);
                myConnection.Open();
                result += cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
            return result;
        }

        
    }
}