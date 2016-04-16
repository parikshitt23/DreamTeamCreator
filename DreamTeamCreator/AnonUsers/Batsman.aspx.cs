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
    public partial class Batsman : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void BatsmanSearch_Click(object sender, EventArgs e)
        {
            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);
            try
            {
                string query = QueryBuilderClass.BatsmanQueryBuilder(BattingTeamNameDropDown, BattingAverageDropDown, BattingStrikeRateDropDown, BatsmanNameTextBox, HalfCenturyCheckBox, CenturyCheckbox);
                OracleCommand cmd = new OracleCommand(query, con);
                con.Open();
                OracleDataReader rdr = cmd.ExecuteReader();
                BatsmanSearchResult.DataSource = rdr;
                BatsmanSearchResult.DataBind();
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