using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;

namespace DreamTeamCreator.AnonUsers
{
    public partial class Bowlers : System.Web.UI.Page
    {
        string bowlername = "", teamid = "", econrange = "", wicketsrange = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            //OracleConnection con = new OracleConnection(oracleConnectionString);
            //if (!IsPostBack)
            //{
            //    try
            //    {
            //        OracleCommand cmd = new OracleCommand("select 0 as id,'Select Team..' teams from dual union all select distinct team_id id, teams from team_ids", con);
            //        con.Open();
            //        DropTeam.DataSource = cmd.ExecuteReader();
            //        DropTeam.DataBind();
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write("<br/><br/><br/><br/><br/>" + ex.Message);
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }
            //}            
        }

        protected void DropTeamSelect(object sender, EventArgs e)
        {
            try
            {
                if (!DropTeam.SelectedValue.Equals('0'))
                {
                    teamid = DropTeam.SelectedValue;
                }
            }
            catch (Exception ex) {
                Response.Write("<br/><br/><br/><br/><br/>" + ex.Message);
            }
        }

        protected void EconomySelect(object sender, EventArgs e)
        {
//select distinct economy from
//(select distinct season, bowler, cast((sum(run_scored) / (count(*) / 6)) as numeric(15, 2)) as economy
//from ball_by_ball
//group by season, bowler) a
//order by 1
        }

        protected void WicketsSelect(object sender, EventArgs e)
        {
//select distinct season, bowler,count(*) as wickets_taken
//from ball_by_ball
//where out_decision <> '*'
//group by season, bowler
        }

        protected void Search_Click(object sender, EventArgs e)
        {

        }
    }
}