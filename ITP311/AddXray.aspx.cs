using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication2
{
    public partial class AddXray : System.Web.UI.Page
    {
        RSAParameters keyInfo = new RSAParameters();

        string symKeyEnc = "IiAXZNRNZ1AhaEzi86iCGSNfkkoq1EJmWgBUblZMgGk/n6r994A0qSwZ7LNbQuq0H+xWXQ/7myoln4Zicv/ucXDL8IycZuyjk4usBXnNjWicgC7MDIlNtWv9My4S+cYf1YWnvGEoYkaod5ggWsVGsapaJEmV1biDrK/8efDoD3Q=";
        string IV = "C5-23-B9-AE-5F-B7-5E-4F-8F-43-28-1D-76-55-85-F0";


        string modulus = "B7-43-10-CA-05-18-E8-A8-BC-93-14-90-BC-C8-48-AE-0D-F4-73-CC-A5-CE-08-A7-6E-A2-60-2F-8B-5F-BC-9B-8B-FF-76-65-3F-22-5C-92-BF-D7-42-67-E9-D9-7F-0C-58-0B-45-B7-EB-97-2F-29-6A-16-DB-00-89-3C-3F-97-1D-2D-0F-E9-93-4B-7A-01-1F-D2-10-B2-1D-B0-21-67-2E-A0-9F-05-20-55-C8-5E-9D-21-70-2A-15-59-1E-17-90-58-4D-EB-3D-EA-82-19-A7-AF-9B-05-6E-B1-95-AD-AC-A2-47-1C-54-6D-8A-17-A7-C5-7A-C7-95-ED-F1-75";
        string exponent = "01-00-01";

        //
        string P = "F3-0E-69-CC-50-A4-40-BC-3A-EC-DE-61-B1-7A-9B-7C-2E-79-78-D0-CB-CE-55-70-7C-7A-8E-B0-BB-DA-0B-84-86-1E-90-BC-09-EB-BD-A4-07-23-15-7F-B9-7B-47-98-B6-4F-D8-AC-DF-AC-32-A7-38-11-43-EE-6F-B3-72-A5";
        string Q = "C1-05-79-E8-E1-A6-D1-A3-27-15-CD-9D-20-08-E7-73-AA-66-7C-26-79-77-25-59-6B-A1-27-BA-90-E4-C1-5C-72-F8-C1-FC-10-5E-2D-2D-4E-DF-AF-7A-0B-9C-A3-42-F3-0F-1C-C5-B1-17-D0-8B-DE-D6-AC-85-CA-4C-5A-91";
        string DP = "49-08-0F-AA-20-A0-FA-02-95-02-0F-5F-F3-60-0F-D0-24-76-C3-62-99-9A-89-F9-9E-AD-84-AA-7E-07-6A-66-8B-96-2B-8F-14-BC-0C-E3-78-71-86-48-36-87-60-5F-F6-87-CF-67-42-5E-0F-6A-47-62-88-B2-E0-45-5F-31";
        string DQ = "22-BA-28-7F-D4-B1-5D-C0-3B-D4-F9-64-4E-92-2B-8A-2C-DB-39-74-F6-9F-90-11-B1-82-92-12-47-E5-50-40-A0-D2-CE-9B-DA-1A-07-88-C2-4B-0E-58-27-E4-AB-9E-EC-FA-08-14-2D-53-7A-8A-DF-B1-C1-E2-64-4E-2E-71";
        string InverseQ = "E6-F4-8D-45-DB-85-4A-45-85-5F-37-83-AD-26-B4-D8-AF-B8-F7-1C-7E-32-ED-D0-78-53-66-42-B9-E1-AE-0C-59-CB-EE-67-C8-00-4E-0A-F2-6E-C6-BC-48-C3-7C-E1-C2-EF-C8-66-69-5F-00-9E-9B-E7-D3-54-68-98-E5-61";

        //for demo, store it somewhere else
        string privateExponent = "19-C7-7A-5E-20-B7-6F-4B-05-33-DF-69-B8-D4-A7-BC-AC-43-DD-E2-44-D4-A5-CC-FF-B8-21-B5-AE-72-6A-32-AB-4F-E5-54-BA-BB-D7-AF-E1-02-A3-D9-C0-40-93-29-A6-5C-F7-92-B6-B6-4E-B1-11-B6-63-5A-40-F3-D3-B1-ED-D5-D7-AD-0A-94-26-FF-CE-96-95-00-CF-CF-5A-FF-48-75-D0-B6-20-41-BB-D8-16-5A-D6-D5-2A-9C-E2-9D-BE-4B-2A-CA-F7-D1-08-56-E8-FE-5A-21-CB-DA-CC-F7-BB-F3-C5-52-0F-2F-12-C5-A6-47-33-C5-24-22-6C-C1";


        protected void Page_Load(object sender, EventArgs e)
        {
            //simulate logged in
            Session["LoggedIn"] = "S7654321A";
            Session["Doctor"] = "true";



            //if (!checkLogin())
                //Response.Redirect("login.aspx", true);

            DateTime dt = DateTime.Now;
            Tool.append_log(symEncrypt(String.Format("{0:G}", dt) + ": " + "User \"" + Session["LoggedIn"] + "\" has entered Xray.aspx"));
        }

        protected void upload()
        {
            string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MYDBConnection"].ConnectionString;


            string filePath = FileUpload1.PostedFile.FileName;
            string fileName = Path.GetFileName(filePath);
            string ext = Path.GetExtension(fileName).ToLower();
            string contentType = String.Empty;


            switch (ext)
            {
                case ".jpg":
                    contentType = "image/jpg";
                    break;
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".gif":
                    contentType = "image/gif";
                    break;
            }



            if (contentType != String.Empty)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(MYDBConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Xray VALUES(@Image, @PatientIC, @PatientName, @PatientDOB, @Description, @DateTimeAdded)"))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.CommandType = CommandType.Text;

                                Stream fs = FileUpload1.PostedFile.InputStream;
                                BinaryReader br = new BinaryReader(fs);
                                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                                cmd.Parameters.AddWithValue("@Image", bytes);
                                cmd.Parameters.AddWithValue("@PatientIC", txtPatientIC.Text);
                                cmd.Parameters.AddWithValue("@PatientName", txtPatientName.Text);
                                cmd.Parameters.AddWithValue("@PatientDOB", txtPatientDOB.Text);
                                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                                cmd.Parameters.AddWithValue("@DateTimeAdded", DateTime.Now);
                                cmd.Connection = con;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();


                                DateTime dt = DateTime.Now;
                                Tool.append_log(symEncrypt(String.Format("{0:G}", dt) + ": " + "User \"" + Session["LoggedIn"] + "\" has added Xray profile"));

                                Response.Redirect("Xray.aspx", true);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.ToString());
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('Invalid image')", true);
            }
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            upload();
        }

        protected bool checkLogin()
        {
            if (Session["LoggedIn"] == null || Session["Doctor"] == null || Request.Cookies["AuthToken"] == null)
                return false;
            if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                return false;

            return true;
        }







        public byte[] hexStringToBytes(String hex)
        {
            String[] arr = hex.Split('-');
            byte[] array = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                array[i] = Convert.ToByte(arr[i], 16);

            return array;
        }

        public string asymEncrypt(string raw)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

                /*
                RSAParameters privateParamas = rsa.ExportParameters(true);
                txtModulus.Text = BitConverter.ToString(privateParamas.Modulus);
                txtExponent.Text = BitConverter.ToString(privateParamas.Exponent);
                txtP.Text = BitConverter.ToString(privateParamas.P);
                txtQ.Text = BitConverter.ToString(privateParamas.Q);
                txtDP.Text = BitConverter.ToString(privateParamas.DP);
                txtDQ.Text = BitConverter.ToString(privateParamas.DQ);
                txtInverseQ.Text = BitConverter.ToString(privateParamas.InverseQ);
                txtPrivateExponent.Text = BitConverter.ToString(privateParamas.D);
                */

                keyInfo.Modulus = hexStringToBytes(modulus);
                keyInfo.Exponent = hexStringToBytes(exponent);
                keyInfo.P = hexStringToBytes(P);
                keyInfo.Q = hexStringToBytes(Q);
                keyInfo.DP = hexStringToBytes(DP);
                keyInfo.DQ = hexStringToBytes(DQ);
                keyInfo.InverseQ = hexStringToBytes(InverseQ);
                keyInfo.D = hexStringToBytes(privateExponent);

                rsa.ImportParameters(keyInfo);
                byte[] encrypted = rsa.Encrypt(Encoding.UTF8.GetBytes(raw), false);
                return Convert.ToBase64String(encrypted);
            }
            catch (Exception e)
            {
                //throw new Exception(e.ToString());
                return "";
            }

        }


        public string asymDecrypt(byte[] cipherText)
        {
            try
            {
                RSACryptoServiceProvider rsa2 = new RSACryptoServiceProvider();

                keyInfo.Modulus = hexStringToBytes(modulus);
                keyInfo.Exponent = hexStringToBytes(exponent);
                keyInfo.P = hexStringToBytes(P);
                keyInfo.Q = hexStringToBytes(Q);
                keyInfo.DP = hexStringToBytes(DP);
                keyInfo.DQ = hexStringToBytes(DQ);
                keyInfo.InverseQ = hexStringToBytes(InverseQ);
                keyInfo.D = hexStringToBytes(privateExponent);

                rsa2.ImportParameters(keyInfo);
                byte[] decrypted = rsa2.Decrypt(cipherText, false);
                return Encoding.UTF8.GetString(decrypted);
            }
            catch (Exception e)
            {
                //throw new Exception(e.ToString());
                return "";
            }
        }

        public string symEncrypt(String raw)
        {
            try
            {
                SymmetricAlgorithm sa = new RijndaelManaged();


                //sa.GenerateKey();
                //txtPlain.Text = BitConverter.ToString(sa.Key);
                //txtEncrypted.Text = BitConverter.ToString(sa.Key);

                sa.Key = hexStringToBytes(asymDecrypt(Convert.FromBase64String(symKeyEnc)));
                sa.IV = hexStringToBytes(IV);



                ICryptoTransform cryptoTransform = sa.CreateEncryptor();
                byte[] plainTextAOB = System.Text.Encoding.UTF8.GetBytes(raw);
                byte[] cipherAOB = cryptoTransform.TransformFinalBlock(plainTextAOB, 0, plainTextAOB.Length);

                return Convert.ToBase64String(cipherAOB);
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public string symDecrypt(String cipher)
        {
            try
            {
                SymmetricAlgorithm sa = new RijndaelManaged();


                sa.Key = hexStringToBytes(asymDecrypt(Convert.FromBase64String(symKeyEnc)));
                sa.IV = hexStringToBytes(IV);



                ICryptoTransform cryptoTransform = sa.CreateDecryptor();
                byte[] cipherAOB = Convert.FromBase64String(cipher);
                byte[] plainTextAOB = cryptoTransform.TransformFinalBlock(cipherAOB, 0, cipherAOB.Length);
                return System.Text.Encoding.UTF8.GetString(plainTextAOB);
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}