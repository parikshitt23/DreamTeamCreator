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
    public partial class BowlerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string bowlerName = (string)Session["BowlerName"];
            BowlerPageHeading.Text = BowlerPageHeading.Text + " : " + bowlerName;

            Dictionary<string, string> bowlerDetailsQueryMap = QueryBuilderClass.BowlerDetailsQueryBuilder(bowlerName);

            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);
            try
            {
                con.Open();
                foreach (string query in bowlerDetailsQueryMap.Values)
                {
                    //string query1 = "select * from (select batsman, bowler, sixes, fours, sixes + fours as total_boundaries from (select s.strike_bat as batsman, s.bowler as bowler, s.sixes as sixes, f.fours as fours from( select strike_bat, bowler, count(run_scored)as sixes  from ball_by_ball  where run_scored = '6' group by strike_bat, bowler) s, (select strike_bat, bowler, count(run_scored)as fours  from ball_by_ball where run_scored = '4' group by strike_bat, bowler) f where s.strike_bat = f.strike_bat and s.bowler = f.bowler) order by total_boundaries desc, sixes desc, fours desc) all_data where ROWNUM = 1 AND Bowler = 'P Kumar'";
                    //string query = "select * from (select bowler, max(wickets) as wickets, min(runs_conceded) as runs_conceded from (select x.season as season, x.match_id as match_id, x.bowler as bowler, x.wickets as wickets, y.runs_conceded as runs_conceded from(select season, match_id, bowler, count(out_decision) as wickets from ball_by_ball where out_decision != '*' group by season, match_id, bowler) x, (select season, match_id, bowler, sum(run_scored) as runs_conceded from ball_by_ball group by season, match_id, bowler) y where x.season = y.season and x.match_id = y.match_id and x.bowler = y.bowler) group by bowler order by wickets desc, runs_conceded asc) all_data where Bowler = '" + bowlerName + "'";
                    OracleCommand cmd = new OracleCommand(query, con);

                    OracleDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        if (query == bowlerDetailsQueryMap["wicketsRunsQuery"])
                        {
                            while (rdr.Read())
                            {
                                WicketsLabel.Text = rdr.GetInt32(1).ToString();
                                RunsConcededLabel.Text = rdr.GetInt32(2).ToString();
                            }
                        }

                        if (query == bowlerDetailsQueryMap["boundariesAgainstQuery"])
                        {
                            while (rdr.Read())
                            {
                                WorstBatsmanLabel.Text = rdr.GetString(0);
                                SixesLabel.Text = rdr.GetInt32(2).ToString();
                                FoursLabel.Text = rdr.GetInt32(3).ToString();
                            }
                        }
                    }
                }
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