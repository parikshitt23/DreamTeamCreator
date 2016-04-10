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
    public partial class Bowlers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);
            if (!IsPostBack)
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("select 0 as id,'Select Team..' teams from dual union all select distinct team_id id, teams from team_ids", con);
                    con.Open();
                    DropTeam.DataSource = cmd.ExecuteReader();
                    DropTeam.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<br/><br/><br/><br/><br/>" + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }            
        }

        protected void DropTeamSelect(object sender, EventArgs e)
        {

        }
    }
}