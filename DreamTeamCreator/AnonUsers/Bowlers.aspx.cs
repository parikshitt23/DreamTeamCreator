using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.UI;

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
            int ab = con.ConnectionTimeout;
          
            try
            {
                string query = QueryBuilderClass.BowlerQueryBuilder(DropTeam, EconomyDrop, Wickets_Taken, Name);
                OracleCommand cmd = new OracleCommand(query, con);
                con.Open();
                OracleConnection.ClearAllPools();
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

        protected void BowlerSearchRes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BowlerSearchRes_SelectedIndexChanging(object sender,GridViewSelectEventArgs e)
        {
            GridViewRow row = BowlerSearchRes.Rows[e.NewSelectedIndex];
            var m_values = this.GetValues(row);
        }

        public IDictionary<string, object> GetValues(GridViewRow row)
        {
            IOrderedDictionary dictionary = new OrderedDictionary();

            foreach (Control control in row.Controls)
            {
                DataControlFieldCell cell = control as DataControlFieldCell;

                if ((cell != null) && cell.Visible)
                {
                    cell.ContainingField.ExtractValuesFromCell
                    (dictionary, cell, row.RowState, true);
                }
            }

            IDictionary<string, object> values = new Dictionary<string, object>();

            foreach (DictionaryEntry de in dictionary)
            {
                values[de.Key.ToString()] = de.Value;
            }

            return values;
        }

        protected void BowlerSearchRes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details") {

                string eb = BowlerSearchRes.SelectedRow.Cells[0].Text;
                GridViewRowCollection row = BowlerSearchRes.Rows;
                string ex = "";

                // var m_values = this.GetValues(row);
                Response.Redirect("~/AnonUsers/BowlerDetails.aspx");
            }
        }
    }
}