using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.UI;

namespace DreamTeamCreator
{
    public partial class Leaderboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);   

            try
            {
                string query = "SELECT * FROM LEADERBOARD";
                OracleCommand cmd = new OracleCommand(query, con);
                con.Open();
                OracleDataReader rdr = cmd.ExecuteReader();
                leaderBoardGridView.DataSource = rdr;
                leaderBoardGridView.DataBind();
            }
            catch (OracleException ex)
            {
                Response.Write("<br>/" + "<br>/" + "<br>/" + "<br>/" + "<br>/" + ex);
            }
            finally
            {
                con.Close();
            }
        }
    }
}