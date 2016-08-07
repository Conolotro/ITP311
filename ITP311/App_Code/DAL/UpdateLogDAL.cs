using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Data;
using System.Web.Services;

namespace ITP311
{
    public class UpdateLogDAL
    {
        private int updatelogId;
        private string cnric;
        private string modifedMethod;
        private string cdatetime;
        private int medicineListID;
        private int creceiptID;
        private string csymptomsList;
        private int ccertID;
        private decimal ctemperature;
        private string updatedBy;
        private string modifiedAt;
        private string modifiedMethod;
        private string cbriefDescription;
        private string cdoctorsNotes;
        private string cdoctorID;
        private int cpulse;
        private int cpressure;

        public int UpdatelogId
        {
            get { return updatelogId; }
            set { updatelogId = value; }
        }
        public string Cnric
        {
            get { return cnric; }
            set { cnric = value; }
        }
        public string Cdatetime
        {
            get { return cdatetime; }
            set { cdatetime = value; }
        }
        public string CsymptomsList
        {
            get { return csymptomsList; }
            set { csymptomsList = value; }
        }
        public int MedicineListID
        {
            get { return medicineListID; }
            set { medicineListID = value; }
        }
        public int CreceiptID
        {
            get { return creceiptID; }
            set { creceiptID = value; }
        }
        public int CcertID
        {
            get { return ccertID; }
            set { ccertID = value; }
        }
        public string CdoctorsNotes
        {
            get { return cdoctorsNotes; }
            set { cdoctorsNotes = value; }
        }
        public string CbriefDescription
        {
            get { return cbriefDescription; }
            set { cbriefDescription = value; }
        }
        public string CdoctorID
        {
            get { return cdoctorID; }
            set { cdoctorID = value; }
        }
        public int Cpulse
        {
            get { return cpulse; }
            set { cpulse = value; }
        }
        public int Cpressure
        {
            get { return cpressure; }
            set { cpressure = value; }
        }
        public decimal Ctemperature
        {
            get { return ctemperature; }
            set { ctemperature = value; }
        }
        public string ModifiedMethod
        {
            get { return modifiedMethod; }
            set { modifiedMethod = value; }
        }
        public string ModifiedAt
        {
            get { return modifiedAt; }
            set { modifiedAt = value; }
        }
        public string ModifedMethod
        {
            get { return modifedMethod; }
            set { modifedMethod = value; }
        }
        public string UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        public UpdateLogDAL(string cnric, string modifiedAt, string modifiedMethod, int updatedby)
        {
            cnric = Cnric;
            modifiedAt = ModifiedAt;
            modifiedMethod = ModifiedMethod;
            updatedBy = UpdatedBy;
        }

        public UpdateLogDAL(int updatelogId, string cnric, string cdatetime, int medicineListID, int creceiptID, string csymptomsList, int ccertID, decimal ctemperature, string updatedBy, string modifiedAt, string modifiedMethod, string cbriefDescription, string cdoctorsNotes, string cdoctorID, int cpulse, int cpressure)
        {
            updatelogId = UpdatelogId;
            cnric = Cnric;
            cdatetime = Cdatetime;
            medicineListID = MedicineListID;
            creceiptID = CreceiptID;
            csymptomsList = CsymptomsList;
            ccertID = CcertID;
            ctemperature = Ctemperature;
            updatedBy = UpdatedBy;
            modifiedAt = ModifiedAt;
            modifiedMethod = ModifiedMethod;
            cbriefDescription = CbriefDescription;
            cdoctorsNotes = CdoctorsNotes;
            cdoctorID = CdoctorID;
            cpulse = Cpulse;
            cpressure = Cpressure;
        }
        public UpdateLogDAL() { }

        string strConnectionString = ConfigurationManager.ConnectionStrings["medicalportal"].ToString();

        public int createUpdatesLog(string cnric, string cdatetime, int medicineListID, int creceiptID, string csymptomsList, int ccertID, decimal ctemperature,
            string updatedBy, string modifiedAt, string modifiedMethod, string cbriefDescription, string cdoctorsNotes, string cdoctorID, int cpulse, int cpressure)
        {
            int result = 0;
            SqlConnection myConnection = new SqlConnection(strConnectionString);
            string strCommandText = "INSERT INTO updateLog(cnric, cdatetime, cmedicineListID, creceiptID, csymptomsList, ccertID, ctemperature, updatedBy, modifiedAt, modifiedMethod, cbriefDescription, cdoctorsNotes, cdoctorID, cpulse, cpressure)"
                    + "values (@cnric, @cdatetime, @cmedicineListID, @creceiptID, @csymptomsList, @ccertID, @ctemperature, @updatedBy, @modifiedAt, @modifiedMethod, @cbriefDescription, @cdoctorsNotes, @cdoctorID, @cpulse, @cpressure)";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            try
            {
                cmd.Parameters.AddWithValue("@cnric", cnric);
                cmd.Parameters.AddWithValue("@cdatetime", cdatetime);
                cmd.Parameters.AddWithValue("@cmedicineListID", medicineListID);
                cmd.Parameters.AddWithValue("@creceiptID", creceiptID);
                cmd.Parameters.AddWithValue("@csymptomsList", csymptomsList);
                cmd.Parameters.AddWithValue("@ccertID", ccertID);
                cmd.Parameters.AddWithValue("@ctemperature", ctemperature);
                cmd.Parameters.AddWithValue("@updatedBy", updatedBy);
                cmd.Parameters.AddWithValue("@modifiedAt", modifiedAt);
                cmd.Parameters.AddWithValue("@modifiedMethod", modifiedMethod);
                cmd.Parameters.AddWithValue("@cbriefDescription", cbriefDescription);
                cmd.Parameters.AddWithValue("@cdoctorsNotes", cdoctorsNotes);
                cmd.Parameters.AddWithValue("@cdoctorID", cdoctorID);
                cmd.Parameters.AddWithValue("@cpulse", cpulse);
                cmd.Parameters.AddWithValue("@cpressure", cpressure);

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

        public List<UpdateLogDAL> retrieveUpdateLog()
        {
            List<UpdateLogDAL> udallist = new List<UpdateLogDAL>();
            
            string strCommandText = "Select cnric, modifiedAt, updatedBy, modifiedMethod from updateLog";
            SqlConnection myConnection = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);

            try
            {
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UpdateLogDAL a = new UpdateLogDAL();
                    a.cnric = reader["cnric"].ToString();
                    a.modifiedAt = reader["modifiedAt"].ToString();
                    a.modifiedMethod = reader["modifiedMethod"].ToString();
                    a.updatedBy = reader["updatedBy"].ToString();
                    udallist.Add(a);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { myConnection.Close(); }
            return udallist;
        }

    }
}