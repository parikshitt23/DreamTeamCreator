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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterClick(object sender, EventArgs e)
        {
            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);
            try
            {
                OracleCommand cmd = new OracleCommand("spRegisterUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleTransaction transaction;

               // string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "SHA1");

                OracleParameter email = new OracleParameter("EMAIL", Email.Text);
                OracleParameter username = new OracleParameter("USERNAME", Username.Text);
                OracleParameter userTeamName = new OracleParameter("U_TEAM_NAME", TeamName.Text);
                OracleParameter password = new OracleParameter("PASSWORD", Password.Text);
                OracleParameter rv = new OracleParameter("RETURNVALUE", OracleDbType.Int32, ParameterDirection.Output);




                cmd.Parameters.Add(email);
                cmd.Parameters.Add(password);
                cmd.Parameters.Add(username);
                cmd.Parameters.Add(userTeamName);
                cmd.Parameters.Add(rv);

                con.Open();
                transaction = con.BeginTransaction();
                cmd.ExecuteNonQuery();
                transaction.Commit();
                int returnCode = int.Parse(cmd.Parameters["RETURNVALUE"].Value.ToString());

                if (returnCode == 1)
                {
                    Response.Redirect("~/Login.aspx");

                }
                else {

                    Response.Write("Username already exists");
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