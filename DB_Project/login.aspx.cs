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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                Response.Redirect("loggedIn.aspx");
            if (Session["newlyCreated"] != null)
                showErrorsl.Text = "<div style=\"color:green\">Your account has been successfully created. Login to continue!</div>";
        }
        protected void login(object sender, EventArgs e)
        {
            try
            {
                if (inputNamel.Text.Length < 5)
                {
                    throw new System.ArgumentException("Username must be at least 5 characters long", "");
                }
                if (inputPassl.Text.Length < 5)
                {
                    throw new System.ArgumentException("Password must be at least 5 characters long", "");
                }


                myDAL obj = new myDAL();
                int res = 0;
                string email = "";
                int usertype = 0;

                res = obj.login_DAL(inputNamel.Text.ToLower(), inputPassl.Text, ref usertype, ref email);

                if (res == 0)
                {
                    throw new System.ArgumentException("Login Failed! Your username or password is incorrect.", "");
                }
                showErrorsl.Text = "<div style=\"color:green\">Logged in successfully!</div>";
                Session["username"] = inputNamel.Text;
                Session["type"] = usertype;
                Session["newlyCreated"] = null;
                Response.Redirect("loggedIn.aspx");
            }
            catch (Exception ex)
            {
                showErrorsl.Text = ex.Message;
            }
        }
    }
}