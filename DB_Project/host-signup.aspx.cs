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
namespace DB_Project
{
    public partial class host_signup : System.Web.UI.Page
    {
        private static readonly string connString =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
        public static bool isNew;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void signup_Host(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                if(inputMail.Text == "")
                {
                    throw new System.ArgumentException("Email cannot be empty", "");
                }else if ((!inputMail.Text.Contains("@")) || (!inputMail.Text.Contains(".")))
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
             

                cmd = new SqlCommand("signup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@password", SqlDbType.NChar, 10);
                cmd.Parameters.Add("@usertype", SqlDbType.Int);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@result", SqlDbType.Int);

                cmd.Parameters["@username"].Value = inputName.Text.ToLower();
                cmd.Parameters["@password"].Value = inputPass.Text;
                cmd.Parameters["@email"].Value = inputMail.Text.ToLower();
                cmd.Parameters["@usertype"].Value = 0; //0 for host
                cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                if(cmd.Parameters["@result"].Value.ToString() == "0")
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
            finally
            {
                con.Close();
            }
        }
    }
}