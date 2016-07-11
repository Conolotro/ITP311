using System;
using System.Collections.Generic;
using System.Web;

namespace ITP311.App_Code.DAL
{
    public class PatientsLog
    {

        public int caseNo
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

        public string nric
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
        public string date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public int symptomsListID
        {
            get
            {
                return symptomsListID;
            }

            set
            {
                symptomsListID = value;
            }
        }

        public int medicineListID
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
         public int receiptID
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
         public int certID
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
         public int patientsCondition
         {
             get
             {
                 return patientsCondition;
             }

             set
             {
                 patientsCondition = value;
             }
         }



    }
}