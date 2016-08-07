using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace ITP311
{
    /// <summary>
    /// Summary description for Enquiry_MailDt
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Enquiry_MailDt : System.Web.Services.WebService
    {

        [WebMethod]
        public void getMailDT()
        {
            List<EnquiryDAL> eList = new List<EnquiryDAL>();
            EnquiryBLL eBll = new EnquiryBLL();
            eList = eBll.retrieveAllEnquiry();
            List<EnquiryDisplay> edList = new List<EnquiryDisplay>();
            EnquiryDisplay ed;
            for (int i = 0; i < eList.Count; i++)
            {
                string format = "g";
                DateTime dt = eList[i].dateTime;
                string dt1 = dt.ToString(format);
                ed = new EnquiryDisplay(eList[i].id, eList[i].name, dt1);
                edList.Add(ed);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(edList));
        }
    }
}
