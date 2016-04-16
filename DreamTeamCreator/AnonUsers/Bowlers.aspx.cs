using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Text.RegularExpressions;

namespace DreamTeamCreator.AnonUsers
{
    public partial class Bowlers : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
                
        }



        protected void Search_Click(object sender, EventArgs e)
        {

            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);
            try
            {
                string query = QueryBuilderClass.BatsmanQueryBuilder(DropTeam, EconomyDrop, Wickets_Taken, Name);
                OracleCommand cmd = new OracleCommand(query, con);
                con.Open();
                OracleDataReader rdr = cmd.ExecuteReader();
                BowlerSearchRes.DataSource = rdr;
                BowlerSearchRes.DataBind();
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