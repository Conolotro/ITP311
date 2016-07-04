using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ITP311.DAL
{
    /*
     * DAL contains methods that helps business layer to connect the data and perform required action, 
       might be returning data or manipulating data (insert, update, delete etc). 
         
     * All code that is specific to the underlying data source – 
       such as creating a connection to the database, issuing SELECT, INSERT, UPDATE, and DELETE commands, and so on – 
       should be located in the DAL. The presentation layer should not contain any references to such data access code, 
       but should instead make calls into the DAL for any and all data requests. 
       Data Access Layers typically contain methods for accessing the underlying database data.
     */

    public class appointmentDAL
    {
        SqlConnection medicalportalconnectionstring = new SqlConnection(ConfigurationManager.ConnectionStrings["MedicalPortal"].ConnectionString);

        public DataSet DAL_Appointment()
        {
            //Create Adaptder 
            SqlDataAdapter myAppointmentAdapter = new SqlDataAdapter("Select * from Appointment", medicalportalconnectionstring);

            //Create Dataset to store results of query
            DataSet ds = new DataSet();

            //Fill the dataset with the results
            myAppointmentAdapter.Fill(ds);

            //Bind the data read to the gridview control 
            return ds;
        }
        
        
        /******************
        Stored Procedures
        ******************/

    public void insertNewAppointment(SqlCommand cmd) 
    {
        medicalportalconnectionstring.Open();
        cmd.Connection = medicalportalconnectionstring;
        cmd.CommandText = "InsertApp";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery(); 
    }  
    
        public appointmentDAL()
        {

        }


}

}