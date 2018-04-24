using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DB_Project.DAL
{
    public class myDAL
    {
        private static readonly string connString =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;

        //usertype: 1 for host -- 0 for guest
        public int signup_DAL(string name, string email, string password, int usertype)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("signup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@password", SqlDbType.NChar, 10);
                cmd.Parameters.Add("@usertype", SqlDbType.Int);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@result", SqlDbType.Int);

                cmd.Parameters["@username"].Value = name;
                cmd.Parameters["@password"].Value = password;
                cmd.Parameters["@email"].Value = email;
                cmd.Parameters["@usertype"].Value = usertype;
                cmd.Parameters["@result"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (cmd.Parameters["@result"].Value.ToString() == "0")
                {
                    return 0;
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public int login_DAL(string name, string password, ref int usertype, ref string email)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Userlogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@password", SqlDbType.NChar, 10);
                cmd.Parameters.Add("@usertype", SqlDbType.Int);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@result", SqlDbType.Int);

                cmd.Parameters["@username"].Value = name;
                cmd.Parameters["@password"].Value = password;
                cmd.Parameters["@usertype"].Direction = ParameterDirection.Output;
                cmd.Parameters["@email"].Direction = ParameterDirection.Output;
                cmd.Parameters["@result"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                email = cmd.Parameters["@email"].Value.ToString();
                if(cmd.Parameters["@usertype"].Value.ToString() == "1")
                {
                    usertype = 1;
                }else
                {
                    usertype = 0;
                }

                if (cmd.Parameters["@result"].Value.ToString() == "0")
                {
                    return 0;
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }



    }
}