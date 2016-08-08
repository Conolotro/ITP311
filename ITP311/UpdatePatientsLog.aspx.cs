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
using ITP311;

namespace ITP311
{
    public partial class UpdatePatientsLog : System.Web.UI.Page
    {
        byte[] Key, IV;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userNric"] == null)
                {
                    Response.Redirect("adminlogin.aspx");
                }
                else
                {
                    string user = Session["userDesignation"].ToString();
                    if (user.Equals("d"))
                    {
                        string Nric = Session["userNric"].ToString();
                        AccountBLL a = new AccountBLL();
                        AccountDAL ad = a.retrieveAccountByNric(Nric);
                        name.Text = ad.firstName;

                        if (Session["caseNo"] != null)
                        {
                            int caseNo = (int)Session["caseNo"];
                            PatientsLogDAL plog = null;
                            PatientsLogBLL plogbll = new PatientsLogBLL();
                            PatientsLogDAL plogdal = new PatientsLogDAL();
                            plog = plogbll.getPatientsLogByCaseNo(caseNo);
                            Session["caseNo"] = caseNo;
                            //decrypt
                            string enkey = plog._enkey;
                            string enIV = plog._enIV;
                            SymmetricAlgorithm sa = new RijndaelManaged();
                            sa.Key = Convert.FromBase64String(enkey);
                            sa.IV = Convert.FromBase64String(enIV);

                            ICryptoTransform cryptTransform = sa.CreateDecryptor();
                            byte[] ciphertext = Convert.FromBase64String(plog._symptomsList);
                            byte[] plaintext = cryptTransform.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
                            string decryptedSymList = Encoding.UTF8.GetString(plaintext);

                            string[] strArray = decryptedSymList.Split(new char[] { ';' });
                            symptomstbx.Text = strArray[0];
                            for (int j = 1; j < (strArray.Length - 1); j++)
                            {
                                string text = strArray[j];
                                symptomstbx.Text += ", " + text;
                            }
                            briefDescriptiontbx.Text = plog._briefDescription;
                            pressuretbx.Text = plog._pressure.ToString();
                            pulsetbx.Text = plog._pulse.ToString();
                            temperaturetbx.Text = plog._temperature.ToString();
                            formDoctorsNotes.Text = plog._doctorsNotes.ToString();
                        }
                        else
                        {
                            Response.Redirect("PatientsLog.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("adminlogin.aspx");
                    }
                }
                
            }
        }

        protected void updateLog_Click(object sender, EventArgs e)
        {
            try
            {
                int caseNo = (int)Session["caseNo"];
                PatientsLogDAL plog = null;
                PatientsLogBLL plogbll = new PatientsLogBLL();
                PatientsLogDAL plogdal = new PatientsLogDAL();
                plog = plogbll.getPatientsLogByCaseNo(caseNo);
                
                string nric = "s9745441h";
                string datetime = plog._datetime.ToString();
                int medicineListID = (int)plog._medicineListID;
                int receiptID = (int)plog._medicineListID;
                int certID = (int)plog._certID;

                //Update
                string doctorsNotes = formDoctorsNotes.Text.Trim();
                string symptomsList = symptomstbx.Text.ToString().Replace(",", ";");
                string description = briefDescriptiontbx.Text;
                string doctorid = plog._doctorID.ToString();
                int pressure = Int32.Parse(pressuretbx.Text);
                int pulse = Int32.Parse(pulsetbx.Text);
                decimal temperature = Decimal.Parse(temperaturetbx.Text);
                string modifiedMethod = "Updated";
                string updatedBy = Session["userNric"].ToString(); ;
                string modifiedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //


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
                //end
                PatientsLogBLL patientlog = new PatientsLogBLL();
                UpdateLogDAL dal = new UpdateLogDAL();
                UpdateLogBLL ulog = new UpdateLogBLL();

                if (patientlog.updatePatientsLog(caseNo, nric, datetime, encryptedSymList, medicineListID, receiptID, certID, doctorsNotes, description, doctorid, pressure, pulse, temperature, enkey, enIV) == true)
                {
                    if (ulog.createUpdatesLog(plog._nric, plog._datetime, plog._medicineListID, plog._receiptID, plog._symptomsList, plog._certID, plog._temperature, updatedBy, modifiedAt, modifiedMethod, plog._briefDescription, plog._doctorsNotes, doctorid, plog._pulse, plog._pressure) == true)
                    {
                        Response.Redirect("doctor-PatientsLog.aspx");
                    }
                    else
                    {

                        Response.Redirect("error.aspx");
                    }
                }
                else
                {
                    Response.Redirect("error.aspx");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Session["caseNo"] = null;
            }
        }
        protected void cancelUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("doctor-PatientsLog.aspx");
        }
    }
}