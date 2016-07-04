using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using ITP311.DAL;

namespace ITP311.BLL
{
    public class appointmentBLL
    {
        appointmentDAL Adal = new appointmentDAL();

        public int appID { get; set; } //Variable Declaration
        public string appDate { get; set; }
        public string appTime { get; set; }
        public string appLocation { get; set; }

        SqlCommand cmd = new SqlCommand();

        public DataSet BLL_Appointment()
        {
            return Adal.DAL_Appointment(); //DataSet method created in appointmentDAL.cs
        }


        //Client
        public void insertNewAppointmentRecord()
        {
            cmd.Parameters.AddWithValue("@appID", appID); //Table Field Name, Variable
            cmd.Parameters.AddWithValue("@appDate", appDate); //Table Field Name, Variable
            cmd.Parameters.AddWithValue("@appTime", appTime); //Table Field Name, Variable
            cmd.Parameters.AddWithValue("@appLocation", appLocation); //Table Field Name, Variable
            Adal.insertNewAppointment(cmd);
        }

        public appointmentBLL()
        {
            //Add constructor logic here
        }

    }
}