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

        public bool createPatientsLog(string nric, string datetime, string symptomsList, int medicineListID, int receiptID, int certID, string doctorsNotes)
        {
            bool result = false;
            PatientsLogDAL plog = new PatientsLogDAL();
            if (plog.createPatientsLog(nric, datetime, symptomsList, medicineListID, receiptID, certID, doctorsNotes) == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public DataTable getDTGrid()
        {
            PatientsLogDAL plogdal = new PatientsLogDAL();
            DataTable dt = new DataTable();
            dt = plogdal.getDTGrid();
            return dt;
        }
        public PatientsLogDAL getPatientsLogByCaseNo(int caseNo)
        {
            PatientsLogDAL plogdal = new PatientsLogDAL();
            return plogdal.getPatientsLogByCaseNo(caseNo);;
        }
    }
}