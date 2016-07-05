using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using ITP311.DAL;
using System.Collections;

namespace ITP311.BLL
{
    public class AccountBLL
    {
            
         public int CreateAccount(string NRIC, string fname, string lname, string PasswordHash, string PasswordSalt, string Email, string ContactNo, string Type)
        {
            AccountDAL acct = new AccountDAL();

            try
            {
                return acct.CreateAccount(NRIC, fname, lname, PasswordHash, PasswordSalt, Email, ContactNo, Type);
            }
            catch
            {
                throw;
            }
             finally
            {
                acct = null;
            }
        }
        

     

    }
}