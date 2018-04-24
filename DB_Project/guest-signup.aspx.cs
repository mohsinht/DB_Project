using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DB_Project.DAL;

namespace DB_Project
{
    public partial class guest_signup : System.Web.UI.Page
    {
        public static bool isNew;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                Response.Redirect("loggedIn.aspx");
        }
        protected void signup_Guest(object sender, EventArgs e)
        {
            try
            {
                if (inputMailg.Text == "")
                {
                    throw new System.ArgumentException("Email cannot be empty", "");
                }
                else if ((!inputMailg.Text.Contains("@")) || (!inputMailg.Text.Contains(".")) || (inputMailg.Text.Contains(" ")))
                {
                    throw new System.ArgumentException("Email is not correct!", "");
                }
                if (inputNameg.Text.Length < 5)
                {
                    throw new System.ArgumentException("Username must be at least 5 characters long", "");
                }
                if (inputPassg.Text.Length < 5)
                {
                    throw new System.ArgumentException("Password must be at least 5 characters long", "");
                }
                if (inputNameg.Text.Contains(" "))
                {
                    throw new System.ArgumentException("Username cannot contain spaces", "");
                }
                myDAL obj = new myDAL();
                int res = 0;
                res = obj.signup_DAL(inputNameg.Text.ToLower(), inputMailg.Text.ToLower(), inputPassg.Text, 1);
                if (res == 0)
                {
                    throw new System.ArgumentException("Email or username already exists", "");
                }
                showErrorsg.Text = "<div style=\"color:green\">Signed up successfully!</div>";
                Session["newlyCreated"] = "1";
                Response.Redirect("login.aspx");
            }
            catch (Exception ex)
            {
                showErrorsg.Text = ex.Message;
            }
        }
    }
}