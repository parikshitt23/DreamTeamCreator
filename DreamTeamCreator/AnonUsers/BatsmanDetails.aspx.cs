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
    public partial class BatsmanDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string batsmanName = (string)Session["BatsmanName"];
            BatsmanPageHeading.Text = BatsmanPageHeading.Text + " : " + batsmanName;

            Dictionary<string, string> batsmanDetailsQueryMap = QueryBuilderClass.BatsmanDetailsQueryBuilder(batsmanName);

            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);
            try
            {
                con.Open();
                foreach (string query in batsmanDetailsQueryMap.Values)
                {
                    //string query1 = "select * from (select batsman, bowler, sixes, fours, sixes + fours as total_boundaries from (select s.strike_bat as batsman, s.bowler as bowler, s.sixes as sixes, f.fours as fours from( select strike_bat, bowler, count(run_scored)as sixes  from ball_by_ball  where run_scored = '6' group by strike_bat, bowler) s, (select strike_bat, bowler, count(run_scored)as fours  from ball_by_ball where run_scored = '4' group by strike_bat, bowler) f where s.strike_bat = f.strike_bat and s.bowler = f.bowler) order by total_boundaries desc, sixes desc, fours desc) all_data where ROWNUM = 1 AND Bowler = 'P Kumar'";
                    //string query = "select * from (select bowler, max(wickets) as wickets, min(runs_conceded) as runs_conceded from (select x.season as season, x.match_id as match_id, x.bowler as bowler, x.wickets as wickets, y.runs_conceded as runs_conceded from(select season, match_id, bowler, count(out_decision) as wickets from ball_by_ball where out_decision != '*' group by season, match_id, bowler) x, (select season, match_id, bowler, sum(run_scored) as runs_conceded from ball_by_ball group by season, match_id, bowler) y where x.season = y.season and x.match_id = y.match_id and x.bowler = y.bowler) group by bowler order by wickets desc, runs_conceded asc) all_data where Bowler = '" + bowlerName + "'";
                    OracleCommand cmd = new OracleCommand(query, con);

                    OracleDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        if (query == batsmanDetailsQueryMap["batsmanWithMostDucks"])
                        {
                            while (rdr.Read())
                            {
                                DucksLabel.Text = rdr.GetInt32(1).ToString();
                            }
                        }

                       if (query == batsmanDetailsQueryMap["batsmanCenturiesAndHalfCenturies"])
                        {
                            while (rdr.Read())
                            {
                                HalfCenturiesLabel.Text = rdr.GetInt32(2).ToString();
                                CenturiesLabel.Text = rdr.GetInt32(1).ToString();
                            }
                        }
                       if(query == batsmanDetailsQueryMap["batsmanHighestScore"])
                        {
                            while (rdr.Read())
                            {
                                SeasonLabel.Text = rdr.GetString(0);
                                MaximumRunsScoredLabel.Text = rdr.GetInt32(2).ToString();
                            }
                        }
                       if(query == batsmanDetailsQueryMap["batsmanRunOuts"])
                        {
                            while(rdr.Read())
                            {
                                RunOutsLabel.Text = rdr.GetInt32(1).ToString();
                            }
                        }
                       if(query == batsmanDetailsQueryMap["MaximumBallsPlayedByBatsman"])
                        {
                            while(rdr.Read())
                            {
                                SeasonLabel1.Text = rdr.GetString(0);
                                BallsPlayedLabel.Text = rdr.GetInt32(4).ToString();
                            }
                        }
                       if(query == batsmanDetailsQueryMap["batsmanMaximumFours"])
                        {
                            while(rdr.Read())
                            {
                                SeasonLabel2.Text = rdr.GetString(0);
                                NumberOfFoursLabel.Text = rdr.GetInt32(4).ToString();
                            }
                        }
                       if(query == batsmanDetailsQueryMap["batsmanMaximumSixes"])
                        {
                            while(rdr.Read())
                            {
                                SeasonLabel3.Text = rdr.GetString(0);
                                NumberOfSixesLabel.Text = rdr.GetInt32(4).ToString();
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