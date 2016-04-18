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

namespace DreamTeamCreator
{
    public partial class DreamTeamCreator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["MatchNumber"] == null)
            {
                Application["MatchNumber"] = 1;
            }

            if (!IsPostBack)
            {
                string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
                OracleConnection con = new OracleConnection(oracleConnectionString);
                try
                {
                    string query = QueryBuilderClass.NextMatchQueryBuilder((int)Application["MatchNumber"]);
                    OracleCommand cmd = new OracleCommand(query, con);
                    con.Open();
                    OracleDataReader rdr = cmd.ExecuteReader();
                    NextMatchGridView.DataSource = rdr;
                    NextMatchGridView.DataBind();
                }
                catch (OracleException ex)
                {
                    Response.Write("<br>/" + "<br>/" + "<br>/" + "<br>/" + "<br>/" + ex);
                }
                finally
                {
                    con.Close();
                }

                string homeTeamString = NextMatchGridView.Rows[0].Cells[0].Text;
                string awayTeamString = NextMatchGridView.Rows[0].Cells[2].Text;

                try
                {
                    string query = QueryBuilderClass.NextMatchPlayerSelectionQueryBuilder(homeTeamString, awayTeamString);
                    OracleCommand cmd = new OracleCommand(query, con);
                    con.Open();
                    OracleDataReader rdr = cmd.ExecuteReader();
                    PlayersGridView.DataSource = rdr;
                    PlayersGridView.DataBind();
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

        protected void AddPlayer_Click(object sender, EventArgs e)
        {
            List<string> PlayerNames = new List<string>();
            foreach (GridViewRow row in PlayersGridView.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("playerSelectCheckBox");

                if (check.Checked)
                {
                    PlayerNames.Add(row.Cells[1].Text);
                }
            }

            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);

            try
            {
                con.Open();
                foreach (string playerName in PlayerNames) {
                    OracleCommand cmd = new OracleCommand("spAddUserTeam", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleTransaction transaction;

                    // string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "SHA1");

                    OracleParameter userid = new OracleParameter("USERID", (int)Session["UserId"]);
                    OracleParameter playername = new OracleParameter("PLAYERNAME", playerName);
                    OracleParameter rv = new OracleParameter("RETURNVALUE", OracleDbType.Int32, ParameterDirection.Output);




                    cmd.Parameters.Add(userid);
                    cmd.Parameters.Add(playername);
                    cmd.Parameters.Add(rv);




                    transaction = con.BeginTransaction();
                    cmd.ExecuteNonQuery();
                    transaction.Commit();

                    int returnCode = int.Parse(cmd.Parameters["RETURNVALUE"].Value.ToString());
                   
                    //if (returnCode == 1)
                    //{
                    //    Response.Write("Teams succesfully added");

                    //}
                    //else {

                    //    Response.Write("Please enter valid username and or password");
                    //}
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

        protected void NextMatch_Click(object sender, EventArgs e)
        {
            Application["MatchNumber"] = (int)Application["MatchNumber"]+1;
        }
    }
}