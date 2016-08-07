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
using System.Web.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Web.UI.DataVisualization.Charting;
using ITP311;

namespace ITP311
{
    public partial class doctor_PatientsLog : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;AttachDbFilename=C:\Users\Daniel\Desktop\ITP311\ITP311\ITP311\App_Data\medicalportal.mdf;Integrated Security=True");
        StringBuilder str = new StringBuilder();
        string[] medicinearr = { "Select Medicine", "Generic Zocor", "Lisinopril", "Amoxicillin", "Glucophage", "Advair Diskus", "Generic Prilosec" };
        List<string> medicinelist = new List<string>();

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
                    string Nric = Session["userNric"].ToString();
                    AccountBLL a = new AccountBLL();
                    AccountDAL ad = a.retrieveAccountByNric(Nric);
                    name.Text = ad.firstName;

                    Session["caseNo"] = null;
                    if (Request.QueryString.AllKeys.Contains("Nric"))
                    {
                        if (Request.QueryString["Nric"].ToString() != null)
                        {
                            Session["search"] = Request.QueryString["Nric"].ToString();
                        }
                    }
                    if (Session["search"] != null)
                    {

                        medicinelist = medicinearr.ToList<string>();
                        medicineListDDL.DataSource = medicinelist;
                        medicineListDDL.DataBind();
                        string search = Session["search"].ToString();
                        nricLbl.Text = search;
                        PatientsLogBLL plogbll = new PatientsLogBLL();
                        DataTable dt = new DataTable();
                        dt = plogbll.getDTGrid(search);
                        gvCaseNumber.DataSource = dt;
                        gvCaseNumber.DataBind();
                        gvCaseNumber.Columns[2].Visible = false;


                        PatientsLogDAL plog = null;
                        PatientsLogDAL plogdal = new PatientsLogDAL();
                        plog = plogbll.getPatientsLogByCaseNo(1);


                    }
                }

            }
        }

        protected void gvCaseNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            symptomsLbl.Text = "";
            PatientsLogDAL plog = null;
            PatientsLogBLL plogbll = new PatientsLogBLL();
            PatientsLogDAL plogdal = new PatientsLogDAL();
            int caseNo = int.Parse(gvCaseNumber.SelectedRow.Cells[2].Text);
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
            for (int j = 0; j < strArray.Length; j++)
            {
                string text = strArray[j];
                symptomsLbl.Text += text + "<br/>";
            }
            briefDescriptionlbl.Text = plog._briefDescription;
            dateOfLogLbl.Text = plog._datetime;
            diagnosisLbl.Text = plog._doctorsNotes;
            
            //MedicineListBLL mb = new MedicineListBLL();
            
              //  List<MedicineListDAL> ml = mb.retrieveMedicineList(plog._caseNo);

                //for (int i = 0; i < ml.Count; i++)
                //{
                 //   prescription.Text += ml[i].medicine + "<br/>";
                //}



        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["caseNo"] != null)
            {
                Response.Redirect("UpdatePatientsLog.aspx", false);
            }
            else
            {
                Response.Redirect("doctor-PatientsLog.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            PatientsLogBLL plog = new PatientsLogBLL();
            try
            {
                int caseNo = (int)Session["caseNo"];
                if (plog.deletePatientsLog(caseNo) == true)
                {
                    Response.Redirect("doctor-PatientsLog.aspx");
                }
                else
                {
                    Response.Redirect("error.aspx");
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void createPrescription_Click(object sender, EventArgs e)
        {
            PatientsLogDAL plog = null;
            PatientsLogBLL plogbll = new PatientsLogBLL();
            PatientsLogDAL plogdal = new PatientsLogDAL();
            int caseNo = int.Parse(gvCaseNumber.SelectedRow.Cells[2].Text);
            plog = plogbll.getPatientsLogByCaseNo(caseNo);

            int medicineListID = plog._medicineListID;
            string medicine = "";
            MedicineListBLL mlistBLL = new MedicineListBLL();
            MedicineListDAL mlistDAL = new MedicineListDAL();
            
                if (medicineListDDL.SelectedValue == "0")
                {
                    errorMsg.Text = "Please Select a Symptom!";
                }
                else
                {
                    medicine = medicineListDDL.SelectedItem.Text;
                    if (mlistBLL.createMedicineList(plog._caseNo, medicine) == true)
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
    }
