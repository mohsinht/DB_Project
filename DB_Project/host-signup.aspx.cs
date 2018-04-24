using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Registration;
using DB_Project.DAL;
namespace DB_Project
{
    public partial class host_signup : System.Web.UI.Page
    {
        public static bool isNew;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                Response.Redirect("loggedIn.aspx");
        }
        protected void signup_Host(object sender, EventArgs e)
        {
            try
            {
                if(inputMail.Text == "")
                {
                    throw new System.ArgumentException("Email cannot be empty", "");
                }else if ((!inputMail.Text.Contains("@")) || (!inputMail.Text.Contains(".")) || (inputMail.Text.Contains(" ")))
                {
                    throw new System.ArgumentException("Email is not correct!", "");
                }
                if (inputName.Text.Length < 5)
                {
                    throw new System.ArgumentException("Username must be at least 5 characters long", "");
                }
                if (inputPass.Text.Length < 5)
                {
                    throw new System.ArgumentException("Password must be at least 5 characters long", "");
                }
                if (inputName.Text.Contains(" "))
                {
                    throw new System.ArgumentException("Username cannot contain spaces", "");
                }

                myDAL obj = new myDAL();
                int res = 0;
                res = obj.signup_DAL(inputName.Text.ToLower(), inputMail.Text.ToLower(), inputPass.Text, 0);
                if(res == 0)
                {
                    throw new System.ArgumentException("Email or username already exists", "");
                }
                showErrors.Text = "<div style=\"color:green\">Signed up successfully!</div>";
                Session["newlyCreated"] = "1";
                Response.Redirect("login.aspx");
            }
            catch(Exception ex)
            {
                showErrors.Text = ex.Message;
                isNew = false;
            }
        }
    }
}