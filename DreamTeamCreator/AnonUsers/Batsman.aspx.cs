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
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    ((CheckBox)row.FindControl("cbSelect")).Attributes.Add("onchange", "javascript:TextboxAutoEnableAndDisable(" + (row.RowIndex) + ");");
                }
            }
            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);
            try
            {
                string query = "SELECT TEAM_ID, TEAMS FROM TEAM_IDS";
                OracleCommand cmd = new OracleCommand(query, con);
                con.Open();
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataTextField = "TEAMS";
                DropDownList1.DataValueField = "TEAM_ID";
                DropDownList1.DataBind();

                DropDownList1.Items.Insert(0, new ListItem("Select a team", ""));
                DropDownList2.Items.Insert(0, new ListItem("Select an average", ""));
                DropDownList3.Items.Insert(0, new ListItem("Select a strike rate", ""));
            }
            catch(OracleException ex)
            {
                Response.Write("<br>/" + "<br>/" + "<br>/" + "<br>/" + "<br>/" + ex);
            }
            finally
            {
                con.Close();
            }
            
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);
            string teamQuery = "SELECT PLAYERNAME FROM PLAYER_IDS";

            if (!string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                //oracleQuery = teamQuery + " intersect SELECT * FROM IPL_MASTER_DATA WHERE STRIKE_BAT LIKE \'%" + TextBox1.Text + "%\'";
            }
            try
            {
                OracleCommand cmd = new OracleCommand(teamQuery, con);
                con.Open();
                OracleDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
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