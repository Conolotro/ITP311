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
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select caseNo from PatientsLog";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}