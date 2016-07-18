using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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
    }
}