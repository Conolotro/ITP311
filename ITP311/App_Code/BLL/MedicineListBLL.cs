using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITP311
{
    public class MedicineListBLL
    {
        public MedicineListBLL()
        {

        }

        public List<MedicineListDAL> retrieveMedicineList(int medicineListId)
        {
            MedicineListDAL m = new MedicineListDAL();
            return m.retrieveMedicalList(medicineListId);
        }

        public bool createMedicineList(int medicineListId, string medicine){
            bool result = false;
            MedicineListDAL mlDAL = new MedicineListDAL();
            if (mlDAL.createMedicineList(medicineListId, medicine) == 1)
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