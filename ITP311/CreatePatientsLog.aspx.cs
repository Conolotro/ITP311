using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP311
{
    public partial class CreatePatientsLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void createNewLog_Click(object sender, EventArgs e)
        {
                    string nric = "s9745441h";
                    string datetime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
                    int medicineListID = 1;
                    int receiptID= 1;
                    int certID= 1;
                    string symptomsList = formSymptomsList.Text.Trim();
                    string doctorsNotes = formDoctorsNotes.Text.Trim();

            
                PatientsLogBLL patientlog = new PatientsLogBLL();
                if (patientlog.createPatientsLog(nric, datetime, symptomsList, medicineListID, receiptID, certID, doctorsNotes) == true)
                {
                    

                    Response.Redirect("doctor-PatientsLog.aspx");
                }
                else
                {
                    Response.Redirect("error.aspx");
                }
            }
           
        }
    }

