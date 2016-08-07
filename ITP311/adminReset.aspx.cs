using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Collections;

namespace ITP311
{
    public partial class adminReset : System.Web.UI.Page
    {
        String nricFirst;
        PasswordScore pass;
        AccountBLL ab = new AccountBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
           nricFirst = (string)(Session["userNric"]);
        }

        protected void submitbutton_Click(object sender, EventArgs e)
        {
            pass = CheckStrength(formPassword.Text);

            if (formPassword.Text.Length < 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please enter a password');</script>");
            }
            else
            {
                if (pass == PasswordScore.VeryStrong || pass == PasswordScore.Strong)
                {
                    AccountBLL ab = new AccountBLL();
                    AccountDAL ad = new AccountDAL();
                    if (formPassword.Text == formConfirmPassword.Text)
                    {
                        //retrieve salt from database and put Hash into database
                        AccountDAL aa = ab.retrieveAccountByNric(nricFirst);
                        string hashedPass = AccountBLL.generatePasswordHash(formPassword.Text, aa.passwordSalt);
                        ad.updatePasswordForUser(nricFirst, hashedPass);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Password has been reset');</script>");
                        adminlogin.resetCounter = 1;
                        Response.Redirect("adminlogin.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Password does not match');</script>");
                        formPassword.Text = "";
                        formConfirmPassword.Text = "";
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Password is too weak, please enter a more complicated password. Usage of caps and lower caps as well as numbers will help.');</script>");
                }
            }
        }

        public enum PasswordScore
        {
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }

        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;

            if (password.Length <= 3)
                score++;
            if (password.Length >= 4)
                score++;
            if (password.Length >= 6)
                score++;
            if (Regex.Match(password, @"[^\d]", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"[^a-z]", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"[^A-Z]", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }

        protected void formPassword_TextChanged(object sender, EventArgs e)
        {
                pass = CheckStrength(formPassword.Text);

                if (pass == PasswordScore.VeryWeak)
                {
                    pass = PasswordScore.VeryWeak;
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Very Weak";
                }
                else if (pass == PasswordScore.Weak)
                {
                    pass = PasswordScore.Weak;
                    Label1.ForeColor = System.Drawing.Color.Orange;
                    Label1.Text = "Weak";
                }
                else if (pass == PasswordScore.Medium)
                {
                    pass = PasswordScore.Medium;
                    Label1.ForeColor = System.Drawing.Color.Yellow;
                    Label1.Text = "Medium";
                }
                else if (pass == PasswordScore.Strong)
                {
                    pass = PasswordScore.Strong;
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "Strong";
                }
                else
                {
                    pass = PasswordScore.VeryStrong;
                    Label1.ForeColor = System.Drawing.Color.DarkGreen;
                    Label1.Text = "Very Strong";
                }
        }

    }
}