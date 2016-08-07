using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication2
{
    public class Tool
    {

        public static bool append_log(string text)
        {
            try
            {
                string path = System.AppDomain.CurrentDomain.BaseDirectory;

                string file = Path.Combine(path, "log.txt");

                //DateTime dt = DateTime.Now;

                //File.AppendAllText(file, String.Format("{0:G}", dt));

                //File.AppendAllText(file, ": ");

                File.AppendAllLines(file, new string[] { text });

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static string[] getLogText()
        {
            try
            {
                string path = System.AppDomain.CurrentDomain.BaseDirectory;

                string file = Path.Combine(path, "log.txt");

                //return File.ReadAllText(file, UTF8Encoding.UTF8);

                //return String.Join("\r\n", File.ReadAllLines(file));

                return File.ReadAllLines(file);
            }
            catch (Exception e)
            {
                return new string[]{};
            }
        }

    }
}
