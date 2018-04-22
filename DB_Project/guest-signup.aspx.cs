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
    public partial class host_signup : System.Web.UI.Page
    {
        private static readonly string connString2 =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
        protected void signup_Guest(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connString2);
            con.Open();
            SqlCommand cmd;
            try
            {
                if (inputMailg.Text == "")
                {
                    throw new System.ArgumentException("Email cannot be empty", "");
                }
                else if ((!inputMailg.Text.Contains("@")) || (!inputMailg.Text.Contains(".")))
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


                cmd = new SqlCommand("signup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@password", SqlDbType.NChar, 10);
                cmd.Parameters.Add("@usertype", SqlDbType.Int);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@result", SqlDbType.Int);

                cmd.Parameters["@username"].Value = inputNameg.Text.ToLower();
                cmd.Parameters["@password"].Value = inputPassg.Text;
                cmd.Parameters["@email"].Value = inputMailg.Text.ToLower();
                cmd.Parameters["@usertype"].Value = 1; //1 for guest
                cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@result"].Value.ToString() == "0")
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
            finally
            {
                con.Close();
            }
        }
    }
}