using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace ITP311
{
    public partial class CreatePatientsLog : System.Web.UI.Page
    {
        List<string> selectedSymptomsList = new List<string>();

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            selectedSymptomsList = (List<string>)ViewState["selectedSymptomsList"];
            if (selectedSymptomsList != null)
            {
                try
                {
                    if (gvSelectedSymptoms.Rows.Count > 0)
                        gvSelectedSymptoms.Height = new Unit(gvSelectedSymptoms.RowStyle.Height.Value * gvSelectedSymptoms.Rows.Count);
                    gvSelectedSymptoms.DataSource = selectedSymptomsList;
                    gvSelectedSymptoms.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
          
                string[] symlist = { "Abdominal pain", "Blood in stool", "Chest pain", "Constipation", "Cough", "Difficulty swallowing", "Dizziness", "Eye discomfort and redness", "Foot pain or ankle pain", "Foot swelling or leg swelling", "Headaches", "Heart palpitations", "Hip pain",
                                       "Knee pain", "Low back pain", "Nasal congestion", "Nausea or vomiting", "Neck pain", "Numbness or tingling in hands", "Pelvic pain: Female", "Pelvic pain: Male", "Shortness of breath", "Shoulder pain", "Sore throat","Urinary problems","Vision problems","Wheezing" };
                List<string> MyList = symlist.ToList<string>();
                gvSymptoms.DataSource = MyList;
                gvSymptoms.DataBind();
                
        }
        protected void gvSymptoms_SelectedIndexChanged(object sender, EventArgs e)
        {
            string symptom = gvSymptoms.SelectedRow.Cells[1].Text;
            selectedSymptomsList.Add(symptom);
            gvSelectedSymptoms.DataSource = selectedSymptomsList;
            gvSelectedSymptoms.DataBind();
            ViewState["selectedSymptomsList"] = selectedSymptomsList;

        }
        

        protected void createNewLog_Click(object sender, EventArgs e)
        {
            string nric = "s9745441h";
            string datetime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
            int medicineListID = 1;
            int receiptID = 1;
            int certID = 1;
            string symptomsList = "";
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

        protected void formDoctorsNotes_TextChanged(object sender, EventArgs e)
        {

        }

     
    }
}

