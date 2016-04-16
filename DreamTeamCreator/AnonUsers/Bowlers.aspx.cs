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
using System.Text.RegularExpressions;
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
            if (!EconomyDrop.SelectedValue.Equals('0'))
            {
                econrange = EconomyDrop.Text;
            }            
//select distinct season, bowler, cast((sum(run_scored) / (count(*) / 6)) as numeric(15, 2)) as economy
//from ball_by_ball
//group by season, bowler
        }

        protected void WicketsSelect(object sender, EventArgs e)
        {
            if (!Wickets_Taken.SelectedValue.Equals('0'))
            {
                wicketsrange = Wickets_Taken.Text;
            }            
//select distinct season, bowler,count(*) as wickets_taken
//from ball_by_ball
//where out_decision <> '*'
//group by season, bowler
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            List<String> conditions=new List<string>();
            //int i = 0;
            //conditions.Add("");

            string master_q = "";
            string search_q = "";
            string econ_f = "";
            string wickets_f = "";
            string player_f=""; //data filtering conditions

            master_q = "select * from (select distinct season,bowler,sum(wickets_taken) wickets_taken,sum(economy) economy from (select distinct season, bowler, 0 as wickets_taken, cast((sum(run_scored) / (count(*) / 6)) as numeric(15, 2)) as economy from ball_by_ball where season <> '2015' group by season, bowler union all select distinct season, bowler, count(*) as wickets_taken, 0 as economy from ball_by_ball where out_decision <> '*' and season <> '2015' group by season, bowler) A group by A.season,A.bowler) all_data";

            if (!string.IsNullOrWhiteSpace(Name.Text)){
                player_f = "bowler like '%" + Name.Text + "%' ";
                conditions.Add(player_f);
            }

            if (!string.IsNullOrEmpty(econrange)) {
                //int high,low;
                List<int> range = split_input_range(econrange);
                if (range.ToArray().Length == 1) {
                    econ_f = "economy "+econrange+" ";
                }
                else
                {
                    econ_f = "economy >=" + range[0] + " and economy < " + range[1] + " ";
                }
                conditions.Add(econ_f);
            }

            if (!string.IsNullOrEmpty(wicketsrange))
            {
                //int high,low;
                List<int> range = split_input_range(wicketsrange);
                if (range.ToArray().Length == 1)
                {
                    wickets_f = "wickets_taken " + wicketsrange + " ";
                }
                else
                {
                    wickets_f = "wickets_taken >=" + range[0] + " and wickets_taken < " + range[1] + " ";
                }
                conditions.Add(wickets_f);
            }

            search_q = master_q;
            for(int k=0; k < conditions.ToArray().Length; k++)
            {
                if (k == 0)
                {
                    search_q += " where " + conditions[k];
                }
                else
                {
                    search_q += " and " + conditions[k];
                }                
            }

            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);
            try
            {
                OracleCommand cmd = new OracleCommand(search_q, con);
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

        //if return of below funtion is single digit, check the 1st character of input string to see if its the lower limit or the upper limit
        private List<int> split_input_range(string input) {
            List<int> range = new List<int>();
            string[] range_parse= input.Split(' ');
            if (range_parse.Length> 1)
            {
                range.Add(Int32.Parse(Regex.Match(range_parse[0], @"\d+").Value));
                range.Add(Int32.Parse(Regex.Match(range_parse[2], @"\d+").Value));
            }
            else
            {
                range.Add(Int32.Parse(Regex.Match(range_parse[0], @"\d+").Value));
            }
            return range;
        }
    }
}