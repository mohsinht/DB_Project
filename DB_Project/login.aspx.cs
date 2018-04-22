using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DB_Project
{
    public partial class index : System.Web.UI.Page
    {
        private static readonly string connString3 =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                Response.Redirect("loggedIn.aspx");
        }
        protected void login(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connString3);
            con.Open();
            SqlCommand cmd;
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


                cmd = new SqlCommand("Userlogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@password", SqlDbType.NChar, 10);
                cmd.Parameters.Add("@usertype", SqlDbType.Int);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@result", SqlDbType.Int);

                cmd.Parameters["@username"].Value = inputNamel.Text.ToLower();
                cmd.Parameters["@password"].Value = inputPassl.Text;
                cmd.Parameters["@usertype"].Direction = ParameterDirection.Output;
                cmd.Parameters["@email"].Direction = ParameterDirection.Output;
                cmd.Parameters["@result"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@result"].Value.ToString() == "0")
                {
                    throw new System.ArgumentException("Login Failed! Your username or password is incorrect.", "");
                }
                showErrorsl.Text = "<div style=\"color:green\">Logged in successfully!</div>";
                Session["username"] = inputNamel.Text;
                Session["type"] = cmd.Parameters["@usertype"].Value.ToString();
                Response.Redirect("loggedIn.aspx");
            }
            catch (Exception ex)
            {
                showErrorsl.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}