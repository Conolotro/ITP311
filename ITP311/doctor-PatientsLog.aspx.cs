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
    public partial class doctor_PatientsLog : System.Web.UI.Page
    {
        SqlConnection con =  new SqlConnection(@"Data Source=(localdb)\v11.0;AttachDbFilename=C:\Users\Daniel\Desktop\ITP311\ITP311\ITP311\App_Data\medicalportal.mdf;Integrated Security=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PatientsLogBLL plogbll = new PatientsLogBLL();
                DataTable dt = new DataTable();
                dt = plogbll.getDTGrid();
                gvCaseNumber.DataSource = dt;
                gvCaseNumber.DataBind();
                gvCaseNumber.Columns[1].Visible = false;

            }
        }

        protected void gvCaseNumber_SelectedIndexChanged(object sender, EventArgs e)
        { 
            PatientsLogDAL plog = null;
            PatientsLogBLL plogbll = new PatientsLogBLL();
            PatientsLogDAL plogdal = new PatientsLogDAL();
            int caseNo = int.Parse(gvCaseNumber.SelectedRow.Cells[1].Text);
            plog = plogbll.getPatientsLogByCaseNo(caseNo);


            nricLbl.Text = plog._nric;
            dateOfLogLbl.Text= plog._datetime;
            symptomsLbl.Text = plog._symptomsList;
            diagnosisLbl.Text = plog._doctorsNotes;
            prescriptionLbl.Text = plog._medicineListID.ToString();
        }
        
    }
}