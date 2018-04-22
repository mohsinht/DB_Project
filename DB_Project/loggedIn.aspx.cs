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
    public partial class loggedIn : System.Web.UI.Page
    {
        public string Uemail;
        private static readonly string connStringd =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("login.aspx");
            SqlConnection con = new SqlConnection(connStringd);
            con.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from login where username='" + Session["username"].ToString() + "'", con);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                inputEmaild.Text = (myReader["email"].ToString());
                if((myReader["usertype"].ToString()) == "1")
                {
                    inputUserTyped.Text = "Guest Account";
                }
                if ((myReader["usertype"].ToString()) == "0")
                {
                    inputUserTyped.Text = "Host Account";
                }
                inputNamed.Text = (myReader["username"].ToString());
                Uemail = (myReader["email"].ToString());
            }
            con.Close();

         }
        protected void logout(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connStringd);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("logout", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30);

                cmd.Parameters["@email"].Value = Uemail;

                cmd.ExecuteNonQuery();
                showErrorsd.Text = "<div style=\"color:green\">Logged out successfully!</div>";
                Session["username"] = null;
                Session["type"] = null;
                Response.Redirect("login.aspx");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
    }
}