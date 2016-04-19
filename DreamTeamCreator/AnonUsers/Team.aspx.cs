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
    public partial class Team : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TeamDetailsDiv.Visible = false;
        }

        protected void DropTeam_SelectedIndexChanged(object sender, EventArgs e)
        {

            TeamDetailsDiv.Visible = true;
            TeamNameLabel.Text = DropTeam.SelectedItem.Text;
            string team = DropTeam.SelectedItem.Text;
            Dictionary<string, string> teamDetailsQueryMap = QueryBuilderClass.TeamDetailsQueryBuilder(team);

            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);
            try
            {
                con.Open();
                foreach (string query in teamDetailsQueryMap.Values)
                {
                   
                   
                    OracleCommand cmd = new OracleCommand(query, con);

                    OracleDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        if (query == teamDetailsQueryMap["winPercentage"])
                        {
                            while (rdr.Read())
                            {
                               winNumberLabel.Text = rdr.GetInt32(1).ToString();
                               loseNumberLabel.Text = rdr.GetInt32(2).ToString();
                               winPercentageLabel.Text = rdr.GetFloat(3).ToString();
                            }
                        }

                        if (query == teamDetailsQueryMap["winPercentageChasingMatch"])
                        {
                            while (rdr.Read())
                            {
                                successfulChasesLabel.Text = rdr.GetInt32(1).ToString();
                                failedChasesLabel.Text = rdr.GetInt32(2).ToString();
                                winPercentageAfterTossWin.Text = rdr.GetFloat(3).ToString();
                            }
                        }

                        if (query == teamDetailsQueryMap["totalNumberOfAllOuts"])
                        {
                            while (rdr.Read())
                            {
                                totalNumberOfAllOutsLabel.Text = rdr.GetInt32(1).ToString();
                            }
                        }

                        if (query == teamDetailsQueryMap["homeGroundQuery"])
                        {
                            while (rdr.Read())
                            {
                                homeWinsLabel.Text = rdr.GetInt32(1).ToString();
                                homeLoseLabel.Text = rdr.GetInt32(2).ToString();
                                homeWinPercentageLabels.Text = rdr.GetFloat(3).ToString();

                            }
                        }

                        if (query == teamDetailsQueryMap["maxBoundariesByATeam"])
                        {
                            while (rdr.Read())
                            {
                                maxBoundariesInningsLabel.Text = rdr.GetInt32(4).ToString();

                            }
                        }

                        if (query == teamDetailsQueryMap["highestRunsScored"])
                        {
                            while (rdr.Read())
                            {
                                highestRunsScoredLabel.Text = rdr.GetInt32(4).ToString();
                                SeasonLabel.Text = rdr.GetString(0);

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