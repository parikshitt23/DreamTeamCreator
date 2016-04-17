using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using System.Web.Security;

namespace DreamTeamCreator.AnonUsers
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginClick(object sender, EventArgs e)
        {
            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);

            try
            {
                OracleCommand cmd = new OracleCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleTransaction transaction;

               // string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "SHA1");

                OracleParameter email = new OracleParameter("EMAIL", Email.Text);
                OracleParameter password = new OracleParameter("PASSWORD", Password.Text);
                OracleParameter rv = new OracleParameter("RETURNVALUE", OracleDbType.Int32, ParameterDirection.Output);
                OracleParameter userid = new OracleParameter("USERID", OracleDbType.Int32, ParameterDirection.Output);


                cmd.Parameters.Add(email);
                cmd.Parameters.Add(password);
                cmd.Parameters.Add(rv);
                cmd.Parameters.Add(userid);

                con.Open();
                transaction = con.BeginTransaction();
                cmd.ExecuteNonQuery();
                transaction.Commit();

                int returnCode = int.Parse(cmd.Parameters["RETURNVALUE"].Value.ToString());
                int user_id = int.Parse(cmd.Parameters["USERID"].Value.ToString());

                if (returnCode == 1)
                {
                    FormsAuthentication.RedirectFromLoginPage(Email.Text, false);

                }
                else {

                    Response.Write("Please enter valid username and or password");
                }
            }
            catch (OracleException ex)
            {
                Response.Write("<br/><br/><br/><br/><br/>" + ex);
            }
            finally
            {
                con.Close();
            }
        }
    }
}