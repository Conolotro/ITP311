using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Data;


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

        public PatientsLogDAL(string nric, string datetime, string symptomsList, int medicineListID, int receiptID, int certID, string doctorsNotes)
        {
            this.nric = nric;
            this.datetime = datetime;
            this.symptomsList = symptomsList;
            this.medicineListID = medicineListID;
            this.receiptID = receiptID;
            this.certID = certID;
            this.doctorsNotes = doctorsNotes;
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

    }
}