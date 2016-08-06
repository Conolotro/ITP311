using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace ITP311
{
    public partial class CreatePatientsLog : System.Web.UI.Page
    {
        byte[] Key, IV;
        List<string> selectedSymptomsList = new List<string>();
        string[] symlist = { "Abdominal pain", "Blood in stool", "Chest pain", "Constipation", "Cough", "Difficulty swallowing", "Dizziness", "Eye discomfort and redness", "Foot pain or ankle pain", "Foot swelling or leg swelling", "Headaches", "Heart palpitations", "Hip pain",
                                       "Knee pain", "Low back pain", "Nasal congestion", "Nausea or vomiting", "Neck pain", "Numbness or tingling in hands", "Pelvic pain: Female", "Pelvic pain: Male", "Shortness of breath", "Shoulder pain", "Sore throat","Urinary problems","Vision problems","Wheezing" };
        List<string> MyList = new List<string>();
        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            selectedSymptomsList = (List<string>)ViewState["selectedSymptomsList"];
            MyList = (List<string>)ViewState["MyList"];
            if (selectedSymptomsList != null)
            {
                try
                {
                    gvSymptoms.DataSource = MyList;
                    gvSymptoms.DataBind();
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
            if ((List<string>)ViewState["MyList"] == null)
            {
                MyList = symlist.ToList<string>();
                gvSymptoms.DataSource = MyList;
                gvSymptoms.DataBind();
            }
            else
            {
                MyList = (List<string>)ViewState["MyList"];
                gvSymptoms.DataSource = MyList;
                gvSymptoms.DataBind();
            }
        }
        protected void gvSymptoms_SelectedIndexChanged(object sender, EventArgs e)
        {
            string symptom = gvSymptoms.SelectedRow.Cells[1].Text;
            selectedSymptomsList.Add(symptom);
            MyList.Remove(symptom);
            ViewState["MyList"] = MyList;
            gvSymptoms.DataSource = MyList;
            gvSymptoms.DataBind();
            gvSelectedSymptoms.DataSource = selectedSymptomsList;
            gvSelectedSymptoms.DataBind();
            ViewState["selectedSymptomsList"] = selectedSymptomsList;

        }

        protected void gvSelectedSymptoms_SelectedIndexChanged(object sender, EventArgs e)
        {
            string symptom = gvSelectedSymptoms.SelectedRow.Cells[1].Text;
            MyList.Add(symptom);
            selectedSymptomsList.Remove(symptom);
            ViewState["MyList"] = MyList;
            gvSymptoms.DataSource = MyList;
            gvSymptoms.DataBind();
            gvSelectedSymptoms.DataSource = selectedSymptomsList;
            gvSelectedSymptoms.DataBind();
            ViewState["selectedSymptomsList"] = selectedSymptomsList;
        }

        protected void createNewLog_Click(object sender, EventArgs e)
        {
            string nric = Session["search"].ToString();
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int medicineListID = 1;
            int receiptID = 1;
            int certID = 1;
            string doctorsNotes = formDoctorsNotes.Text.Trim();
            selectedSymptomsList = (List<string>)ViewState["selectedSymptomsList"];
            string symptomsList = "";
            string description = briefDescription.Text;
            int doctorid = 1;
            int pressure = Int32.Parse(pressuretbx.Text);
            int pulse = Int32.Parse(pulsetbx.Text);
            decimal temperature = Decimal.Parse(temperaturetbx.Text);

            for (int i = 0; i < selectedSymptomsList.Count; i++)
            {
                symptomsList = symptomsList + selectedSymptomsList[i] + ";";
            }
            string encryptedSymList = "";

            //encrypting symptoms

            SymmetricAlgorithm sa = new RijndaelManaged();
            sa.GenerateKey();
            Key = sa.Key;
            IV = sa.IV;

            string enkey = Convert.ToBase64String(Key);
            string enIV = Convert.ToBase64String(IV);

            ICryptoTransform cryptTransform = sa.CreateEncryptor();
            byte[] plaintext = Encoding.UTF8.GetBytes(symptomsList);
            byte[] ciphertext = cryptTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);
            encryptedSymList = Convert.ToBase64String(ciphertext);
            
            
            PatientsLogBLL patientlog = new PatientsLogBLL();
            if (patientlog.createPatientsLog(nric, datetime, encryptedSymList, medicineListID, receiptID, certID, doctorsNotes, description, doctorid, pressure, pulse, temperature, enkey, enIV) == true)
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

