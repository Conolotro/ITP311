using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ITP311
{
    public class MedicineListDAL
    {
        public int id { get; set; }
        public int MedicineListId { get; set; }
        public string medicine { get; set; }

        string cn = ConfigurationManager.ConnectionStrings["medicalportal"].ToString();

        public MedicineListDAL()
        {

        }

        public MedicineListDAL(int id, int MedicineListId, string medicine)
        {
            this.id = id;
            this.MedicineListId = MedicineListId;
            this.medicine = medicine;
        }

        public List<MedicineListDAL> retrieveMedicalList(int MedicineListId)
        {
            MedicineListDAL m = null;
            string strCommandText = "Select DISTINCT(medicine) from MedicineList where MedicalListID = @id";
            string medicine;
            int id;
            List<MedicineListDAL> MedicalList = new List<MedicineListDAL>();
            SqlConnection myConnection = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@id", MedicineListId);


            try
            {
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = (int)reader["id"];
                    string mdl = reader["MedicalListID"].ToString();
                    MedicineListId = Int32.Parse(mdl);
                    medicine = reader["medicine"].ToString();

                    m = new MedicineListDAL(id, MedicineListId, medicine);
                    MedicalList.Add(m);

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { myConnection.Close(); }
            return MedicalList;
        }

        public int createMedicineList(int MedicineListId, string medicine)
        {
            int result = 0;
            string strCommandText = "INSERT INTO MedicineList(medicalListID, medicine)"
                + "values (@medicalListID, @medicine)";

            SqlConnection myConnection = new SqlConnection(cn);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnection);
            cmd.Parameters.AddWithValue("@medicalListID", MedicineListId);
            cmd.Parameters.AddWithValue("@medicine", medicine);

            myConnection.Open();

            result += cmd.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();

            return result;
        }
    
    }
}