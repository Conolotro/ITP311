using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ITP311
{
    public class AccountDAL
    {
        public string nric { get; set; }
        public string passwordHash { get; set; }
        public string salt { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int contactNo { get; set; }

        String strConnectionString = ConfigurationManager.ConnectionStrings["itp311"].ToString();

        public AccountDAL(string nric,string passwordHash,string salt,string firstName,string lastName,int contactNo)
        {
            this.nric = nric;
            this.passwordHash = passwordHash;
            this.salt = salt;
            this.firstName = firstName;
            this.lastName = lastName;
            this.contactNo = contactNo;
        }


    }
}