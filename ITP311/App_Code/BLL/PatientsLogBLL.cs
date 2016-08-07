using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace ITP311
{
    public class PatientsLogBLL
    {
        public PatientsLogBLL()
        {

        }

        public bool createPatientsLog(string nric, string datetime, string symptomsList, int receiptID, int certID, string doctorsNotes, string briefDescription, int doctorID, int pressure, int pulse, decimal temperature, string enkey, string enIV)
        {
            bool result = false;
            PatientsLogDAL plog = new PatientsLogDAL();
            if (plog.createPatientsLog(nric, datetime, symptomsList, receiptID, certID, doctorsNotes, briefDescription, doctorID, pressure, pulse, temperature, enkey, enIV) == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        public bool updatePatientsLog(int caseNo, string nric, string datetime, string symptomsList, int medicineListID, int receiptID, int certID, string doctorsNotes, string briefDescription, int doctorID, int pressure, int pulse, decimal temperature, string enkey, string enIV)
        {
            bool result = false;
            PatientsLogDAL plog = new PatientsLogDAL();
            if (plog.updatePatientsLog(caseNo, nric, datetime, symptomsList, receiptID, certID, doctorsNotes, briefDescription, doctorID, pressure, pulse, temperature, enkey, enIV) == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        public bool deletePatientsLog(int caseNo)
        {
            bool result = false;
            PatientsLogDAL plog = new PatientsLogDAL();
            if (plog.deletePatientsLog(caseNo) == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        public DataTable getDTGrid(string nric)
        {
            PatientsLogDAL plogdal = new PatientsLogDAL();
            DataTable dt = new DataTable();
            dt = plogdal.getDTGrid(nric);
            return dt;
        }

        public PatientsLogDAL getPatientsLogByCaseNo(int caseNo)
        {
            PatientsLogDAL plogdal = new PatientsLogDAL();
            return plogdal.getPatientsLogByCaseNo(caseNo); ;
        }
    }
}