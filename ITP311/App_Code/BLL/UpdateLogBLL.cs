using System;
using System.Collections.Generic;
using System.Data;
using System.Web;


namespace ITP311
{
    public class UpdateLogBLL
    {
        public UpdateLogBLL()
        {

        }

        public List<UpdateLogDAL> retrieveUpdateLog()
        {
            List<UpdateLogDAL> ulList = new List<UpdateLogDAL>();
            UpdateLogDAL uldal = new UpdateLogDAL();
            ulList = uldal.retrieveUpdateLog();
            return ulList;
        }

        public bool createUpdatesLog(string cnric, string cdatetime, int medicineListID, int creceiptID, string csymptomsList, int ccertID, decimal ctemperature,
            string updatedBy, string modifiedAt, string modifiedMethod, string cbriefDescription, string cdoctorsNotes, string cdoctorID, int cpulse, int cpressure)
        {
            bool result = false;
            UpdateLogDAL ulog = new UpdateLogDAL();

            if (ulog.createUpdatesLog(cnric, cdatetime, medicineListID, creceiptID, csymptomsList, ccertID, ctemperature,
            updatedBy, modifiedAt, modifiedMethod, cbriefDescription, cdoctorsNotes, cdoctorID, cpulse, cpressure) == 1)
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